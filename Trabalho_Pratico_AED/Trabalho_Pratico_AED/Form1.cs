using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exercicios.Exercicio1;
using Trabalho_Pratico_AED;
using Trabalho_Pratico_AED.Arvore;
using Trabalho_Pratico_AED.Pilha;
using Trabalho_Pratico_AED.Fila;
using VS_Code;

namespace Trabalho_Pratico_AED {
    public partial class formStructures : Form {
        /*
         * Classe controladora do formulário.
         *
         * Design: André Valentim
         * 
         * Lógica: Philemon da Silva Souza,
         *         André Valentim,
         *         Richard Nikolas e
         *         Felipe Ribeiro Lisboa Moreira
         * 
         * Documentação e ajustes de Legibilidade:
         *         Richard Nikolas,
         *         André Valentim e
         *         Philemon da Silva Souza
         * 
         * Revisão, Testes e Correções:
         *         Richard Nikolas e
         *         Felipe Ribeiro lisboa Moreira
         * 
         * Classes: Adicionadas do exercício de AED's passado na mesma semana.
         *          (créditos individuais podem ser encontrados na classe)
         * 
         */
        public StackDAO StackDao;

        public QueueDAO filaDAO;

        public ListDAO ListDao;

        public TreeDAO TreeDao;
        
        public HashDAO hashDao;
        
        public string selectedStruct;
        
        public formStructures() {
            InitializeComponent();
            this.StackDao = new StackDAO(output_txt);
            this.ListDao = new ListDAO(output_txt);
            this.filaDAO = new QueueDAO(output_txt);
            this.TreeDao = new TreeDAO(output_txt);
            this.hashDao = new HashDAO(output_txt);
        }

        public void ChangeDeleteButtonText(byte dataStructureType) {
            /*Atribui-se o número 0 para determinar o texto para o botão da Pilha
             * Atribui-se o número 1 para determinar o texto para o botão da Fila
             * Atribui-se o número 0 para as demais estruturas.
             */
            switch(dataStructureType) {
                case 0: btn_delete.Text = "Desempilhar";
                    break;
                case 1: btn_delete.Text = "Desenfileirar";
                    break;
                default: btn_delete.Text = "Deletar selecionado";
                    break;
            }
        }

        public void EnableOrder(){
            btn_ordenar.Enabled = true;
        }
        public void DisableOrder(){
            btn_ordenar.Enabled = false;
        }
        

        public void ChangeEnabled(byte option) {
            switch(option) {
                case 1:
                    btn_pilha.Enabled = false;
                    btn_lista.Enabled = true;
                    btn_fila.Enabled = true;
                    btn_arvore.Enabled = true;
                    btn_hash.Enabled = true;
                    break;
                case 2:
                    btn_pilha.Enabled = true;
                    btn_lista.Enabled = false;
                    btn_fila.Enabled = true;
                    btn_arvore.Enabled = true;
                    btn_hash.Enabled = true;
                    break;
                case 3:
                    btn_pilha.Enabled = true;
                    btn_lista.Enabled = true;
                    btn_fila.Enabled = false;
                    btn_arvore.Enabled = true;
                    btn_hash.Enabled = true;
                    break;
                case 4:
                    btn_pilha.Enabled = true;
                    btn_lista.Enabled = true;
                    btn_fila.Enabled = true;
                    btn_arvore.Enabled = false;
                    btn_hash.Enabled = true;
                    break;
                case 5:
                    btn_pilha.Enabled = true;
                    btn_lista.Enabled = true;
                    btn_fila.Enabled = true;
                    btn_arvore.Enabled = true;
                    btn_hash.Enabled = false;
                    break;
                default:
                    btn_pilha.Enabled = true;
                    btn_lista.Enabled = true;
                    btn_fila.Enabled = true;
                    btn_arvore.Enabled = true;
                    btn_hash.Enabled = true;
                    break;
            }
        }

        private void btn_pilha_Click_1(object sender, EventArgs e){
            OperationCounter.Reset();
            ChangeEnabled(1);
            ChangeDeleteButtonText (0);
            EnableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "PILHA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Pilha...\n");
            
            grid_tabelaOutput.DataSource = null;
            this.selectedStruct = "Pilha";

            try {
                this.StackDao.LoadDao();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar DAO.\n ");
                this.output_txt.AppendText("Excessão: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }

            grid_tabelaOutput.DataSource = this.StackDao.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_lista_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            ChangeEnabled(2);
            ChangeDeleteButtonText(2);
            EnableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "LISTA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Lista...\n");
            OperationCounter.Reset();
            selectedStruct = "Lista";
            grid_tabelaOutput.DataSource = null;

            try {
                this.ListDao.LoadDao();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }

            grid_tabelaOutput.DataSource = this.StackDao.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_fila_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            ChangeEnabled(3);
            ChangeDeleteButtonText(1);
            EnableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "FILA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Fila...\n");
            OperationCounter.Reset();
            selectedStruct = "Fila";
            grid_tabelaOutput.DataSource = null;

            try {
                this.filaDAO.CarregarDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_arvore_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            ChangeEnabled(4);
            ChangeDeleteButtonText(2);
            DisableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "ÁRVORE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Árvore AVL...\n");
            OperationCounter.Reset();
            selectedStruct = "Arvore";
            grid_tabelaOutput.DataSource = null;

