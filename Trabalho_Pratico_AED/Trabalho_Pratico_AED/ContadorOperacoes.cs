namespace Trabalho_Pratico_AED
{
    static public class ContadorOperacoes
    {
        private static int quantOperacoes = 0;
        public static void Reset(){
            quantOperacoes = 0;
        }
        public static void Incrementa(){
            ++quantOperacoes;
        }
        public static void Incrementa(int numero){
            quantOperacoes+=numero;
        }

        public static int QuantOperacoes{
            get { return quantOperacoes; }
        }
    }
}