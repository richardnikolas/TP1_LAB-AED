using System;

namespace Trabalho_Pratico_AED.Fila {

    class Cell {
        public Cell Next;
        public object Value;

        public Cell() {
            Next = null;
            Value = null;
            OperationCounter.Increment(2);
        }

        public Cell(object newValue) {
            Next = null;
            Value = newValue;
            OperationCounter.Increment(2);
        }

        public Cell(Cell nextCell, object newValue) {
            Next = nextCell;
            Value = newValue;
            OperationCounter.Increment(2);
        }
    }
}
