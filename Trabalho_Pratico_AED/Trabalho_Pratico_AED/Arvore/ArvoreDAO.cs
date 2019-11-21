using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Arvore {
    public class ArvoreDAO {
        List<int> valuesToOutput;
        private ArvoreABP tree;
        private RichTextBox output_txt;
        static private string path = "C://temp/treeABP.xml";

        public ArvoreDAO(RichTextBox output_txt) {
            tree = new ArvoreABP();
            valuesToOutput = new List<int>(1000);
            this.output_txt = output_txt;
            ContadorOperacoes.Increment(3);
        }

        public List<int> Listar() { return valuesToOutput; }

        public int GetNumberOfElements() {
            return tree.GetQuantity();
        }
        public void InsertElement(int elemento) {
            valuesToOutput.Add(elemento);
            this.tree.Insert(elemento);
            ContadorOperacoes.Increment(2);
        }

        public void RemoveElement(int elemento) {
            if(valuesToOutput.Count > 0) {
                try {
                    tree.Remove(elemento);
                    ContadorOperacoes.Increment();
                    valuesToOutput.Remove(elemento); // não será funcional.
                    ContadorOperacoes.Increment();
                } catch(Exception e) {
                    output_txt.AppendText("Ocorreu um erro interno!\n");
                    output_txt.AppendText("Mensagem da Exceção:\n" + e.Message);
                    output_txt.AppendText("Local da Exceção:\n" + e.Source);
                }
            } else
                output_txt.AppendText("Não é possível remover um elemento de uma árvore de vazia!\n");
            ContadorOperacoes.Increment();
        }

        public void SalvarDAO() {
            output_txt.AppendText("Salvando árvore binária...\n");
            FileStream fs = null;

            try {
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));
                ContadorOperacoes.Increment();

                fs = new FileStream(path, FileMode.OpenOrCreate);
                ContadorOperacoes.Increment();

                ser.Serialize(fs, valuesToOutput);
                ContadorOperacoes.Increment();

                output_txt.AppendText("Árvore binária salva!\n");
            } catch(Exception e) {
                output_txt.AppendText("Ocorreu um erro interno! Exceção: \n" + e.Message + "\n");
            }

            fs.Close();
            ContadorOperacoes.Increment();
        }

        public void CarregarDAO() {
            output_txt.AppendText("Carregando árvore binária...\n");
            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            ContadorOperacoes.Increment(2);

            try {
                //Carregar o arquivo xml e jogar na lista:
                valuesToOutput = ser.Deserialize(fs) as List<int>;
                ContadorOperacoes.Increment();
            } catch(Exception e) {
                ser.Serialize(fs, valuesToOutput);
                ContadorOperacoes.Increment();
                throw e;
            } finally {
                fs.Close();
                ContadorOperacoes.Increment();
            }

            output_txt.AppendText("Árvore binária carregada!\n");
        }

        public void LimparDao() {
            output_txt.AppendText("Limpando árvore binária...\n");
            tree = new ArvoreABP();
            this.valuesToOutput = new List<int>();
            ContadorOperacoes.Increment(2);
            SalvarDAO();
            this.output_txt.AppendText("Árvore binária limpa!\n");
        }
    }
}
