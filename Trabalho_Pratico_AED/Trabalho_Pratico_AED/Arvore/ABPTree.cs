using System;

namespace Trabalho_Pratico_AED.Arvore {

    class ABPTree {
        /*
         * Arvore ABP feita de acordo com as recomendações de Fabio Leandro Rodrigues Cordeiro
         *
         * Autor: André Valentim
         */
        public Node root;
        public int quantity;

        public ABPTree() {
            root = null;
            quantity = 0;
        }

        public bool Insert(int value) {
            bool checkAdded = false;
            if(quantity <= 1000) {
                if(Search(value, root) == null) {
                    this.root = this.InsertInTree(value, this.root);
                    checkAdded = true;
                }
                OperationCounter.Increment();
            }
            else
                Console.WriteLine("A árvore está cheia!");
            
            OperationCounter.Increment();
            return checkAdded;
        }
        private Node InsertInTree(int value, Node node) {

            if(node == null) {
                node = new Node(value);
                quantity++;
                OperationCounter.Increment(); 
            } else if(value < node.item)
                node.setEsq(InsertInTree(value, node.getEsq()));

            else if(value > node.item)
                node.setDir(InsertInTree(value, node.getDir()));

            OperationCounter.Increment(4);
            return node;
        }
        private Node Search(int value, Node node) {
            if (node == null) {
                OperationCounter.Increment();
                return null; // Registro não encontrado ou já existente
            }

            else if (value < node.item){
                OperationCounter.Increment(2);
                return Search(value, node.getEsq());
            }                

            else if (value > node.item){
                OperationCounter.Increment(2);
                return Search(value, node.getDir());
            }

            else return node;
        }

        public void Remove(int value) {
            if (this.Search(value, root) == null) {
                OperationCounter.Increment();
                Console.WriteLine("\n\t Valor não encontrado!");
            }
            else {
                Withdraw(value, root);
                Console.WriteLine("\n\t Valor removido!");
                quantity--;
                OperationCounter.Increment(3);
            }
        }
        private Node Withdraw(int value, Node node) {
            if (node == null) {
                OperationCounter.Increment();
                Console.WriteLine("\n\tErro: Registro nao encontrado");
            } 
            else if (value < (int) node.getItem()){
                node.setEsq(Withdraw(value, node.getEsq()));
                OperationCounter.Increment(5);
            }
            else if (value > (int) node.getItem()){
                OperationCounter.Increment(5);
                node.setDir(Withdraw(value, node.getDir()));
            }
            else {
                if (node.getDir() == null){
                    OperationCounter.Increment();
                    node = node.getEsq();
                }
                else if (node.getEsq() == null){
                    OperationCounter.Increment();
                    node = node.getDir();
                }
                else {
                    OperationCounter.Increment();
                    node.setEsq(Predecessor(node, node.getEsq()));
                }
            }

            OperationCounter.Increment(3);
            return node;
        }

        private Node Predecessor(Node q, Node r) {
            if (r.getDir() != null){
                r.setDir(Predecessor(q, r.getDir()));
            }
            else {
                q.setItem(r.getItem());
                r = r.getEsq();
            }
            OperationCounter.Increment(3);
            return r;
        }

        public int GetQuantity() {
            return quantity;
        }
    }
}
