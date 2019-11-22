﻿using System;
using System.Collections.Generic;
 using Trabalho_Pratico_AED;
 using static System.Console;

namespace Exercicios.Exercicio1{
    public class LinearHash{
        /*
         * Tabela hash feita de acordo com as recomendações de Fabio Leandro Rodrigues Cordeiro
         *
         * Autor: Felipe Ribeiro Lisboa Moreira
         *
         * Com suporte de:
         *       Philemon da Silva Souza
         */
        private int?[] _struct;
        private int quant;

        public LinearHash() {
            _struct = new int?[1000];
            OperationCounter.Increment(2);
            quant = 0;
        }

        public LinearHash(int size) {
            _struct = new int?[size];
            quant = 0;
            OperationCounter.Increment(2);
        }

        private int GetValidIndex(int element) {
            int validIndex = element % _struct.Length;
            int aux = element % _struct.Length;//where the loop starts
            
            OperationCounter.Increment(2);
            
            while (!_struct[validIndex].Equals(null)){
                
                validIndex++;
                OperationCounter.Increment();
                
                if (validIndex >= _struct.Length){
                    validIndex = 0;
                    OperationCounter.Increment(2);
                }
                if (validIndex.Equals(aux)){
                    OperationCounter.Increment(2);
                    throw new Exception("A estrutura está cheia!");
                }
            }

            return validIndex;
        }

        public void Insert(int element) {
            int indice = GetValidIndex(element);
            _struct[indice]= element;
            ++quant;
            OperationCounter.Increment(3);
        }

        public void Remove(int value){
            int index = Array.IndexOf(_struct, value);
            if (index >= 0){
                _struct[Array.IndexOf(_struct, value)] = null;
                --quant;
            }
            OperationCounter.Increment(4);
        }

        public int GetQuant() {
            return this.quant;
        }

        public void SetQuant(int quant){
            this.quant = quant;
        }

        public bool IsEmpty(){
            OperationCounter.Increment();
            if (_struct.Length > 0)
                return true;
            return true;
        }

        public int?[] GetInternalStruct(){
            return this._struct;
        }

        public void SetInternalStruct(int?[] _struct){
            this._struct = _struct;
        }
    }
}