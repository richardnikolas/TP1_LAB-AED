using System;
using System.Collections;
using static System.Console;

namespace Trabalho_Pratico_AED.Arvore {

    public class BinaryTree {
        public class Node {
            public int value;
            public Node left, right;
        }

        public Node root;

        public BinaryTree() {
            this.root = null;
        }

        public int SearchTree(int value) {
            return this.Search(value, this.root);
        }

        public void Insert(int value) {
            this.root = this.InsertInTree(value, this.root);
        }

        public void Withdraw(int value) {
            this.root = this.Withdraw(value, this.root);
        }

        public void Print(Node node) {
            this.Printall(node);
        }

        private int Search(int value, Node node) {
            if (node == null) return -1; // Registro não encontrado

            else if (value < node.value)
                return Search(value, node.left);

            else if (value > node.value)
                return Search(value, node.right);

            else return node.value;
        }
        private Node InsertInTree(int value, Node node) {
            if (node == null) {
                node = new Node();
                node.value = value;
                node.left = null;
                node.right = null;

                ForegroundColor = ConsoleColor.Green;
                WriteLine("\n\t Valor inserido!");
                ForegroundColor = ConsoleColor.White;
            }

            else if (value < node.value) node.left = InsertInTree(value, node.left);

            else if (value > node.value) node.right = InsertInTree(value, node.right);

            else {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\n\tErro: Registro ja existente");
                ForegroundColor = ConsoleColor.White;
            }

            return node;
        }

        private Node Predecessor(Node q, Node r) {
            if (r.right != null)
                r.right = Predecessor(q, r.right);

            else {
                q.value = r.value;
                r = r.left;
            }

            return r;
        }

        private Node Withdraw(int value, Node node) {
            if (node == null) {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\n\tErro: Registro nao encontrado");
                ForegroundColor = ConsoleColor.White;                
            }

            else if (value < node.value)
                node.left = Withdraw(value, node.left);

            else if (value > node.value)
                node.right = Withdraw(value, node.right);

            else {
                if (node.right == null)
                    node = node.left;

                else if (node.left == null)
                    node = node.right;

                else
                    node.left = Predecessor(node, node.left);
            }

            return node;
        }

        private void Printall(Node node) {
            if (node != null) {
                Write("{0} - ", node.value);
                Printall(node.left);
                Printall(node.right);
            }
        }
    }

    public class TabelaHashTree {
        
        public class Cell {
            public int key;
            public BinaryTree tree;

            public Cell (int key) {
                this.key = key;
                this.tree = new BinaryTree();
            }
        }

        public int M; // Table size
        public Cell[] table;

        public int HashKey (int key) {
            return key % this.M;
        }

        public TabelaHashTree(int size) {
            if (size <= 3)
                size = 3;

            this.M = size;
            this.table = new Cell[this.M];

            for (int i = 0; i < this.M; i++)
                this.table[i] = new Cell(i);
        }

        public TabelaHashTree() { }

        public object Search (int key) {
            if (this.table[key].tree.root == null)
                return null;
            else
                return this.table[key].tree.SearchTree(key);
        }

        public int Insert (int hashKey, int value, int counter) {

            if (value == -1)
                return -1;

            if (hashKey == this.M)
                hashKey = 0;

            if (counter == this.M)
                return -1;

            this.table[hashKey].tree.Insert(value);

            return 0;                        
        }

        public void Remove (int value) {
            int i = this.HashKey(value);

            if (this.Search(i) == null) { 
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\n\t Valor não encontrado!");
                ForegroundColor = ConsoleColor.White;
            }
            else {
                this.table[i].tree.Withdraw(value);
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("\n\t Valor removido!");
                ForegroundColor = ConsoleColor.White;        
            }
        }

        public void Imprime() {
            Write("\n---------------------------------------------");
            WriteLine("\n Valores armazenados na HashTable: \n ");

            for (int i = 0; i < this.M; i++) { 
                Write(" Valor da posição [" + i + "]: ");
                this.table[i].tree.Print(this.table[i].tree.root);
                Write("\n");
            }

            WriteLine("---------------------------------------------\n");
        }

        public void Testar(Queue numeros) {
            Clear();
            WriteLine("\n\t\t----------- HASH TABLE COM ARVORE BINÁRIA -----------\n\n");

            int size, valueToInsert = 0, choice = 99;
            bool keepExecuting = true;

            Write(" Escolha o tamanho da tabela Hash: ");
            size = int.Parse(ReadLine());

            TabelaHashTree hashTable = new TabelaHashTree(size);

            if(numeros != null) {
                while(numeros.Count > 0) {
                    valueToInsert = (int)numeros.Dequeue();
                    int key = hashTable.HashKey(valueToInsert);
                    hashTable.Insert(key, valueToInsert, 0);
                }
            }

            while(keepExecuting) {
                Clear();
                WriteLine("\n\t\t----------- HASH TABLE COM ARVORE BINÁRIA -----------\n\n");
                WriteLine(" Temos as seguintes opções para Hash Table (0 a 3):");

                WriteLine("\n 1 - Inserir novo número");
                WriteLine(" 2 - Remover número");
                WriteLine(" 3 - Imprimir toda tabela");
                WriteLine(" 0 - Sair do programa");

                Write("\n Insira o número da operação que deseja realizar: ");
                choice = int.Parse(ReadLine());

                switch(choice) {
                    case 1:
                        Write("\n Escolha um valor para inserir na tabela: ");
                        valueToInsert = int.Parse(ReadLine());

                        int key = hashTable.HashKey(valueToInsert);

                        hashTable.Insert(key, valueToInsert, 0);

                        Write("\n\n\n\n Aperte qualquer tecla para voltar ao Menu...");
                        ReadKey();
                        break;

                    case 2:
                        int valueToRemove;
                        Write("\n Escolha um valor para remover na tabela: ");
                        valueToRemove = int.Parse(ReadLine());

                        hashTable.Remove(valueToRemove);

                        Write("\n\n\n\n Aperte qualquer tecla para voltar ao Menu...");
                        ReadKey();
                        break;

                    case 3:
                        Clear();
                        hashTable.Imprime();

                        Write("\n\n\n\n Aperte qualquer tecla para voltar ao Menu...");
                        ReadKey();
                        break;

                    case 0:
                        keepExecuting = false;
                        break;
                    default:
                        keepExecuting = true;
                        break;
                }
            }
        }
    }
}
