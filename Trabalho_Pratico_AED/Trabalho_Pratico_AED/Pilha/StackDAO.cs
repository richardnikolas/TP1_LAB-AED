using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Pilha {

    public class StackDAO {
        /*
         * Classe para manipulação de arquivo XML encontrado em "C:/temp/pilha.xml"
         *
         * Feita por Philemon da Silva Souza
         *
         * com suporte de:
         *       Fabio Leandro Rodrigues Cordeiro
         */
        
        // A lista "valoresParaOutput" se faz necessária devido à classe DataGridView, nativa do C#,
        //que, até onde entendo, só aceita a inserção de uma lista de objetos:

        private List<int> outputValues;
        
        private Pilha stack;
        private RichTextBox output_txt;
        static private string path = "C://temp/pilha.xml";

        public StackDAO(RichTextBox output_txt) {
            this.stack = new Pilha();
            this.outputValues = new List<int>();
            this.output_txt = output_txt;
            OperationCounter.Increment(3);
        }

        public List<int> List() { return this.outputValues; }

        public void Stack(int element) {
            this.outputValues.Add(element);
            this.stack.Stack(element);
            OperationCounter.Increment(2);
        }

        public void Unstack() {
            if (this.outputValues.Count >0) {
                try {
                    this.stack.Unstack();
                    OperationCounter.Increment();
                    this.outputValues.RemoveAt(this.outputValues.Count - 1);
                    OperationCounter.Increment();
                }
                catch (Exception e) {
                    this.output_txt.AppendText("Ocorreu um erro Interno!\n");
                    this.output_txt.AppendText("Mensagem da Exceção:\n" + e.Message);
                    this.output_txt.AppendText("Local da Exceção:\n" + e.Source);
                }   
            }
            else
                this.output_txt.AppendText("Não é possivel desempilhar uma pilha vazia!\n");               
        }

        public void SaveDao() {
            this.output_txt.AppendText("Salvando Pilha...\n");
            FileStream fs = null;

            try {
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
                OperationCounter.Increment();

                //Carrega o aqruivo da memória:
                fs = new FileStream(path, FileMode.OpenOrCreate);
                OperationCounter.Increment();

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.outputValues);
                OperationCounter.Increment();
            }
            catch (Exception e) {
                this.output_txt.AppendText("Ocorreu um erro interno! Exceção: \n" + e.Message+"\n");
            }

            fs.Close();
            this.output_txt.AppendText("Pilha Salva!\n");
        }

        public void LoadDAO() {

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            OperationCounter.Increment();
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            OperationCounter.Increment();

            try {
                //Carregar o arquivo xml e jogar na lista:
                this.outputValues = ser.Deserialize(fs) as List<int>;
                OperationCounter.Increment();
            }
            catch(Exception e) {
                ser.Serialize(fs, this.outputValues);
                OperationCounter.Increment();
                throw e;
            }
            finally {
                fs.Close();
                OperationCounter.Increment();
            }
        }

        public void CleanDao() {
            this.output_txt.AppendText("Limpando Lista...\n");
            this.stack = new Pilha();
            this.outputValues = new List<int>();
            OperationCounter.Increment(2);
            SaveDao();
            this.output_txt.AppendText("Lista Limpa!\n");
        }

        public void SortDao(){
            this.outputValues.Sort();
            SaveDao();
        }

        public int GetQuant(){
            return stack.Quantidade();
        }
    }
}