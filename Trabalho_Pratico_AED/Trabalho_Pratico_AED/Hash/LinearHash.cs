﻿using System;
using System.Collections;
using Trabalho_Pratico_AED;
using static System.Console;

namespace Exercicios.Exercicio1 {

    public class TabelaHash {

        public int tableSize; // Table size
        public HashCell[] table;

        public int HashKey(int key) {
            OperationCounter.Increment();
            return key % this.tableSize;
        }
    }

    public class TabelaHashLinear : TabelaHash {
        public TabelaHashLinear(){
            for (int i = 0; i < this.tableSize; i++){
                OperationCounter.Increment();
                this.table[i] = new HashCell(i);
            }
        }

        public TabelaHashLinear(int size) {
            
            if (size <= 3)
                size = 3;

            this.tableSize = size;
            this.table = new HashCell[this.tableSize];
            OperationCounter.Increment(3);

            for (int i = 0; i < this.tableSize; i++){
                OperationCounter.Increment();
                this.table[i] = new HashCell(i);
            }
        }

        public object Search (int key) {
            OperationCounter.Increment();
            if (this.table[key].value == null)
                return null;
            else{
                OperationCounter.Increment();
                return this.table[key].value;
            }
        }

        public int Insert (int hashKey, int value, int counter) {

            OperationCounter.Increment();
            if (value == -1)
                return -1;
            
            OperationCounter.Increment();
            if (hashKey == this.tableSize)
                hashKey = 0;

            OperationCounter.Increment();
            if (counter == this.tableSize)
                return -1;

            OperationCounter.Increment();
            if (this.Search(hashKey) == null) { 
                this.table[hashKey].value = value;
                OperationCounter.Increment();
                return 0;
            }
            else{
                OperationCounter.Increment();
                return this.Insert(hashKey + 1, value, counter + 1);
            }
        }

        public void Remove (int value) {
            int i = this.HashKey(value);

            if (this.Search(value) == null) { 
                throw new Exception("Não foi possível encontrar o valor especificado");
            }
            else {
                this.table[i] = new HashCell(i);            
            }
            OperationCounter.Increment(3);
        }

        public int GetQuant(){
            int quant = 0;
            for (int i = 0; i < table.Length; i++){
                OperationCounter.Increment();
                quant += table[i].value != null ? 1 : 0;
            }
            return quant;
        }

        public HashCell[] GetInternalStruct(){
            return this.table;
        }

        public void SetInternalStruct(HashCell[] _struct){
            this.table = _struct;
        }
    }
}