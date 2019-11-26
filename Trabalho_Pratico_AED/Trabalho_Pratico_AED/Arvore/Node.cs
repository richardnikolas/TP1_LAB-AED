﻿namespace Trabalho_Pratico_AED.Arvore {

    public class Node {

        /*
         * Classe que caracteriza uma unidade de uma estrutura de Arvore Binária.
         *
         * Feita por Philemon da Silva Souza
         */

        private Node esq;
        private Node dir;
        public int item;

        public Node() {
            this.esq = null;
            this.dir = null;
            OperationCounter.Increment(2);
        }

        public Node(int value){
            esq = null;
            dir = null;
            item = value;
            OperationCounter.Increment(3);
        }

        public void setEsq(Node esq) {
            this.esq = esq;
            OperationCounter.Increment();
        }

        public Node getEsq() {
            return this.esq;
        }

        public void setDir(Node dir) {
            this.dir = dir;
            OperationCounter.Increment();
        }

        public Node getDir() {
            return this.dir;
        }

        public void setItem(object item) {
            this.item = (int)item;
            OperationCounter.Increment();
        }

        public object getItem() {
            return this.item;
        }
    }
}