using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Pilha
{
    public class PilhaDAO
    {
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
        private List<int> valoresParaOutput;
        
        private Pilha pilha;
        private RichTextBox output_txt;
        private string caminho;

        public PilhaDAO(RichTextBox output_txt){
            this.pilha = new Pilha();
            this.valoresParaOutput = new List<int>();
            this.output_txt = output_txt;
            this.caminho = "C://temp//pilha.xml";
        }
        public List<int> Listar(){ return this.valoresParaOutput; }

        public void Empilhar(int elemento){
            this.valoresParaOutput.Add(elemento);
            this.pilha.Empilha(elemento);
        }
        public void Desempilhar()
        {
            if (this.valoresParaOutput.Count >0){
                try{
                    this.pilha.Desempilha();
                    this.valoresParaOutput.RemoveAt(this.valoresParaOutput.Count - 1);
                }
                catch (Exception e){
                    this.output_txt.AppendText("Ocorreu um erro Interno!\n");
                    this.output_txt.AppendText("Mensagem da Excessão:\n" + e.Message);
                    this.output_txt.AppendText("Local da Excessão:\n" + e.Source);
                }   
            }
            else{
                this.output_txt.AppendText("Não é possivel desempilhar uma pilha vazia!\n");   
            }
        }
        public void SalvarDao(){
            this.output_txt.AppendText("Salvando Pilha...\n");
            FileStream fs = null;
            try{
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));

                //Carrega o aqruivo da memória:
                fs = new FileStream(caminho, FileMode.OpenOrCreate);

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.valoresParaOutput);
            }
            catch (Exception e){
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }
            fs.Close();
            this.output_txt.AppendText("Pilha Salva!\n");
        }
        public void CarregarDao(){
            this.output_txt.AppendText("Carregando Pilha...\n");
            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(caminho, FileMode.OpenOrCreate);
            try{
                //Carregar o arquivo xml e jogar na lista:
                this.valoresParaOutput = ser.Deserialize(fs) as List<int>;
            }
            catch(Exception e){
                ser.Serialize(fs, this.valoresParaOutput);
                throw e;
            }
            finally{
                fs.Close();
            }
            this.output_txt.AppendText("Pilha Carregada!\n");
        }
        public void LimparDao(){
            this.output_txt.AppendText("Limpando Lista...\n");
            this.pilha = new Pilha();
            this.valoresParaOutput = new List<int>();
            SalvarDao();
            this.output_txt.AppendText("Lista Limpa!\n");
        }
    }
}