using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Trabalho_Pratico_AED;

namespace VS_Code{
    public class ListaDAO{
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

        public ListaDAO(RichTextBox output_txt) {
            this.output_txt = output_txt;
            this.list = new List<int>();
            ContadorOperacoes.Increment(2);
        }

        public List<int> Listar() { return this.list; }

        public void Inserir(int element) {
            list.Add(element);
            ContadorOperacoes.Increment();
        }

        public void Remover(int indexToRemove) {
            if (list.Count > 0) {
                try {
                    list.RemoveAt(indexToRemove);
                    ContadorOperacoes.Increment(2);
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

        public void SalvarDao() {
            this.output_txt.AppendText("Salvando Lista...\n");
            FileStream fs = null;

            try {
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
                ContadorOperacoes.Increment();

                //Carrega o aqruivo da memória:
                fs = new FileStream(path, FileMode.OpenOrCreate);
                ContadorOperacoes.Increment();

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.list);
                ContadorOperacoes.Increment();
            }
            catch (Exception e) {
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }

            fs.Close();
            ContadorOperacoes.Increment();
            this.output_txt.AppendText("Lista Salva!\n");
        }

        public void CarregarDao(){
            this.output_txt.AppendText("Carregando Lista...\n");

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            ContadorOperacoes.Increment();

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            ContadorOperacoes.Increment();

            try {
                //Carregar o arquivo xml e jogar na lista:
                this.list = ser.Deserialize(fs) as List<int>;
                ContadorOperacoes.Increment();
            }
            catch(Exception e) {
                ser.Serialize(fs, this.list);
                ContadorOperacoes.Increment();
                throw e;
            }
            finally {
                fs.Close();
                ContadorOperacoes.Increment();
            }

            this.output_txt.AppendText("Lista Carregada!\n");
        }

        public void LimparDao() {
            this.output_txt.AppendText("Limpando Lista...\n");
            this.list = new List<int>();

            SalvarDao();

            this.output_txt.AppendText("Lista Limpa!\n");
            ContadorOperacoes.Increment();
        }

        public void OrdernarDao() {
            this.output_txt.AppendText("Ordenando Lista...\n");

            this.list.Sort();

            this.output_txt.AppendText("Lista ordenada!...\n");
            ContadorOperacoes.Increment();
        }
    }
}