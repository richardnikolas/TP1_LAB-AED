namespace Trabalho_Pratico_AED
{
    public class EnumEstrutura
    {
        //Classe para simular um Enumerator de string
        public string valor { get; set; }

        public EnumEstrutura(string valor){ this.valor = valor; }
        public static EnumEstrutura PILHA { get {return new EnumEstrutura("Pilha");}}
        public static EnumEstrutura FILA { get {return new EnumEstrutura("Fila");}}
        public static EnumEstrutura LISTA { get {return new EnumEstrutura("Lista");}}
        public static EnumEstrutura ARVORE { get {return new EnumEstrutura("Árvore AVL");}}
        public static EnumEstrutura HASH { get {return new EnumEstrutura("Tabela Hash");}}
    }
}