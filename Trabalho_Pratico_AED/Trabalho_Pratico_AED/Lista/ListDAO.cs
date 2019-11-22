using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Trabalho_Pratico_AED;

namespace VS_Code{
    public class ListDAO{
        /*
         * Classe para manipulação de arquivo XML encontrado em "C:/temp/lista.xml"
         *
         * Feita por Philemon da Silva Souza
         *
         * com suporte de:
         *       Fabio Leandro Rodrigues Cordeiro
         */
        
        private List<int> list;
        private RichTextBox output_txt;
        static private string path = "C://temp//lista.xml";

        public ListDAO(RichTextBox output_txt) {
            this.output_txt = output_txt;
            this.list = new List<int>();
            OperationCounter.Increment(2);
        }

        public List<int> List() { return this.list; }

        public void Insert(int element) {
            list.Add(element);
            OperationCounter.Increment();
        }

        public void RemoveAt(int indexToRemove) {
            if (list.Count > 0) {
                try {
                    list.RemoveAt(indexToRemove);
                    OperationCounter.Increment(2);
                }
                catch (Exception e) {
                    this.output_txt.AppendText("ERRO! Não é possivel remover o íncide específicado!\n");
                    this.output_txt.AppendText("Mensagem da Excessão:\n" + e.Message);
                    this.output_txt.AppendText("Local da Excessão:\n" + e.Source);
                }
            }
            else 
                this.output_txt.AppendText("Não é possível remover elementos de uma lista vazia!\n");            
        }

        public void SaveDao() {
            this.output_txt.AppendText("Salvando Lista...\n");
            FileStream fs = null;

            try {
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
                OperationCounter.Increment();

                //Carrega o aqruivo da memória:
                fs = new FileStream(path, FileMode.OpenOrCreate);
                OperationCounter.Increment();

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.list);
                OperationCounter.Increment();
            }
            catch (Exception e) {
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }

            fs.Close();
            OperationCounter.Increment();
            this.output_txt.AppendText("Lista Salva!\n");
        }

        public void LoadDAO(){

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            OperationCounter.Increment();

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            OperationCounter.Increment();

            try {
                //Carregar o arquivo xml e jogar na lista:
                this.list = ser.Deserialize(fs) as List<int>;
                OperationCounter.Increment();
            }
            catch(Exception e) {
                ser.Serialize(fs, this.list);
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
            this.list = new List<int>();

            SaveDao();

            this.output_txt.AppendText("Lista Limpa!\n");
            OperationCounter.Increment();
        }

        public void SortDao() {
            this.list.Sort();
            OperationCounter.Increment();
        }

        public int GetQuant(){
            return this.list.Count;
        }
    }
}