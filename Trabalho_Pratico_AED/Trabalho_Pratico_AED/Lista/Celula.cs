using System;
using Trabalho_Pratico_AED;

namespace VS_Code {
    
    #region Classe Celula - representa a célula utilizada pelas classes CLista, Fila e CPilha
    /// <summary>
    /// Classe utilizada pelas classes Lista, Fila e Pilha
    /// </summary>
    class Celula {
        public Object Item; // O Item armazendo pela célula
        public Celula Prox; // Referencia a próxima célula

        /// <summary>
        /// Inicializa uma nova instância da classe Celula atribuindo null aos atributos Item e Prox.
        /// </summary>
        public Celula() {
            Item = null;
            Prox = null;
            OperationCounter.Increment(2);
        }

        /// <summary>
        /// Inicializa uma nova instância da classe Celula atribuindo o valor passado por parâmetro ao atributo Item e null ao atributo Prox.
        /// </summary>
        /// <param name="ValorItem">Valor a ser armazenado pela célula.</param>
        public Celula(object ValorItem) {
            Item = ValorItem;
            Prox = null;
            OperationCounter.Increment(2);
        }

        /// <summary>
        /// Inicializa uma nova instância da classe Celula atribuindo ValorItem ao atributo Item e ProxCelula ao atributo Prox.
        /// </summary>
        /// <param name="ValorItem">Valor a ser armazenado pela célula</param>
        /// <param name="ProxCelula">Referência para a próxima célula.</param>
        public Celula(object ValorItem, Celula ProxCelula) {
            Item = ValorItem;
            Prox = ProxCelula;
            OperationCounter.Increment(2);
        }
    }
    #endregion
}