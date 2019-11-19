﻿using System;
 using System.Collections;

 namespace VS_Code 
{
    public class ListaSimples : IEnumerable{
        private Celula primeira, ultima;
        private int quant;

        public ListaSimples(){
            this.primeira = null;
            this.ultima = null;
        }

        public bool vazia(){
            return primeira == null;
        }
        public void insereComeco(Object valorItem){
            Celula novaCelula = new Celula(valorItem, primeira);
            primeira = novaCelula;
            ++quant;
        }
        public Object removeComeco(){
            Object output = null;
            if (this.primeira != null){
                output = primeira.Item;
                primeira = primeira.Prox;
                --quant;
            }
            return output;
        }
        public void insereFim(Object valorItem){
            Celula novaCelula = new Celula(valorItem);
            if(primeira == null){
                primeira = novaCelula;
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
            if (this.primeira != null){
                Celula aux = primeira;
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
            for (Celula aux = primeira; aux != null; aux = aux.Prox)
                yield return aux.Item;
        } 
    }
}
