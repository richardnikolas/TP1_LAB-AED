using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Trabalho_Pratico_AED;

namespace Exercicios.Exercicio1 {

    public class HashDAO {
        /*
         * Classe para manipulação de arquivo XML encontrado em "C:/temp/hash.xml"
         *
         * Feita por Philemon da Silva Souza
         *
         * com suporte de:
         *       Fabio Leandro Rodrigues Cordeiro
         */

        private LinearHash _hashTable;
        private List<int> outputValues;
        private RichTextBox output_txt;
        static private string path = "C://temp/hash.xml";

        public HashDAO(RichTextBox output_txt) {
            this._hashTable = new LinearHash(1000);
            this.outputValues = new List<int>();
            this.output_txt = output_txt;
            OperationCounter.Increment(3);
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
            catch (Exception e) {
                ser.Serialize(fs, this.outputValues);
                OperationCounter.Increment();
                throw e;
            }
            finally {
                fs.Close();
                SaveDao();
                OperationCounter.Increment(4);
            }
        }

        public List<int> List() {
            UpdateOutput();
            return outputValues;
        }

        public void Insert(int element) {
            _hashTable.Insert(element);
            UpdateOutput();
            OperationCounter.Increment(2);
        }

        private void UpdateOutput() {
            outputValues = new List<int>();
            OperationCounter.Increment();
            
            foreach (int? n in _hashTable.GetInternalStruct()){
                OperationCounter.Increment();

                if (n != null)
                    outputValues.Add((int)n); break;
            }
        }

        public void Remove(int valueToRemove) {
            if (_hashTable.GetQuant() > 0) {
              _hashTable.Remove(valueToRemove);
              SaveDao();
              OperationCounter.Increment();
            }
            else
                this.output_txt.AppendText("Não é possível remover elementos de uma tabela Hash Vazia!\n");
            
            OperationCounter.Increment();
        }

        public void SaveDao() {
            this.output_txt.AppendText("Salvando Tabela Hash...\n");
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
            OperationCounter.Increment();
            this.output_txt.AppendText("Tabela Hash Salva!\n");
        }

        public void CleanDao() {
            this.output_txt.AppendText("Limpando Tabela Hash...\n");
            this._hashTable = new LinearHash();
            this.outputValues = new List<int>();
            SaveDao();
            OperationCounter.Increment(3);
            this.output_txt.AppendText("Tabela Hash Limpa!\n");
        }

        public void SortDao() {
            this.outputValues.Sort();
            SaveDao();
        }

        public int GetQuant() {
            return _hashTable.GetQuant();
        }
    }
}