﻿using System;
using System.Collections.Generic;
 using Trabalho_Pratico_AED;
 using static System.Console;

namespace Exercicios.Exercicio1{
    public class TabelaHashLinear{
        private List<int>[] estrutura;

        public TabelaHashLinear() {
            estrutura = new List<int>[1000];
            ContadorOperacoes.Incrementa();
        }

        public TabelaHashLinear(int tamanho) {
            estrutura = new List<int>[tamanho];
            ContadorOperacoes.Incrementa();
        }

        private int retornaIndiceValido(int elemento) {
            int indiceValido = elemento % estrutura.Length;
            ContadorOperacoes.Incrementa();
            while (estrutura[indiceValido].Count > 0 && indiceValido < estrutura.Length){
                ContadorOperacoes.Incrementa();
                indiceValido++;
            }

            return indiceValido;
        }

        public void inserir(int elemento) {
            int indice = retornaIndiceValido(elemento);
            estrutura[indice].Add(elemento);
            ContadorOperacoes.Incrementa(2);
        }

        public void remover(int elemento) {
            int indice = retornaIndiceValido(elemento);

            if (estrutura[indice].Contains(elemento)){
                ContadorOperacoes.Incrementa();
                estrutura[indice].Remove(elemento);
            }
            else
                WriteLine("Elemento " + elemento + " não encontrado na tabela!");
            ContadorOperacoes.Incrementa(2);
        }

        public void imprimir() {
            int indice = 0;

            foreach (List<int> lista in estrutura) {
                Write(indice + "[");

                foreach (int elemento in lista)
                    Write(elemento);
                
                WriteLine("]");
                ++indice;
            }
        }

        public int getQuant() {
            int count = 0;
            if (!estaVazia()){
                foreach (List<int> lista in estrutura) {
                    if (lista.Count > 0) {
                        foreach (int elemento in lista) {
                            ContadorOperacoes.Incrementa();
                            ++count;
                        }
                    }
                }
            }
            return count;
        }

        public bool estaVazia() {
            foreach (List<int> lista in estrutura) {
                ContadorOperacoes.Incrementa();
                if (lista.Count > 0)
                    return false;
            }
            return true;
        }

        public List<int>[] getEstrutura(){
            return this.estrutura;
        }
    }
}