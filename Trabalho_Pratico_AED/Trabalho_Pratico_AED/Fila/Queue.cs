﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Trabalho_Pratico_AED.Fila {

    class Queue {
        private Cell firstCell;
        private Cell lastCell;
        private ushort quantity;

        public Queue() {
            firstCell = new Cell();
            lastCell = firstCell;
            quantity = 0;
            ContadorOperacoes.Increment(3);
        }

        public void Clear() {
            firstCell = new Cell();
            lastCell = firstCell;
            quantity = 0;
            ContadorOperacoes.Increment(3);
        }

        public int GetQuantity() {
            ContadorOperacoes.Increment();
            return quantity;
        }
        public void Enqueue(int value) {
            if (quantity <= 1000){
                ContadorOperacoes.Increment();
                InsertNewCell(value);
            }
            else
                Console.WriteLine("O tamanho máximo da fila foi atingido! [{0} elementos]", quantity);
        }

        private void InsertNewCell(int value) {
            Cell newCell = new Cell(value);
            lastCell.Next = newCell;
            lastCell = lastCell.Next;
            quantity++;
            ContadorOperacoes.Increment(4);
        }

        public void Dequeue() {
           RemoveFirstCell();
        }
        
        private void RemoveFirstCell() {
            if(firstCell != lastCell) {
                firstCell = firstCell.Next;
                quantity--;
                ContadorOperacoes.Increment(2);
            }
            ContadorOperacoes.Increment();
        }
    }
}