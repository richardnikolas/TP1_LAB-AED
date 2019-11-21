using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

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
        
        private List<int> lista;
        private RichTextBox output_txt;
        static private string caminho = "C://temp//lista.xml";

        public ListaDAO(RichTextBox output_txt) {
            this.output_txt = output_txt;
            this.lista = new List<int>();
        }

        public List<int> Listar() { return this.lista; }

        public void Inserir(int elemento) {
            lista.Add(elemento);
        }

        public void Remover(int indiceDaRemocao) {
            if (lista.Count > 0) {
                try {
                    lista.RemoveAt(indiceDaRemocao);
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

                //Carrega o aqruivo da memória:
                fs = new FileStream(caminho, FileMode.OpenOrCreate);

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.lista);
            }
            catch (Exception e) {
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }

            fs.Close();
            this.output_txt.AppendText("Lista Salva!\n");
        }

        public void CarregarDao(){
            this.output_txt.AppendText("Carregando Lista...\n");

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(caminho, FileMode.OpenOrCreate);

            try {
                //Carregar o arquivo xml e jogar na lista:
                this.lista = ser.Deserialize(fs) as List<int>;
            }
            catch(Exception e) {
                ser.Serialize(fs, this.lista);
                throw e;
            }
            finally {
                fs.Close();
            }

            this.output_txt.AppendText("Lista Carregada!\n");
        }

        public void LimparDao(){
            this.output_txt.AppendText("Limpando Lista...\n");
            this.lista = new List<int>();
            SalvarDao();
            this.output_txt.AppendText("Lista Limpa!\n");            
        }
    }
}