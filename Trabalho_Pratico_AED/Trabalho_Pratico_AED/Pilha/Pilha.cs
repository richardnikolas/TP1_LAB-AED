using System;
using System.Collections;

namespace Trabalho_Pratico_AED.Pilha {

    public class Pilha : IEnumerable {
        /*
         * Tabela hash feita por Rodrigo Richard para as aulas de AED
         *
         * Autor: Rodrigo Richard
         *
         * Com ajustes por:
         *       Philemon da Silva Souza
         */
        private Celula Topo = null;
        private int Qtde = 0;
        public Pilha(){}

        public bool Vazia() { return Topo == null; }

        public void Stack(Object itemValue) {
            Topo = new Celula(itemValue, Topo);
            Qtde++;
            OperationCounter.Increment(2);
        }

        public Object Unstack() {
            Object Item = null;

            if (Topo != null) {
                Item = Topo.Item;
                Topo = Topo.Prox;
                Qtde--;
            }

            OperationCounter.Increment(3);
            return Item;
        }

        /// <summary>
        /// Verifica se o Item passado como parâmetro está contido na lista. (Obs: usa o comando FOR)
        /// </summary>
        public bool ContemFor(Object element) {
            bool achou = false;

            for (Celula aux = Topo; aux != null && !achou; aux = aux.Prox){
                OperationCounter.Increment();
                achou = aux.Item.Equals(element);
            }
                

            return achou;
        }

        /// <summary>
        /// Retorna o Item do Topo da Pilha sem removê-lo.
        /// </summary>
        public Object Peek() {
            if (Topo != null)
                return Topo.Item;
            else
                return null;
        }

        public int Quantidade() { return Qtde; }

        /// <summary>
        /// Torna possível iterar sobre a CPilha usando o comando foreach
        /// </summary>
        public IEnumerator GetEnumerator() {
            for (Celula aux = Topo; aux != null; aux = aux.Prox)
                yield return aux.Item;
        } 
    }
}