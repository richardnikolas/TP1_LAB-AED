﻿using System;
 using System.Collections;

 namespace VS_Code 
{
    public class ListaSimples : IEnumerable{
        private Celula cabeca, ultima;
        private int quant;

        public ListaSimples(){
            this.cabeca = null;
            this.ultima = null;
        }

        public bool vazia(){
            return cabeca == null;
        }
        public void insereComeco(Object valorItem){
            Celula novaCelula = new Celula(valorItem, cabeca);
            cabeca = novaCelula;
            ++quant;
        }
        public Object removeComeco(){
            Object output = null;
            if (this.cabeca != null){
                output = cabeca.Item;
                cabeca = cabeca.Prox;
                --quant;
            }
            return output;
        }
        public void insereFim(Object valorItem){
            Celula novaCelula = new Celula(valorItem);
            if(cabeca == null){
                cabeca = novaCelula;
                ultima = novaCelula;
            }
            else{
                ultima.Prox = novaCelula;
                ultima = ultima.Prox;
            }
            ++quant;
        }
        public Object removeFim(){
            Object output = null;
            if (this.cabeca != null){
                Celula aux = cabeca;
                while (aux.Prox.Prox != null){
                    aux = aux.Prox;
                }
                output = aux.Prox;
                aux.Prox = null;
                --quant;
            }
            return output;
        }
        public void imprime(){
            foreach (Celula celula in this){
                Console.WriteLine(celula.Item.ToString());
            }
        }
        public bool contem(Object elemento){
            bool contem = false;
            foreach (Celula celula in this){
                if (celula.Item.Equals(elemento))
                    contem = true;
            }
            return contem;
        }
        // Torna possível iterar sobre a Estrutura usando o comando foreach
        public IEnumerator GetEnumerator()
        {
            for (Celula aux = cabeca; aux != null; aux = aux.Prox)
                yield return aux.Item;
        } 
    }
}
