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
                ContadorOperacoes.Incrementa();
                if(this.root != null) {
                    SetNodesHeight(this.root);
                    SetNodesDepth(this.root, 1);
                    SetNodesBalanceFactor(this.root);
                    quantity++;
                    ContadorOperacoes.Incrementa(4);
                }
            } else {
                Console.WriteLine("A árvore está cheia!");
            }
            ContadorOperacoes.Incrementa();
        }
        private Node InsertInTree(int value, Node node) {

            if(node == null) {
                node = new Node(value);
            } else if(value < node.item) node.setEsq(InsertInTree(value, node.getEsq()));

            else if(value > node.item) node.setDir(InsertInTree(value, node.getDir()));

            ContadorOperacoes.Incrementa(4);
            return node;
        }
        private Node Search(int value, Node node) {
            if(node == null){
                ContadorOperacoes.Incrementa();
                return null; // Registro não encontrado
            }

            else if (value < node.item){
                ContadorOperacoes.Incrementa(2);
                return Search(value, node.getEsq());
            }
                

            else if (value > node.item){
                ContadorOperacoes.Incrementa(2);
                return Search(value, node.getDir());
            }

            else return node;
        }
        private int SetNodesHeight(Node currentNode) {
            if(currentNode == null) {
                ContadorOperacoes.Incrementa();
                return 0;
            } else {
                int leftHeight = SetNodesHeight(currentNode.getEsq());
                int rightHeight = SetNodesHeight(currentNode.getDir());
                currentNode.height = 1 + Math.Max(leftHeight, rightHeight);
                ContadorOperacoes.Incrementa(3);
                return currentNode.height;
            }
        }
        private void SetNodesDepth(Node currentNode, int depthParam) {
            if(currentNode == null) {
                ContadorOperacoes.Incrementa();
            } else {
                currentNode.depth = depthParam;
                SetNodesDepth(currentNode.getEsq(), depthParam + 1);
                SetNodesDepth(currentNode.getDir(), depthParam + 1);
                ContadorOperacoes.Incrementa(3);
            }
        }

        private void SetNodesBalanceFactor(Node currentNode) {
            if(currentNode == null) {
                ContadorOperacoes.Incrementa();
            } else {
                setBalanceFactor(currentNode);
                ContadorOperacoes.Incrementa();
                if (currentNode.getEsq() != null){
                    ContadorOperacoes.Incrementa();
                    SetNodesBalanceFactor(currentNode.getEsq());
                }
                if (currentNode.getDir() != null){
                    ContadorOperacoes.Incrementa();
                    SetNodesBalanceFactor(currentNode.getDir());
                }
            }
        }
        private void setBalanceFactor(Node currentNode) {
            int subTreeLeftHeight = 0;
            int subTreeRightHeight = 0;
            ContadorOperacoes.Incrementa(2);
            if(currentNode.getEsq() != null) {
                subTreeLeftHeight = currentNode.getEsq().height;
                ContadorOperacoes.Incrementa(2);
            }
            if(currentNode.getDir() != null) {
                subTreeRightHeight = currentNode.getDir().height;
                ContadorOperacoes.Incrementa(2);
            }
            currentNode.balanceFactor = subTreeLeftHeight - subTreeRightHeight;
            ContadorOperacoes.Incrementa();
        }

        public void Remove(int value) {
            if(this.Search(value, root) == null) {
                ContadorOperacoes.Incrementa();
                Console.WriteLine("\n\t Valor não encontrado!");
            } else {
                Withdraw(value, root);
                Console.WriteLine("\n\t Valor removido!");
                quantity--;
                ContadorOperacoes.Incrementa(4);
            }
        }
        private Node Withdraw(int value, Node node) {
            if(node == null) {
                ContadorOperacoes.Incrementa();
                Console.WriteLine("\n\tErro: Registro nao encontrado");
            } 
            else if (value < (int) node.getItem()){
                node.setEsq(Withdraw(value, node.getEsq()));
                ContadorOperacoes.Incrementa(5);
            }
            else if (value > (int) node.getItem()){
                ContadorOperacoes.Incrementa(5);
                node.setDir(Withdraw(value, node.getDir()));
            }
            else {
                if (node.getDir() == null){
                    ContadorOperacoes.Incrementa();
                    node = node.getEsq();
                }
                else if (node.getEsq() == null){
                    ContadorOperacoes.Incrementa();
                    node = node.getDir();
                }
                else{
                    ContadorOperacoes.Incrementa();
                    node.setEsq(Predecessor(node, node.getEsq()));
                }
            }
            ContadorOperacoes.Incrementa(3);
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
            ContadorOperacoes.Incrementa(3);
            return r;
        }
        public int GetQuantity() {
            return quantity;
        }
    }
}
