﻿using System;
using System.Collections.Generic;
 using Trabalho_Pratico_AED;
 using static System.Console;

namespace Exercicios.Exercicio1{
    public class TabelaHashLinear{
        /*
         * Tabela hash feita de acordo com as recomendações de Fabio Leandro Rodrigues Cordeiro
         *
         * Autor: Felipe Ribeiro Lisboa Moreira
         *
         * Com suporte de:
         *       Philemon da Silva Souza
         */
        private List<int>[] _struct;

        public TabelaHashLinear() {
            _struct = new List<int>[1000];
            for (int i = 0; i < _struct.Length; i++){
                _struct[i] = new List<int>();
            }
            ContadorOperacoes.Increment();
        }

        public TabelaHashLinear(int size) {
            _struct = new List<int>[size];
            ContadorOperacoes.Increment();
        }

        private int GetValidIndex(int element) {
            int indiceValido = element % _struct.Length;
            ContadorOperacoes.Increment();
            while (_struct[indiceValido].Count > 0 && indiceValido < _struct.Length){
                ContadorOperacoes.Increment();
                indiceValido++;
            }

            return indiceValido;
        }

        public void Inserir(int element) {
            int indice = GetValidIndex(element);
            _struct[indice].Add(element);
            ContadorOperacoes.Increment(2);
        }

        public void Remover(int element) {
            int indice = GetValidIndex(element);

            if (_struct[indice].Contains(element)){
                ContadorOperacoes.Increment();
                _struct[indice].Remove(element);
            }
            else
                WriteLine("Elemento " + element + " não encontrado na tabela!");
            ContadorOperacoes.Increment(2);
        }

        public void Imprimir() {
            int index = 0;

            foreach (List<int> list in _struct) {
                Write(index + "[");

                foreach (int element in list)
                    Write(element);
                
                WriteLine("]");
                ++index;
            }
        }

        public int GetQuant() {
            int count = 0;
            if (!IsEmpty()){
                foreach (List<int> list in _struct) {
                    if (list.Count > 0) {
                        foreach (int elemento in list) {
                            ContadorOperacoes.Increment();
                            ++count;
                        }
                    }
                }
            }
            return count;
        }

        public bool IsEmpty() {
            foreach (List<int> lista in _struct) {
                ContadorOperacoes.Increment();
                if (lista.Count > 0)
                    return false;
            }
            return true;
        }

        public List<int>[] GetInternalStruct(){
            return this._struct;
        }
    }
}