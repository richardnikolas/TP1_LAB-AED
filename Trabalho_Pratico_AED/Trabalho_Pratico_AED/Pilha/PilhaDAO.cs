using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Pilha
{
    public class PilhaDAO
    {
        //Classe para manipulação de arquivo XML encontrado em "C:/temp/pilha.xml"
        private List<int> valoresParaOutput;
        private Pilha pilha;
        private RichTextBox output_txt;

        public PilhaDAO(RichTextBox output_txt){
            this.pilha = new Pilha();
            this.valoresParaOutput = new List<int>();
            this.output_txt = output_txt;
        }
        public List<int> Listar(){ return this.valoresParaOutput; }

        public void Empilhar(int elemento){
            this.valoresParaOutput.Add(elemento);
            this.pilha.Empilha(elemento);
        }
        public void Desempilhar()
        {
            if (!this.pilha.Vazia()){
                try{
                    this.pilha.Desempilha();
                    this.valoresParaOutput.RemoveAt(this.valoresParaOutput.Count - 1);
                }
                catch (Exception e){
                    this.output_txt.AppendText("Ocorreu um erro interno! Função: Remover() em PilhaDAO.cs\n");
                }   
            }
            else{
                this.output_txt.AppendText("Não é possivel desempilhar uma pilha vazia!\n");   
            }
        }
        public void SalvarDao(){
            this.output_txt.AppendText("Salvando DAO...\n");
            FileStream fs = null;
            try{
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));

                //Carrega o aqruivo da memória:
                fs = new FileStream("C://temp//pilha.xml", FileMode.OpenOrCreate);

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.valoresParaOutput);
            }
            catch (Exception e){
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }
            fs.Close();
            this.output_txt.AppendText("DAO Salvo!\n");
        }
        public void CarregarDao(){
            this.output_txt.AppendText("Carregando DAO...\n");
            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream("C://temp//pilha.xml", FileMode.OpenOrCreate);
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
        }
        public void LimparDao(){
            this.output_txt.AppendText("Limpando DAO...\n");
            this.pilha = new Pilha();
            this.valoresParaOutput = new List<int>();
            SalvarDao();
        }
    }
}