            try {
                TreeDao.LoadDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar Arvore!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.TreeDao.List().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_hash_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            ChangeEnabled(5);
            ChangeDeleteButtonText(2);
            EnableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "HASHTABLE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Tabela Hash...\n");
            OperationCounter.Reset();
            selectedStruct = "Hash";
            grid_tabelaOutput.DataSource = null;

            try {
                hashDao.LoadDao();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar Tabela Hash!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.hashDao.List().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_delete_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            Stopwatch sw;

            output_txt.Clear();

            if (this.selectedStruct.Equals("Pilha")) {
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Desempilhando...\n");
                this.StackDao.Unstack();
                this.StackDao.SaveDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.StackDao.Listar().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if(this.selectedStruct.Equals("Fila")) {
                sw = Stopwatch.StartNew();

                output_txt.AppendText("Desenfileirando...\n");
                this.filaDAO.DequeueElement();
                this.filaDAO.SaveDAO();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.selectedStruct.Equals("Lista")) {
                sw = Stopwatch.StartNew();

                output_txt.AppendText("Removendo linha "+grid_tabelaOutput.CurrentRow.Index+" da Lista...\n");
                this.ListDao.RemoveAt(grid_tabelaOutput.CurrentRow.Index);
                this.ListDao.SaveDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.ListDao.List().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.selectedStruct.Equals("Arvore")) {
                sw = Stopwatch.StartNew();

                int valorASerRemovido = (int) grid_tabelaOutput.CurrentCell.Value;
                output_txt.AppendText("Removendo elemento "+valorASerRemovido+" da Árvore...\n");
                this.TreeDao.RemoveElement(valorASerRemovido);
                this.TreeDao.SaveDAO();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.TreeDao.List().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.selectedStruct.Equals("Hash")) {
                sw = Stopwatch.StartNew();

                output_txt.AppendText("Removendo elemento " + grid_tabelaOutput.CurrentRow.Index + " da Tabela Hash...\n");
                this.hashDao.Remove(grid_tabelaOutput.CurrentRow.Index);
                this.hashDao.SaveDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.hashDao.List().Select(k => new { Valores = k }).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            OperationCounter.Reset();
        }

        private void btn_inserir_Click(object sender, EventArgs e)  {
            OperationCounter.Reset();
            Stopwatch sw;

            output_txt.Clear();
            grid_tabelaOutput.DataSource = null;

            int element;

            if (int.TryParse(inserir_txt.Text, out element)) {
                if (this.selectedStruct.Equals("Pilha")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Empilhando...\n");
                    this.StackDao.Stack(element);
                    this.StackDao.SaveDao();
                    grid_tabelaOutput.DataSource = this.StackDao.Listar().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Empilhado!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop(); 
                }

                else if(this.selectedStruct.Equals("Fila")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Enfileirando...\n");
                    filaDAO.EnqueueElement(element);
                    filaDAO.SaveDAO();
                    grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();

                    output_txt.AppendText("Enfileirado!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop();
                }

                else if (this.selectedStruct.Equals("Lista")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ element +"...\n");
                    this.ListDao.Insert(element);
                    this.ListDao.SaveDao();
                    grid_tabelaOutput.DataSource = this.ListDao.List().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop();
                }

                else if (this.selectedStruct.Equals("Arvore")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ element +"...\n");
                    this.TreeDao.InsertElement(element);
                    this.TreeDao.SaveDAO();
                    grid_tabelaOutput.DataSource = this.TreeDao.List().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                    sw.Stop();
                }

                else if (this.selectedStruct.Equals("Hash")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ element +"...\n");
                    this.hashDao.Insert(element);
                    this.hashDao.SaveDao();
                    grid_tabelaOutput.DataSource = this.hashDao.List().Select(k => new { Valores = k }).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                    sw.Stop();
                }
            }
            else 
                output_txt.AppendText("Não é possível inserir elementos não-inteiros!\n");
            
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            OperationCounter.Reset();
        }

        private void formStructures_Load(object sender, EventArgs e) {

        }

        private void btn_qtde_Click(object sender, EventArgs e) {

        }

        private void btn_limpar_Click(object sender, EventArgs e){
            OperationCounter.Reset();
            output_txt.Clear();

            if (this.selectedStruct.Equals("Pilha")) {
                StackDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.StackDao.Listar().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Fila")) {
                filaDAO.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();
            } 

            else if (this.selectedStruct.Equals("Lista")) {
                ListDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.ListDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Arvore")) {
                TreeDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.TreeDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Hash")) {
                hashDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.hashDao.List().Select(k => new { Valores = k }).ToList();
            }

            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            OperationCounter.Reset();
        }

        private void Btn_ordenar_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            Stopwatch sw;
            
            if (this.selectedStruct.Equals("Lista")){
                sw = Stopwatch.StartNew();
                
                this.output_txt.AppendText("Ordenando Lista...\n");
                ListDao.SortDao();
                this.output_txt.AppendText("Lista ordenada!...\n");
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }
            else if (this.selectedStruct.Equals("Pilha")){
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Ordenando a Pilha...");
                StackDao.SortDao();
                output_txt.AppendText("Pilha Ordenada!");
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }
            else if (this.selectedStruct.Equals("Fila")){
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }
            else if (this.selectedStruct.Equals("Arvore")){
                output_txt.AppendText("Não é possível ordenar uma àrvore ABP!\n");
            }
            else if (this.selectedStruct.Equals("Hash")){
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Ordenando Tabela Hash...");
                hashDao.SortDao();
                output_txt.AppendText("Tabela Hash Ordenada!");
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            OperationCounter.Reset();
        }
    }
}