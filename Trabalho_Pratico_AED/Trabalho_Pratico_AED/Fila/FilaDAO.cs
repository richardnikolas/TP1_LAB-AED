using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Trabalho_Pratico_AED.Fila {
    public class FilaDAO {
        List<int> valoresParaOutput;
        private Fila fila;
        private RichTextBox output_txt;
        private string caminho;

        public FilaDAO(RichTextBox output_txt) {
            fila = new Fila();
            valoresParaOutput = new List<int>(1000);
            this.output_txt = output_txt;
            caminho = "C://temp/fila.xml";
        }
        public List<int> Listar() { return valoresParaOutput; }

        public void Enfileirar(int elemento) {
            valoresParaOutput.Add(elemento);
            this.fila.enqueue(elemento);
        }
        public void Desenfileirar() {
            if(valoresParaOutput.Count > 0) {
                try {
                    fila.dequeue();
                    valoresParaOutput.RemoveAt(0);
                }
                catch (Exception e){
                    output_txt.AppendText("Ocorreu um erro interno!\n");
                    output_txt.AppendText("Mensagem da Exceção:\n" + e.Message);
                    output_txt.AppendText("Local da Exceção:\n" + e.Source);
                }
            } else {
                output_txt.AppendText("Não é possível desenfileirar uma fila vazia!\n");
            }
        }
        public void SalvarDAO() {
            output_txt.AppendText("Salvando fila...\n");
            FileStream fs = null;
            try {
                XmlSerializer ser = new XmlSerializer(typeof(List<int>));

                fs = new FileStream(caminho, FileMode.OpenOrCreate);

                ser.Serialize(fs, valoresParaOutput);

                output_txt.AppendText("Fila salva!\n");
            } catch (Exception e) {
                output_txt.AppendText("Ocorreu um erro interno! Exceção: \n" + e.Message + "\n");
            }
            fs.Close();
        }
        public void CarregarDAO() {
            output_txt.AppendText("Carregando fila...\n");
            XmlSerializer ser = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream(caminho, FileMode.OpenOrCreate);
            try {
                //Carregar o arquivo xml e jogar na lista:
                valoresParaOutput = ser.Deserialize(fs) as List<int>;
            } catch(Exception e) { 
                ser.Serialize(fs, valoresParaOutput);
                throw e;
            } finally {
                fs.Close();
            }
            output_txt.AppendText("Fila carregada!\n");
        }
        public void LimparDao() {
            output_txt.AppendText("Limpando Lista...\n");
            fila = new Fila();
            this.valoresParaOutput = new List<int>();
            SalvarDAO();
            this.output_txt.AppendText("Lista Limpa!\n");
        }
    }
}
