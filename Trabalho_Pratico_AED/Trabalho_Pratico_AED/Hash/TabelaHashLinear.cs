﻿using System;
using System.Collections.Generic;

namespace Exercicios.Exercicio1{
    public class TabelaHashLinear{
        private List<int>[] estrutura;
        static private Random geradorNumeroAleatorio = new Random(DateTime.Now.Millisecond);

        public TabelaHashLinear(){
            estrutura = new List<int>[50];
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

        public static void testarTudo(){
            TabelaHashLinear hashLinear = new TabelaHashLinear();
            Console.WriteLine("Teste iniciado...");
            int numeroInserido = geradorNumeroAleatorio.Next(0, 100);
            testarInsercao(hashLinear, numeroInserido);
            testarRemocao(hashLinear,numeroInserido);
            testarInsercao(hashLinear, (numeroInserido*10));
            testarRemocao(hashLinear, numeroInserido);
            Console.WriteLine("Teste encerrado");
        }

        private static void testarInsercao(TabelaHashLinear hashLinear, int numeroInserido){
            Console.WriteLine("Inserindo número " + numeroInserido+"...");
            hashLinear.inserir(numeroInserido);
            hashLinear.imprimir();
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        private static void testarRemocao(TabelaHashLinear hashLinear, int numeroInserido){
            Console.WriteLine("Removendo número " + numeroInserido+"...");
            hashLinear.remover(numeroInserido);
            hashLinear.imprimir();
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}