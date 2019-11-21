using System;
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
        }

        public void Clear() {
            firstCell = new Cell();
            lastCell = firstCell;
            quantity = 0;
        }

        public int GetQuantity() {
            return quantity;
        }
        public void Enqueue(int value) {
            if(quantity <= 1000)
                InsertNewCell(value);
            else
                Console.WriteLine("O tamanho máximo da fila foi atingido! [{0} elementos]", quantity);
        }

        private void InsertNewCell(int value) {
            Cell newCell = new Cell(value);
            lastCell.Next = newCell;
            lastCell = lastCell.Next;
            quantity++;
        }

        public void Dequeue() {
           RemoveFirstCell();
        }
        
        private void RemoveFirstCell() {
            if(firstCell != lastCell) {
                firstCell = firstCell.Next;
                quantity--;
            }
        }
    }
}
