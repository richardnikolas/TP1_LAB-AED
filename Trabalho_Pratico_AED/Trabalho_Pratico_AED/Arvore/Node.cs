using System;

﻿namespace Trabalho_Pratico_AED.Arvore {

    public class Node {

        /*
         * Classe que caracteriza uma unidade de uma estrutura de árvoreAVL.
         *
         * Feita por Philemon da Silva Souza
         */

        private Node esq;
        private Node dir;
        public int balanceFactor;
        public int height;
        public int depth;
        public int item;

        public Node() {
            this.esq = null;
            this.dir = null;
            this.item = 0;
            this.balanceFactor = 0;
            this.height = 1;
            this.depth = 0;
            ContadorOperacoes.Incrementa(6);
        }
        public Node(int value){
            esq = null;
            dir = null;
            item = value;
            balanceFactor = 0;
            height = 1;
            depth = 0;
            ContadorOperacoes.Incrementa(6);
        }

        public void setEsq(Node esq) {
            this.esq = esq;
            ContadorOperacoes.Incrementa();
        }

        public Node getEsq() {
            return this.esq;
        }

        public void setDir(Node dir) {
            this.dir = dir;
            ContadorOperacoes.Incrementa();
        }

        public Node getDir() {
            return this.dir;
        }

        public void setItem(object item) {
            this.item = (int)item;
            ContadorOperacoes.Incrementa();
        }

        public object getItem() {
            return this.item;
        }
    }
}