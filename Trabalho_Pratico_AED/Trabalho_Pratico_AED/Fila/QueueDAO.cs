﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Fila {

    public class QueueDAO {
        /*
         * Classe para manipulação de arquivo XML encontrado em "C:/temp/fila.xml"
         *
         * Feita por Philemon da Silva Souza
         *
         * com suporte de:
         *       Fabio Leandro Rodrigues Cordeiro
         */
        List<int> valuesToOutput;
        private Queue queue;
        private RichTextBox output_txt;
        static private string path = "C://temp/fila.xml";

        public QueueDAO(RichTextBox output_txt) {
            queue = new Queue();
            valuesToOutput = new List<int>(1000);
            this.output_txt = output_txt;
        }

        public List<int> Listar() { return valuesToOutput; }

        public int GetNumberOfElements() {
            return queue.GetQuantity();
        }
        public void EnqueueElement(int elemento) {
            valuesToOutput.Add(elemento);
            this.queue.Enqueue(elemento);
            OperationCounter.Increment(2);
        }

        public void DequeueElement() {
            if(valuesToOutput.Count > 0) {
                try {
                    queue.Dequeue();
                    OperationCounter.Increment();
                    valuesToOutput.RemoveAt(0);
                    OperationCounter.Increment();
                }
                catch (Exception e){
                    output_txt.AppendText("Ocorreu um erro interno!\n");
                    output_txt.AppendText("Mensagem da Exceção:\n" + e.Message);
                    output_txt.AppendText("Local da Exceção:\n" + e.Source);
                }
            }
            else
                output_txt.AppendText("Não é possível desenfileirar uma fila vazia!\n");            
        }

        public void SaveDAO() {
            output_txt.AppendText("Salvando fila...\n");
            FileStream fs = null;

            try {
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
                OperationCounter.Increment();

                fs = new FileStream(path, FileMode.OpenOrCreate);
                OperationCounter.Increment();

                ser.Serialize(fs, valuesToOutput);
                OperationCounter.Increment();

                output_txt.AppendText("Fila salva!\n");
            } catch (Exception e) {
                output_txt.AppendText("Ocorreu um erro interno! Exceção: \n" + e.Message + "\n");
            }

            fs.Close();
        }

        public void CarregarDAO() {
            output_txt.AppendText("Carregando fila...\n");

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            OperationCounter.Increment(2);

            try {
                //Carregar o arquivo xml e jogar na lista:
                valuesToOutput = ser.Deserialize(fs) as List<int>;
                OperationCounter.Increment();
            } catch(Exception e) { 
                ser.Serialize(fs, valuesToOutput);
                OperationCounter.Increment();
                throw e;
            } finally {
                fs.Close();
                OperationCounter.Increment();
            }

            output_txt.AppendText("Fila carregada!\n");
        }

        public void LimparDao() {
            output_txt.AppendText("Limpando Lista...\n");
            queue = new Queue();
            this.valuesToOutput = new List<int>();
            OperationCounter.Increment(2);
            SaveDAO();
            this.output_txt.AppendText("Lista Limpa!\n");
        }
    }
}
