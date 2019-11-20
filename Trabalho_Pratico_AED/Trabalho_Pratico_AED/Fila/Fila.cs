using System;
using System.Collections;

namespace Trabalho_Pratico_AED.Fila {
    class Fila {
        private Celula firstCell;
        private Celula lastCell;
        private ushort quantity;

        public Fila() {
            firstCell = null;
            lastCell = firstCell;
            quantity = 0;
        }

        public void clear() {
            firstCell = null;
            lastCell = firstCell;
            quantity = 0;
        }
        public ArrayList getAllElements() {
            ArrayList elements = new ArrayList(quantity);
            Celula coursing = firstCell;
            while(coursing.getNext() != null) {
                elements.Add(coursing.getValue());
            }
            return elements;
        }

        public void insertNewCell(Celula newCell) {
            if(quantity <= 1000)
                enqueue(newCell);
            else
                Console.WriteLine("O tamanho máximo da fila foi atingido! [{0} elementos]", quantity);
        }
        private void enqueue(Celula newCell) {
            lastCell.setNext(newCell);
            lastCell = lastCell.getNext();
            quantity++;
        }

        public object removeFirstCell() {
            return dequeue();
        }
        private object dequeue() {
            Celula firstOfQueue = null;
            if(firstCell != lastCell) {
                firstCell = firstCell.getNext();
                firstOfQueue.setValue(firstCell.getValue());
                quantity--;
            }
            return firstOfQueue.getValue();
        }

    }
}
