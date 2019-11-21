using System;

namespace Trabalho_Pratico_AED.Fila {

    class Cell {
        public Cell Next;
        public object Value;

        public Cell() {
            Next = null;
            Value = null;
        }

        public Cell(object newValue) {
            Next = null;
            Value = newValue;
        }

        public Cell(Cell nextCell, object newValue) {
            Next = nextCell;
            Value = newValue;
        }
    }
}
