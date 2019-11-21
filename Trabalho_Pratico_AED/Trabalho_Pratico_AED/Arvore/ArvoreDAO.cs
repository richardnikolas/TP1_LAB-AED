using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Arvore {
    class ArvoreDAO {
        List<int> valuesToOutput;
        private ArvoreABP tree;
        private RichTextBox output_txt;
        private string path;

        public ArvoreDAO(RichTextBox output_txt) {
            tree = new ArvoreABP();
            valuesToOutput = new List<int>(1000);
            this.output_txt = output_txt;
            path = "C://temp/treeABP.xml";
        }

        public List<int> Listar() { return valuesToOutput; }

        public int GetNumberOfElements() {
            return tree.GetQuantity();
        }
        public void InsertElement(int elemento) {
            valuesToOutput.Add(elemento);
            this.tree.Insert(elemento);
        }

        public void RemoveElement(int elemento) {
            if(valuesToOutput.Count > 0) {
                try {
                    tree.Remove(elemento);
                    valuesToOutput.Remove(elemento); // não será funcional.
                } catch(Exception e) {
                    output_txt.AppendText("Ocorreu um erro interno!\n");
                    output_txt.AppendText("Mensagem da Exceção:\n" + e.Message);
                    output_txt.AppendText("Local da Exceção:\n" + e.Source);
                }
            } else
                output_txt.AppendText("Não é possível remover um elemento de uma árvore de vazia!\n");
        }

        public void SalvarDAO() {
            output_txt.AppendText("Salvando árvore binária...\n");
            FileStream fs = null;

            try {
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));

                fs = new FileStream(path, FileMode.OpenOrCreate);

                ser.Serialize(fs, valuesToOutput);

                output_txt.AppendText("Árvore binária salva!\n");
            } catch(Exception e) {
                output_txt.AppendText("Ocorreu um erro interno! Exceção: \n" + e.Message + "\n");
            }

            fs.Close();
        }

        public void CarregarDAO() {
            output_txt.AppendText("Carregando árvore binária...\n");
            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            try {
                //Carregar o arquivo xml e jogar na lista:
                valuesToOutput = ser.Deserialize(fs) as List<int>;
            } catch(Exception e) {
                ser.Serialize(fs, valuesToOutput);
                throw e;
            } finally {
                fs.Close();
            }

            output_txt.AppendText("Árvore binária carregada!\n");
        }

        public void LimparDao() {
            output_txt.AppendText("Limpando árvore binária...\n");
            tree = new ArvoreABP();
            this.valuesToOutput = new List<int>();
            SalvarDAO();
            this.output_txt.AppendText("Árvore binária limpa!\n");
        }
    }
}
