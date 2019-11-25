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

        private TabelaHashLinear _hashTable;
        private HashCell[] outputValues;
        private RichTextBox output_txt;
        static private string path = "C://temp/hash.xml";

        public HashDAO(RichTextBox output_txt) {
            this._hashTable = new TabelaHashLinear(1000);
            this.outputValues = _hashTable.GetInternalStruct();
            this.output_txt = output_txt;
            OperationCounter.Increment(3);
        }

        public void LoadDAO() {
            XmlSerializer ser = new XmlSerializer(typeof(HashCell[]));
            OperationCounter.Increment();

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            OperationCounter.Increment();

            try {
                //Carregar o arquivo xml e jogar na lista:
                _hashTable.SetInternalStruct(ser.Deserialize(fs) as HashCell[]); 
                OperationCounter.Increment();
            }
            catch (Exception e) {
                ser.Serialize(fs, _hashTable.GetInternalStruct());
                OperationCounter.Increment();
                throw e;
            }
            finally {
                fs.Close();
                SaveDao();
                OperationCounter.Increment(4);
            }
        }

        public HashCell[] List(){
            return _hashTable.GetInternalStruct();
        }

        public void Insert(int element) {
            _hashTable.Insert(_hashTable.HashKey(element), element, 0);
            OperationCounter.Increment();
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
                XmlSerializer ser = new XmlSerializer(typeof(HashCell[]));
                OperationCounter.Increment();

                //Carrega o aqruivo da memória:
                fs = new FileStream(path, FileMode.OpenOrCreate);
                OperationCounter.Increment();

                //Usando a lista criada e mandando para o FileStream, num formato de XML:
                ser.Serialize(fs, this._hashTable.GetInternalStruct());
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
            this._hashTable = new TabelaHashLinear();
            this.outputValues = this._hashTable.GetInternalStruct();
            SaveDao();
            OperationCounter.Increment(3);
            this.output_txt.AppendText("Tabela Hash Limpa!\n");
        }

        public void SortDao() {
            //this.outputValues.Sort();
            SaveDao();
        }

        public int GetQuant() {
            return _hashTable.GetQuant();
        }
    }
}