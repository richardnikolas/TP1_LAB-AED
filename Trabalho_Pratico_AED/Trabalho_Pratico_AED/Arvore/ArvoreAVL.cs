﻿using System;

namespace Trabalho_Pratico_AED.Arvore {
    public class ArvoreAVL {
        
        /*
         * Arvore binária AVL feita por:
         *     Philemon da Silva Souza e
         *     Felibe Ribeiro Lisboa Moreira
         * 
         * com suporte de:
         *     Richard Nikolas (com recursividade),
         *     Neemias da Silva Souza (com a função de remoção),
         *     Internet (função de remoçao),
         *      e Fabio Leandro Rodrigues Cordeiro (fornecendo a motivação do ódio puro)
         * 
         * "Get a hold of this Fabio guy... what a jerk, am I right?"
         *                          -Einstein, probably.
        */
        
        private Nodulo raiz;
        
        public ArvoreAVL(){

        }
        
        public void inserir(int elemento){
            Nodulo novoNodulo = new Nodulo(elemento);
            if (raiz == null)
                raiz = novoNodulo;
            else
                raiz = insere(raiz, novoNodulo);
        }
        private Nodulo insere(Nodulo noduloAtual, Nodulo novoNodulo)
        {
            if (noduloAtual == null){
                noduloAtual = novoNodulo;
                return noduloAtual;
            }
            else if ((int)novoNodulo.getItem() < (int)noduloAtual.getItem()){
                noduloAtual.setEsq(insere(noduloAtual.getEsq(), novoNodulo));
                noduloAtual = balancear(noduloAtual);
            }
            else if ((int)novoNodulo.getItem() > (int)noduloAtual.getItem()){
                noduloAtual.setDir(insere(noduloAtual.getDir(), novoNodulo));
                noduloAtual = balancear(noduloAtual);
            }
            return noduloAtual;
        }
        private Nodulo balancear(Nodulo novoNodulo)
        {
            int fatorBalanceamento = calculaFatorBalanceamento(novoNodulo);
            if (fatorBalanceamento > 1){
                if (calculaFatorBalanceamento(novoNodulo.getEsq()) > 0)
                    novoNodulo = rotacaoEE(novoNodulo);
                else
                    novoNodulo = rotacaoED(novoNodulo);
            }
            else if (fatorBalanceamento < -1){
                if (calculaFatorBalanceamento(novoNodulo.getDir()) > 0)
                    novoNodulo = rotacaoDE(novoNodulo);
                else
                    novoNodulo = rotacaoDD(novoNodulo);
            }
            return novoNodulo;
        }
        public void deletar(int item){
            raiz = deleta(raiz, item);
        }
        private Nodulo deleta(Nodulo noduloAtual, int itemASerDeletado){
            Nodulo pai;
            if (noduloAtual.Equals(null))
                return null;
            else{
                //Subárvore esquerda
                if (itemASerDeletado < (int)noduloAtual.getItem()){
                    noduloAtual.setEsq(deleta(noduloAtual.getEsq(), itemASerDeletado));
                    if (calculaFatorBalanceamento(noduloAtual) == -2){
                        if (calculaFatorBalanceamento(noduloAtual.getDir()) <= 0)
                            noduloAtual = rotacaoDD(noduloAtual);
                        else
                            noduloAtual = rotacaoDE(noduloAtual);
                    }
                }
                //Subárvore direita
                else if (itemASerDeletado > (int)noduloAtual.getItem()){
                    noduloAtual.setDir(deleta(noduloAtual.getDir(), itemASerDeletado));
                    if (calculaFatorBalanceamento(noduloAtual) == 2){
                        if (calculaFatorBalanceamento(noduloAtual.getEsq()) >= 0)
                            noduloAtual = rotacaoEE(noduloAtual);
                        else
                            noduloAtual = rotacaoED(noduloAtual);
                    }
                }
                else{
                    if (noduloAtual.getDir().Equals(null)){
                        pai = noduloAtual.getDir();
                        while (pai.getEsq().Equals(null)){
                            pai = pai.getEsq();
                        }
                        noduloAtual.setItem(pai.getItem());
                        noduloAtual.setDir(deleta(noduloAtual.getDir(), (int)pai.getItem()));
                        if (calculaFatorBalanceamento(noduloAtual) == 2){
                            if (calculaFatorBalanceamento(noduloAtual.getEsq()) >= 0)
                                noduloAtual = rotacaoEE(noduloAtual);
                            else
                                noduloAtual = rotacaoED(noduloAtual);
                        }
                    }
                    else
                        return noduloAtual.getEsq();
                }
            }
            return noduloAtual;
        }
        public bool pesquisar(int item){
            if (pesquisa(item, raiz).getItem().Equals(item))
                return true;
            else return false;
        }
        private Nodulo pesquisa(int item, Nodulo noduloAtual){
 
                if (item < (int)noduloAtual.getItem()){
                    if (item == (int) noduloAtual.getItem())
                        return noduloAtual;
                    else return pesquisa(item, noduloAtual.getEsq());
                }
                else{
                    if (item == (int) noduloAtual.getItem())
                        return noduloAtual;
                    else return pesquisa(item, noduloAtual.getDir());
                }
        }
        //Imprime a arvore:
        public void imprimir(){
            if (raiz.Equals(null)){
                Console.WriteLine("Arvore está vazia!");
                return;
            }
            imprimirEmOrdem(raiz);
            Console.WriteLine();
        }
        //Impriem subárvore em ordem:
        private void imprimirEmOrdem(Nodulo nohAtual){
            if (!nohAtual.Equals(null)){
                imprimirEmOrdem(nohAtual.getEsq());
                Console.Write("({0}) ", (int)nohAtual.getItem());
                imprimirEmOrdem(nohAtual.getDir());
            }
        }
        private int retornaMaior(int item1, int item2){
            return item1 > item2 ? item1 : item2;
        }
        private int getAltura(Nodulo noduloAtual){
            int height = 0;
            if (noduloAtual.Equals(null)){
                int l = getAltura(noduloAtual.getEsq());
                int r = getAltura(noduloAtual.getDir());
                int m = retornaMaior(l, r);
                height = m + 1;
            }
            return height;
        }
        private int calculaFatorBalanceamento(Nodulo noduloAtual){
            int fatorBalanceamentoEsq = getAltura(noduloAtual.getEsq());
            int fatorBalanceamentoDir = getAltura(noduloAtual.getDir());
            int fatorBalanceamento = fatorBalanceamentoEsq - fatorBalanceamentoDir;
            return fatorBalanceamento;
        }
        private Nodulo rotacaoDD(Nodulo pai){
            Nodulo noduloParaGiro = pai.getDir();
            pai.setDir(noduloParaGiro.getEsq()) ;
            noduloParaGiro.setEsq(pai);
            return noduloParaGiro;
        }
        private Nodulo rotacaoEE(Nodulo pai){
            Nodulo noduloParaGiro = pai.getEsq();
            pai.setEsq(noduloParaGiro.getDir());
            noduloParaGiro.setDir(pai);
            return noduloParaGiro;
        }
        private Nodulo rotacaoED(Nodulo parent){
            Nodulo noduloParaGiro = parent.getEsq();
            parent.setEsq(rotacaoDD(noduloParaGiro));
            return rotacaoEE(parent);
        }
        private Nodulo rotacaoDE(Nodulo parent){
            Nodulo noduloParaGiro = parent.getDir();
            parent.setDir(rotacaoEE(noduloParaGiro));
            return rotacaoDD(parent);
        }
        //Retorna a quantidade de nós/elementos em uma árvore
        public int getQuant(){
            if (raiz.getItem().Equals(null)){
                return 0;
            }
            return calcularQuantNohsSubArvore(raiz);
        }
        //Checa se uma subárvore está vazia:
        private bool subarvoreEstaVazia(Nodulo raizDaSubArvore){
            return (raizDaSubArvore.getEsq().Equals(null) && raizDaSubArvore.getDir().Equals(null));
        }
        //Retorna a quantidade de elementos em uma subárvore
        private int calcularQuantNohsSubArvore(Nodulo noduloRaizSubarvore){
            int quantNohs = 0;
            if(!subarvoreEstaVazia(noduloRaizSubarvore)){
                if (!noduloRaizSubarvore.getEsq().Equals(null)) 
                    quantNohs += calcularQuantNohsSubArvore(noduloRaizSubarvore.getEsq()) + 1;
                if (!noduloRaizSubarvore.getDir().Equals(null)) 
                    quantNohs += calcularQuantNohsSubArvore(noduloRaizSubarvore.getDir()) + 1;
                return quantNohs;
            }
            return 1;
        }
    }
}