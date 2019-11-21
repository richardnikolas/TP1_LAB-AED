using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico_AED.Arvore {
    class ArvoreABP {
        public Node root;
        public int quantity;
        public ArvoreABP() {
            root = null;
        }
        public void Insert(int value) {
            if(quantity <= 1000) {
                this.root = this.InsertInTree(value, this.root);
                if(this.root != null) {
                    SetNodesHeight(this.root);
                    SetNodesDepth(this.root, 1);
                    SetNodesBalanceFactor(this.root);
                    quantity++;
                }
            } else {
                Console.WriteLine("A árvore está cheia!");
            }
        }
        private Node InsertInTree(int value, Node node) {

            if(node == null) {
                node = new Node(value);
            } else if(value < node.item) node.setEsq(InsertInTree(value, node.getEsq()));

            else if(value > node.item) node.setDir(InsertInTree(value, node.getDir()));

            return node;
        }
        private Node Search(int value, Node node) {
            if(node == null) return null; // Registro não encontrado

            else if(value < node.item)
                return Search(value, node.getEsq());

            else if(value > node.item)
                return Search(value, node.getDir());

            else return node;
        }
        private int SetNodesHeight(Node currentNode) {
            if(currentNode == null) {
                return 0;
            } else {
                int leftHeight = SetNodesHeight(currentNode.getEsq());
                int rightHeight = SetNodesHeight(currentNode.getDir());
                currentNode.height = 1 + Math.Max(leftHeight, rightHeight);
                return currentNode.height;
            }
        }
        private void SetNodesDepth(Node currentNode, int depthParam) {
            if(currentNode == null) {
                return;
            } else {
                currentNode.depth = depthParam;
                SetNodesDepth(currentNode.getEsq(), depthParam + 1);
                SetNodesDepth(currentNode.getDir(), depthParam + 1);
            }
        }

        private void SetNodesBalanceFactor(Node currentNode) {
            if(currentNode == null) {
                return;
            } else {
                setBalanceFactor(currentNode);
                if(currentNode.getEsq() != null)
                    SetNodesBalanceFactor(currentNode.getEsq());
                if(currentNode.getDir() != null)
                    SetNodesBalanceFactor(currentNode.getDir());
                return;
            }
        }
        private void setBalanceFactor(Node currentNode) {
            int subTreeLeftHeight = 0;
            int subTreeRightHeight = 0;
            if(currentNode.getEsq() != null) {
                subTreeLeftHeight = currentNode.getEsq().height;
            }
            if(currentNode.getDir() != null) {
                subTreeRightHeight = currentNode.getDir().height;
            }
            currentNode.balanceFactor = subTreeLeftHeight - subTreeRightHeight;
        }

        public void Remove(int value) {
            if(this.Search(value, root) == null) {
                Console.WriteLine("\n\t Valor não encontrado!");
            } else {
                Withdraw(value, root);
                Console.WriteLine("\n\t Valor removido!");
                quantity--;
            }
        }
        private Node Withdraw(int value, Node node) {
            if(node == null) {
                Console.WriteLine("\n\tErro: Registro nao encontrado");
            } else if(value < (int)node.getItem())
                node.setEsq(Withdraw(value, node.getEsq()));

            else if(value > (int)node.getItem())
                node.setDir(Withdraw(value, node.getDir()));

            else {
                if(node.getDir() == null)
                    node = node.getEsq();

                else if(node.getEsq() == null)
                    node = node.getDir();

                else
                    node.setEsq(Predecessor(node, node.getEsq()));
            }
            return node;
        }

        private Node Predecessor(Node q, Node r) {
            if(r.getDir() != null)
                r.setDir(Predecessor(q, r.getDir()));

            else {
                q.setItem(r.getItem());
                r = r.getEsq();
            }

            return r;
        }
        public int GetQuantity() {
            return quantity;
        }
    }
}
