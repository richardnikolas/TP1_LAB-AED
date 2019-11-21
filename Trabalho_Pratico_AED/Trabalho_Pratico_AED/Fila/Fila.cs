using System;
using System.Collections;
using System.Collections.Generic;

namespace Trabalho_Pratico_AED.Fila {
    class Fila {
        private List<int> valoresParaOutput;
        private Celula firstCell;
        private Celula lastCell;
        private ushort quantity;

        public Fila() {
            firstCell = new Celula();
            lastCell = firstCell;
            quantity = 0;
        }
        public void clear() {
            firstCell = new Celula();
            lastCell = firstCell;
            quantity = 0;
        }
        public List<int> getAllElements() {
            valoresParaOutput = loadAllElements();
            return valoresParaOutput;
        }
        private List<int> loadAllElements() {
            List<int> elements = new List<int>(quantity);
            Celula coursing = firstCell;
            while(coursing.getNext() != null) {
                elements.Add((int)coursing.getValue());
            }
            return elements;
        }
        public void enqueue(int value) {
            if(quantity <= 1000)
                insertNewCell(value);
            else
                Console.WriteLine("O tamanho máximo da fila foi atingido! [{0} elementos]", quantity);
        }
        private void insertNewCell(int value) {
            Celula newCell = new Celula(value);
            lastCell.setNext(newCell);
            lastCell = lastCell.getNext();
            quantity++;
        }
        public void dequeue() {
           removeFirstCell();
        }
        private void removeFirstCell() {
            if(firstCell != lastCell) {
                firstCell = firstCell.getNext();
                quantity--;
            }
        }

    }
}
