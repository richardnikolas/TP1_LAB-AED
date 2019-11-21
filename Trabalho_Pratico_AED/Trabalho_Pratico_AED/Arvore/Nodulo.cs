using System;

﻿namespace Exercicios.Exercicio3 {

    public class Nodulo {

        /*
         * Classe que caracteriza uma unidade de uma estrutura de árvoreAVL.
         *
         * Feita por Philemon da Silva Souza
         */

        private Nodulo esq;
        private Nodulo dir;
        public int balanceFactor;
        public int height;
        public int depth;
        public object item;

        public Nodulo() {
            this.esq = null;
            this.dir = null;
            this.item = null;
            this.balanceFactor = 0;
            this.height = 1;
            this.depth = 0;
        }
        public Nodulo(object value){
            esq = null;
            dir = null;
            item = value;
            balanceFactor = 0;
            height = 1;
            depth = 0;
        }

        public void setEsq(Nodulo esq) {
            this.esq = esq;
        }

        public Nodulo getEsq() {
            return this.esq;
        }

        public void setDir(Nodulo dir) {
            this.dir = dir;
        }

        public Nodulo getDir() {
            return this.dir;
        }

        public void setItem(object item) {
            this.item = item;
        }

        public object getItem() {
            return this.item;
        }
    }
}