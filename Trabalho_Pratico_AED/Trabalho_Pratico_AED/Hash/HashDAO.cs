using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Trabalho_Pratico_AED;

namespace Exercicios.Exercicio1
{
    public class HashDAO
    {
        private TabelaHashLinear tabelaHash;
        private List<int>[] valoresParaOutput;
        private RichTextBox output_txt;
        static private string caminho = "C://temp/hash.xml";

        public HashDAO(RichTextBox output_txt){
            this.tabelaHash = new TabelaHashLinear(1000);
            this.valoresParaOutput = new List<int>[1000];
            this.output_txt = output_txt;
            ContadorOperacoes.Incrementa(3);
        }
        public void CarregarDao(){
            this.output_txt.AppendText("Carregando Tabela Hash...\n");

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            ContadorOperacoes.Incrementa();
            FileStream fs = new FileStream(caminho, FileMode.OpenOrCreate);
            ContadorOperacoes.Incrementa();
            try {
                //Carregar o arquivo xml e jogar na lista:
                this.valoresParaOutput = ser.Deserialize(fs) as List<int>[];
                ContadorOperacoes.Incrementa();
            }
            catch(Exception e) {
                ser.Serialize(fs, this.valoresParaOutput);
                ContadorOperacoes.Incrementa();
                throw e;
            }
            finally {
                fs.Close();
                ContadorOperacoes.Incrementa();
            }

            this.output_txt.AppendText("Tabela Hash Carregada!\n");
        }

        public List<string> Listar(){
            List<string> saida = new List<string>();
            string valoresEmString ="";
            ContadorOperacoes.Incrementa(2);
            foreach (List<int> lista in valoresParaOutput){
                valoresEmString = "";
                ContadorOperacoes.Incrementa();
                foreach (int valor in lista){
                    ContadorOperacoes.Incrementa();
                    valoresEmString += "(" + valor + ") ";
                }
            }
            return saida;
        }
        public void inserir(int elemento)
        {
            tabelaHash.inserir(elemento);
            valoresParaOutput = tabelaHash.getEstrutura();
            ContadorOperacoes.Incrementa(2);
        }

        public void remover(int elementoARemover)
        {
            if (tabelaHash.getQuant() > 0){
                try{
                    tabelaHash.remover(elementoARemover);
                    valoresParaOutput = tabelaHash.getEstrutura();
                    ContadorOperacoes.Incrementa();
                }
                catch (Exception e){
                    this.output_txt.AppendText("ERRO! Não é possivel remover o elemento específicado!\n");
                    this.output_txt.AppendText("Mensagem da Excessão:\n" + e.Message);
                    this.output_txt.AppendText("Local da Excessão:\n" + e.Source);
                }
            }
            else{
                this.output_txt.AppendText("Não é possível remover elementos de uma tabela Hash Vazia!\n");
            }
            ContadorOperacoes.Incrementa();
        }
        public void SalvarDao(){
            this.output_txt.AppendText("Salvando Tabela Hash...\n");
            FileStream fs = null;
            try{
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>[]));
                ContadorOperacoes.Incrementa();

                //Carrega o aqruivo da memória:
                fs = new FileStream(caminho, FileMode.OpenOrCreate);
                ContadorOperacoes.Incrementa();

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.valoresParaOutput);
                ContadorOperacoes.Incrementa();
            }
            catch (Exception e){
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }
            fs.Close();
            ContadorOperacoes.Incrementa();
            this.output_txt.AppendText("Tabela Hash Salva!\n");
        }

        public void LimparDao(){
            this.output_txt.AppendText("Limpando Tabela Hash...\n");
            this.tabelaHash = new TabelaHashLinear();
            this.valoresParaOutput = new List<int>[valoresParaOutput.Length];
            SalvarDao();
            ContadorOperacoes.Incrementa(3);
            this.output_txt.AppendText("Tabela Hash Limpa!\n");
        }
    }
}