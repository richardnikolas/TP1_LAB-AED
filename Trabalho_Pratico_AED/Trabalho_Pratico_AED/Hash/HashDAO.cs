using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Trabalho_Pratico_AED;

namespace Exercicios.Exercicio1
{
    public class HashDAO{
        /*
         * Classe para manipulação de arquivo XML encontrado em "C:/temp/hash.xml"
         *
         * Feita por Philemon da Silva Souza
         *
         * com suporte de:
         *       Fabio Leandro Rodrigues Cordeiro
         */
        private TabelaHashLinear linearHashTable;
        private List<int>[] outputValues;
        private RichTextBox output_txt;
        static private string path = "C://temp/hash.xml";

        public HashDAO(RichTextBox output_txt){
            this.linearHashTable = new TabelaHashLinear(1000);
            this.outputValues = new List<int>[1000];
            for (int i = 0; i < outputValues.Length; i++){
                outputValues[i] = new List<int>();
            }
            this.output_txt = output_txt;
            ContadorOperacoes.Increment(3);
        }
        public void CarregarDao(){
            this.output_txt.AppendText("Carregando Tabela Hash...\n");

            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            ContadorOperacoes.Increment();
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            ContadorOperacoes.Increment();
            try {
                //Carregar o arquivo xml e jogar na lista:
                this.outputValues = ser.Deserialize(fs) as List<int>[];
                ContadorOperacoes.Increment();
            }
            catch(Exception e) {
                ser.Serialize(fs, this.outputValues);
                ContadorOperacoes.Increment();
                throw e;
            }
            finally {
                fs.Close();
                ContadorOperacoes.Increment();
            }

            this.output_txt.AppendText("Tabela Hash Carregada!\n");
        }

        public List<string> Listar(){
            List<string> saida = new List<string>();
            string valoresEmString ="";
            ContadorOperacoes.Increment(2);
            foreach (List<int> lista in outputValues){
                valoresEmString = "";
                ContadorOperacoes.Increment();
                foreach (int valor in lista){
                    ContadorOperacoes.Increment();
                    valoresEmString += "(" + valor + ") ";
                }
            }
            return saida;
        }
        public void Inserir(int element)
        {
            linearHashTable.Inserir(element);
            outputValues = linearHashTable.GetInternalStruct();
            ContadorOperacoes.Increment(2);
        }

        public void Remover(int elementToRemove)
        {
            if (linearHashTable.GetQuant() > 0){
                try{
                    linearHashTable.Remover(elementToRemove);
                    outputValues = linearHashTable.GetInternalStruct();
                    ContadorOperacoes.Increment();
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
            ContadorOperacoes.Increment();
        }
        public void SalvarDao(){
            this.output_txt.AppendText("Salvando Tabela Hash...\n");
            FileStream fs = null;
            try{
                //Acesso a dados XML (DAO):
                XmlSerializer ser = new XmlSerializer(typeof(List<int>[]));
                ContadorOperacoes.Increment();

                //Carrega o aqruivo da memória:
                fs = new FileStream(path, FileMode.OpenOrCreate);
                ContadorOperacoes.Increment();

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this.outputValues);
                ContadorOperacoes.Increment();
            }
            catch (Exception e){
                this.output_txt.AppendText("Ocorreu um erro interno! Excessão: \n" + e.Message+"\n");
            }
            fs.Close();
            ContadorOperacoes.Increment();
            this.output_txt.AppendText("Tabela Hash Salva!\n");
        }

        public void LimparDao(){
            this.output_txt.AppendText("Limpando Tabela Hash...\n");
            this.linearHashTable = new TabelaHashLinear();
            this.outputValues = new List<int>[outputValues.Length];
            SalvarDao();
            ContadorOperacoes.Increment(3);
            this.output_txt.AppendText("Tabela Hash Limpa!\n");
        }
    }
}