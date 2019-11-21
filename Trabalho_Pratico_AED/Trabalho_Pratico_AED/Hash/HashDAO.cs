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
        private List<int> valoresParaOutput;
        private RichTextBox output_txt;
        static private string caminho = "C://temp/hash.xml";

        public HashDAO(RichTextBox output_txt){
            this.tabelaHash = new TabelaHashLinear(1000);
            this.valoresParaOutput = new List<int>();
            this.output_txt = output_txt;
            ContadorOperacoes.Incrementa(3);
        }

        public void inserir(int elemento)
        {
            tabelaHash.inserir(elemento);
            valoresParaOutput.Add(elemento);
            ContadorOperacoes.Incrementa(2);
        }

        public void remover(int elementoARemover)
        {
            if (tabelaHash.getQuant() > 0){
                try{
                    tabelaHash.remover(elementoARemover);
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
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
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
    }
}