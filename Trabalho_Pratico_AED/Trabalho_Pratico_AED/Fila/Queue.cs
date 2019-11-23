using System;

namespace Trabalho_Pratico_AED.Fila {

    class Queue {
        private Cell firstCell;
        private Cell lastCell;
        private ushort quantity;

        public Queue() {
            firstCell = new Cell();
            lastCell = firstCell;
            quantity = 0;
            OperationCounter.Increment(3);
        }

        public void Clear() {
            firstCell = new Cell();
            lastCell = firstCell;
            quantity = 0;
            OperationCounter.Increment(3);
        }

        public int GetQuantity() {
            OperationCounter.Increment();
            return quantity;
        }
        public void Enqueue(int value) {
            if (quantity <= 1000){
                OperationCounter.Increment();
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
            OperationCounter.Increment(4);
        }

        public void Dequeue() {
           RemoveFirstCell();
        }
        
        private void RemoveFirstCell() {
            if(firstCell != lastCell) {
                firstCell = firstCell.Next;
                quantity--;
                OperationCounter.Increment(2);
            }
            OperationCounter.Increment();
        }
    }
}
