using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Arvore {
    public class TreeDAO {
        private List<int> outputValues;
        private ABPTree tree;
        private RichTextBox output_txt;
        static private string path = "C://temp/treeABP.xml";

        public TreeDAO(RichTextBox output_txt) {
            tree = new ABPTree();
            outputValues = new List<int>(1000);
            this.output_txt = output_txt;
            OperationCounter.Increment(3);
        }

        public List<int> List() { return outputValues; }

        public int GetNumberOfElements() {
            return tree.GetQuantity();
        }
        public void InsertElement(int elemento) {
            outputValues.Add(elemento);
            this.tree.Insert(elemento);
            OperationCounter.Increment(2);
        }

        public void RemoveElement(int elemento) {
            if(outputValues.Count > 0) {
                
                try {
                    
                    tree.Remove(elemento);
                    OperationCounter.Increment();
                    outputValues.Remove(elemento); // não será funcional.
                    OperationCounter.Increment();
                    
                } catch(Exception e) {
                    
                    output_txt.AppendText("Ocorreu um erro interno!\n");
                    output_txt.AppendText("Mensagem da Exceção:\n" + e.Message);
                    output_txt.AppendText("Local da Exceção:\n" + e.Source);
                }
                
            } else
                output_txt.AppendText("Não é possível remover um elemento de uma árvore de vazia!\n");
            
            OperationCounter.Increment();
        }

        public void SaveDAO() {
            output_txt.AppendText("Salvando árvore binária...\n");
            FileStream fs = null;

            try {
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
                OperationCounter.Increment();

                fs = new FileStream(path, FileMode.OpenOrCreate);
                OperationCounter.Increment();

                ser.Serialize(fs, outputValues);
                OperationCounter.Increment();

                output_txt.AppendText("Árvore binária salva!\n");
            } catch(Exception e) {
                output_txt.AppendText("Ocorreu um erro interno! Exceção: \n" + e.Message + "\n");
            }

            fs.Close();
            OperationCounter.Increment();
        }

        public void LoadDAO() {
            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            OperationCounter.Increment(2);

            try {
                //Carregar o arquivo xml e jogar na lista:
                outputValues = ser.Deserialize(fs) as List<int>;
                OperationCounter.Increment();
            } catch(Exception e) {
                ser.Serialize(fs, outputValues);
                OperationCounter.Increment();
                throw e;
            } finally {
                fs.Close();
                OperationCounter.Increment();
            }
        }

        public void CleanDao() {
            output_txt.AppendText("Limpando árvore binária...\n");
            tree = new ABPTree();
            this.outputValues = new List<int>();
            OperationCounter.Increment(2);
            SaveDAO();
            this.output_txt.AppendText("Árvore binária limpa!\n");
        }

        public int GetQuant(){
            return this.outputValues.Count;
        }
    }
}
