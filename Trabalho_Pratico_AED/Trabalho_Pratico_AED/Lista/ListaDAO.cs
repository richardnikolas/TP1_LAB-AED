using System.Collections.Generic;
using System.Windows.Forms;

namespace VS_Code{
    public class ListaDAO
    {
        /*
         * Classe para manipulação de arquivo XML encontrado em "C:/temp/lista.xml"
         *
         * Feita por Philemon da Silva Souza
         *
         * com suporte de:
         *       Fabio Leandro Rodrigues Cordeiro
         */
        
        // A lista "valoresParaOutput" se faz necessária devido à classe DataGridView, nativa do C#,
        //que, até onde entendo, só aceita a inserção de uma lista de objetos:
        private List<int> valoresParaOutput;
        
        private ListaSimples lista;
        private RichTextBox output_txt;

        public ListaDAO(RichTextBox output_txt){
            this.output_txt = output_txt;
            this.valoresParaOutput = new List<int>();
            this.lista = new ListaSimples();
        }
    }
}