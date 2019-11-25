﻿using System;
using System.Collections;
using Trabalho_Pratico_AED;
using static System.Console;

namespace Exercicios.Exercicio1 {

    public class TabelaHash {
        public class Cell {
            public int key;
            public object value;

            public Cell(int key) {
                this.key = key;
                this.value = null;
            }
        }

        public int M; // Table size
        public Cell[] table;

        public int HashKey(int key) {
            return key % this.M;
        }
    }

    public class TabelaHashLinear : TabelaHash {

        public TabelaHashLinear(int size) {
            if (size <= 3)
                size = 3;

            this.M = size;
            this.table = new Cell[this.M];

            for (int i = 0; i < this.M; i++)
                this.table[i] = new Cell(i);
        }

        public TabelaHashLinear() { }

        public object Search (int key) {
            if (this.table[key].value == null)
                return null;
            else
                return this.table[key].value;
        }

        public int Insert (int hashKey, int value, int counter) {

            if (value == -1)
                return -1;

            if (hashKey == this.M)
                hashKey = 0;

            if (counter == this.M)
                return -1;

            if (this.Search(hashKey) == null) { 
                this.table[hashKey].value = value;
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\n\t Valor inserido!");
                ForegroundColor = ConsoleColor.White;
                return 0;
            }

            else 
                return this.Insert(hashKey + 1, value, counter + 1);                           
        }

        public void Remove (int value) {
            int i = this.HashKey(value);

            if (this.Search(value) == null) { 
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\n\t Valor não encontrado!");
                ForegroundColor = ConsoleColor.White;
            }
            else {
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("\n\t Valor removido!");
                ForegroundColor = ConsoleColor.White;
                this.table[i] = new Cell(i);            
            }
        }

        public void Imprime() {
            Write("\n---------------------------------------------");
            WriteLine("\n Valores armazenados na HashTable:\n ");

            for (int i = 0; i < this.M; i++)
                WriteLine(" Valor da posição [" + i + "]:" + this.table[i].value);

            WriteLine("---------------------------------------------\n");
        }

        public void Testar(Queue numbers) {
            Clear();
            WriteLine("\n\t\t----------- HASH TABLE LINEAR -----------\n\n");

            int size, valueToInsert = 0, choice = 99;
            bool keepExecuting = true;

            Write(" Escolha o tamanho da tabela Hash: ");
            size = int.Parse(ReadLine());

            TabelaHashLinear hashTable = new TabelaHashLinear(size);

            if (numbers != null) {
                while(numbers.Count > 0) {
                    valueToInsert = (int)numbers.Dequeue();
                    int key = hashTable.HashKey(valueToInsert);
                    hashTable.Insert(key, valueToInsert, 0);
                }
            }

            while(keepExecuting) {
                Clear();
                WriteLine("\n\t\t----------- HASH TABLE LINEAR -----------\n\n");
                WriteLine(" Temos as seguintes opções para Hash Table (0 a 3):");
                WriteLine("\n 1 - Inserir novo número");
                WriteLine(" 2 - Remover número");
                WriteLine(" 3 - Imprimir toda tabela");
                WriteLine(" 0 - Sair do programa");

                Write("\n Insira o número da operação que deseja realizar: ");
                choice = int.Parse(ReadLine());

                switch(choice) {
                    case 1:
                        Write("\n Escolha um valor para inserir na tabela: ");
                        valueToInsert = int.Parse(ReadLine());

                        int key = hashTable.HashKey(valueToInsert);

                        hashTable.Insert(key, valueToInsert, 0);

                        WriteLine("\n\n\n\n Aperte qualquer tecla para voltar ao Menu...");
                        ReadKey();
                        break;

                    case 2:
                        int valueToRemove;
                        Write("\n Escolha um valor para remover da na tabela: ");
                        valueToRemove = int.Parse(ReadLine());

                        hashTable.Remove(valueToRemove);

                        WriteLine("\n\n\n\n Aperte qualquer tecla para voltar ao Menu...");
                        ReadKey();
                        break;

                    case 3:
                        Clear();
                        hashTable.Imprime();

                        WriteLine("\n\n\n\n Aperte qualquer tecla para voltar ao Menu...");
                        ReadKey();
                        break;

                    case 0:
                        keepExecuting = false;
                        break;
                    default:
                        keepExecuting = true;
                        break;
                }
            }
        }
    }

    public class LinearHash {
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