namespace Trabalho_Pratico_AED
{
    static public class OperationCounter
    {
        private static int quantOperacoes = 0;
        public static void Reset(){
            quantOperacoes = 0;
        }
        public static void Increment(){
            ++quantOperacoes;
        }
        public static void Increment(int numero){
            quantOperacoes+=numero;
        }

        public static int QuantOperacoes{
            get { return quantOperacoes; }
        }
    }
}