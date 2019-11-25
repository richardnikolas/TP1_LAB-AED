using Trabalho_Pratico_AED;

namespace Exercicios.Exercicio1
{
    public class HashCell {
        public int key;
        public object value;
        
        public HashCell(){}

        public HashCell(int key) {
            this.key = key;
            this.value = null;
            OperationCounter.Increment(2);
        }
    }
}