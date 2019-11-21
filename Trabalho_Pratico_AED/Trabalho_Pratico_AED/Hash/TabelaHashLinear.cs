﻿using System;
using System.Collections.Generic;

namespace Exercicios.Exercicio1{
    public class TabelaHashLinear{
        private List<int>[] estrutura;
        static private Random geradorNumeroAleatorio = new Random(DateTime.Now.Millisecond);

        public TabelaHashLinear(){
            estrutura = new List<int>[1000];
        }

        public TabelaHashLinear(int tamanho){
            estrutura = new List<int>[tamanho];
        }

        private int retornaIndiceValido(int elemento)
        {
            int indiceValido = elemento % estrutura.Length;
            while (estrutura[indiceValido].Count > 0 && indiceValido < estrutura.Length){
                indiceValido++;
            }
            return indiceValido;
        }

        public void inserir(int elemento){
            int indice = retornaIndiceValido(elemento);
            estrutura[indice].Add(elemento);
        }

        public void remover(int elemento){
            int indice = retornaIndiceValido(elemento);
            if (estrutura[indice].Contains(elemento)){
                estrutura[indice].Remove(elemento);
            } else Console.WriteLine("Elemento " + elemento + " não encontrado na tabela!");
        }

        public void imprimir(){
            int indice = 0;
            foreach (List<int> lista in estrutura){
                Console.Write(indice + "[");
                foreach (int elemento in lista){
                    Console.Write(elemento);
                }
                Console.WriteLine("]");
                ++indice;
            }
        }

        public int getQuant(){
            int count = 0;
            if (!estaVazia()){
                foreach (List<int> lista in estrutura){
                    if (lista.Count > 0){
                        foreach (int elemento in lista){
                            ++count;
                        }
                    }
                }
            }
            return count;
        }

        public bool estaVazia(){
            foreach (List<int> lista in estrutura){
                if (lista.Count > 0)
                    return false;
            }
            return true;
        }
    }
}