﻿namespace Exercicios.Exercicio3
{
    public class Nodulo
    {
        /*
         * Classe que caracteriza uma unidade de uma estrutura de árvoreAVL.
         *
         * Feita por Philemon da Silva Souza
         */
        private Nodulo esq;
        private Nodulo dir;
        public object item;

        public Nodulo(){
            this.esq = null;
            this.dir = null;
            this.item = null;
        }
        public Nodulo(object item){
            this.esq = null;
            this.dir = null;
            this.item = item;
        }
        public void setEsq(Nodulo esq){
            this.esq = esq;
        }
        public Nodulo getEsq(){
            return this.esq;
        }
        public void setDir(Nodulo dir){
            this.dir = dir;
        }
        public Nodulo getDir(){
            return this.dir;
        }
        public void setItem(object item){
            this.item = item;
        }
        public object getItem(){
            return this.item;
        }
    }
}