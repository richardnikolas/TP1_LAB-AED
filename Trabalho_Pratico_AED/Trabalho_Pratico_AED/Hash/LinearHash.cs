﻿using System;
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
            quant = 0;
            OperationCounter.Increment(2);
        }

        public LinearHash(int size) {
            _struct = new int?[size];
            quant = 0;
            OperationCounter.Increment(2);
        }

        private int GetValidIndex(int element) {
            int validIndex = element % _struct.Length;
            int aux = element % _struct.Length; // where the loop starts

            if (validIndex < 0)
                validIndex = validIndex * -1;
            
            OperationCounter.Increment(2);
            
            while (!_struct[validIndex].Equals(null)) {
                
                validIndex++;
                OperationCounter.Increment();
                
                if (validIndex >= _struct.Length) {
                    validIndex = 0;
                    OperationCounter.Increment(2);
                }

                if (validIndex.Equals(aux)) {
                    OperationCounter.Increment(2);
                    throw new Exception("A estrutura está cheia!");
                }
            }
            return validIndex;
        }

        public int Insert(int element) {
            int indice = GetValidIndex(element);
            _struct[indice] = element;
            quant++;
            OperationCounter.Increment(3);
            return indice;
        }

        public void Remove(int value) {
            if (this.quant > 0) {
                int index = Array.IndexOf(_struct, value);
                
                if (index >= 0) {    
                    _struct[Array.IndexOf(_struct, value)] = null;
                    --quant;
                }

                OperationCounter.Increment(4);
            }
            else 
                throw new Exception("Não é possível remover elementos de uma lista vazia!");            
        }

        public int GetQuant() {
            return this.quant;
        }

        public void SetQuant(int quant) {
            this.quant = quant;
        }

        public bool IsEmpty() {
            OperationCounter.Increment();

            if (_struct.Length > 0)
                return false;

            return true;
        }

        public int?[] GetInternalStruct() {
            return this._struct;
        }

        public void SetInternalStruct(int?[] _struct) {
            this._struct = _struct;
        }
    }
}