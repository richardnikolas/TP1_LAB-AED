namespace Trabalho_Pratico_AED.Fila {
    class Celula {
        private Celula next;
        private object value;
        public Celula() {
            next = null;
            value = null;
        }
        public Celula(object newValue) {
            next = null;
            value = newValue;
        }
        public Celula(Celula nextCell, object newValue) {
            next = nextCell;
            value = newValue;
        }
        public Celula getNext() { return next; }
        public void setNext(Celula nextCell) { next = nextCell; }
        public object getValue() { return value; }
        public void setValue(object newValue) { value = newValue; }
    }
}
