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
        public StackDAO pilhaDao;

        public QueueDAO filaDao;

        public ListDAO listaDao;

        public TreeDAO arvoreDao;
        
        public HashDAO hashDao;
        
        public string selectedStruct;
        
        public formStructures() {
            InitializeComponent();
            this.pilhaDao = new StackDAO(output_txt);
            this.listaDao = new ListDAO(output_txt);
            this.filaDao = new QueueDAO(output_txt);
            this.arvoreDao = new TreeDAO(output_txt);
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
        

        public void ChangeColors(byte option) {
            switch(option) {
                case 1:
                    btn_pilha.BackColor = Color.MediumPurple;
                    btn_lista.BackColor = Color.DarkGray;
                    btn_fila.BackColor = Color.DarkGray;
                    btn_arvore.BackColor = Color.DarkGray;
                    btn_hash.BackColor = Color.DarkGray;
                    break;
                case 2:
                    btn_pilha.BackColor = Color.DarkGray;
                    btn_lista.BackColor = Color.MediumPurple;
                    btn_fila.BackColor = Color.DarkGray;
                    btn_arvore.BackColor = Color.DarkGray;
                    btn_hash.BackColor = Color.DarkGray;
                    break;
                case 3:
                    btn_pilha.BackColor = Color.DarkGray;
                    btn_lista.BackColor = Color.DarkGray;
                    btn_fila.BackColor = Color.MediumPurple;
                    btn_arvore.BackColor = Color.DarkGray;
                    btn_hash.BackColor = Color.DarkGray;
                    break;
                case 4:
                    btn_pilha.BackColor = Color.DarkGray;
                    btn_lista.BackColor = Color.DarkGray;
                    btn_fila.BackColor = Color.DarkGray;
                    btn_arvore.BackColor = Color.MediumPurple;
                    btn_hash.BackColor = Color.DarkGray;
                    break;
                case 5:
                    btn_pilha.BackColor = Color.DarkGray;
                    btn_lista.BackColor = Color.DarkGray;
                    btn_fila.BackColor = Color.DarkGray;
                    btn_arvore.BackColor = Color.DarkGray;
                    btn_hash.BackColor = Color.MediumPurple;
                    break;
                default:
                    btn_pilha.BackColor = Color.DarkGray;
                    btn_lista.BackColor = Color.DarkGray;
                    btn_fila.BackColor = Color.DarkGray;
                    btn_arvore.BackColor = Color.DarkGray;
                    btn_hash.BackColor = Color.DarkGray;
                    break;
            }
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
            output_txt.Clear();
            OperationCounter.Reset();
            ChangeEnabled(1);
            ChangeColors(1);
            ChangeDeleteButtonText(0);
            DisableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "PILHA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Pilha...\n");
            
            grid_tabelaOutput.DataSource = null;
            this.selectedStruct = "Pilha";

            try {
                this.pilhaDao.LoadDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar DAO.\n ");
                this.output_txt.AppendText("Exceção: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }

            grid_tabelaOutput.DataSource = this.pilhaDao.List().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_lista_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            ChangeEnabled(2);
            ChangeColors(2);
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
                this.listaDao.LoadDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }

            grid_tabelaOutput.DataSource = this.listaDao.List().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_fila_Click(object sender, EventArgs e) {
            output_txt.Clear();
            OperationCounter.Reset();
            ChangeEnabled(3);
            ChangeColors(3);
            ChangeDeleteButtonText(1);
            DisableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "FILA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Fila...\n");
            OperationCounter.Reset();
            selectedStruct = "Fila";
            grid_tabelaOutput.DataSource = null;

            try {
                this.filaDao.LoadDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.filaDao.List().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_arvore_Click(object sender, EventArgs e) {
            output_txt.Clear();
            OperationCounter.Reset();
            ChangeEnabled(4);
            ChangeColors(4);
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
                arvoreDao.LoadDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar Arvore!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.arvoreDao.List().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            OperationCounter.Reset();
        }

        private void btn_hash_Click(object sender, EventArgs e) {
            output_txt.Clear();
            OperationCounter.Reset();
            ChangeEnabled(5);
            ChangeColors(5);
            ChangeDeleteButtonText(2);
            DisableOrder();

            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "HASHTABLE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Tabela Hash...\n");
            OperationCounter.Reset();
            selectedStruct = "Hash";
            grid_tabelaOutput.DataSource = null;

            try {
                hashDao.LoadDAO();
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
            output_txt.Clear();
            OperationCounter.Reset();
            Stopwatch sw;

            output_txt.Clear();

            if (this.selectedStruct.Equals("Pilha")) {
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Desempilhando...\n");
                this.pilhaDao.Unstack();
                this.pilhaDao.SaveDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDao.List().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if(this.selectedStruct.Equals("Fila")) {
                sw = Stopwatch.StartNew();

                output_txt.AppendText("Desenfileirando...\n");
                this.filaDao.DequeueElement();
                this.filaDao.SaveDAO();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDao.List().Select(k => new { Valor = k }).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.selectedStruct.Equals("Lista")) {
                sw = Stopwatch.StartNew();

                if (grid_tabelaOutput.CurrentCell != null){
                    
                    output_txt.AppendText("Removendo linha "+grid_tabelaOutput.CurrentRow.Index+" da Lista...\n");
                    this.listaDao.RemoveAt(grid_tabelaOutput.CurrentRow.Index);
                    this.listaDao.SaveDao();
                    grid_tabelaOutput.DataSource = null;
                    grid_tabelaOutput.DataSource = this.listaDao.List().Select(k=> new {Valor = k}).ToList();
                    
                }

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.selectedStruct.Equals("Arvore")) {
                sw = Stopwatch.StartNew();

                if (grid_tabelaOutput.CurrentCell != null){
                    
                    int valorASerRemovido = (int) grid_tabelaOutput.CurrentCell.Value;
                    output_txt.AppendText("Removendo elemento "+valorASerRemovido+" da Árvore...\n");
                    this.arvoreDao.RemoveElement(valorASerRemovido);
                    this.arvoreDao.SaveDAO();
                    grid_tabelaOutput.DataSource = null;
                    grid_tabelaOutput.DataSource = this.arvoreDao.List().Select(k=> new {Valor = k}).ToList();
                    
                }

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.selectedStruct.Equals("Hash")) {
                sw = Stopwatch.StartNew();

                if (grid_tabelaOutput.CurrentCell != null){
                    
                    output_txt.AppendText("Removendo elemento " + (int) grid_tabelaOutput.CurrentCell.Value + " da Tabela Hash...\n");
                    this.hashDao.Remove((int) grid_tabelaOutput.CurrentCell.Value);
                    this.hashDao.SaveDao();
                    grid_tabelaOutput.DataSource = null;
                    grid_tabelaOutput.DataSource = this.hashDao.List().Select(k => new { Valores = k }).ToList();
                    
                }
                else
                {
                    output_txt.AppendText("Não é possível remover elementos de uma Tabela Hash vazia\n");
                }

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
                    this.pilhaDao.Stack(element);
                    this.pilhaDao.SaveDao();
                    grid_tabelaOutput.DataSource = this.pilhaDao.List().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Empilhado!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop(); 
                }

                else if(this.selectedStruct.Equals("Fila")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Enfileirando...\n");
                    filaDao.EnqueueElement(element);
                    filaDao.SaveDAO();
                    grid_tabelaOutput.DataSource = this.filaDao.List().Select(k => new { Valor = k }).ToList();

                    output_txt.AppendText("Enfileirado!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop();
                }

                else if (this.selectedStruct.Equals("Lista")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ element +"...\n");
                    this.listaDao.Insert(element);
                    this.listaDao.SaveDao();
                    grid_tabelaOutput.DataSource = this.listaDao.List().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop();
                }

                else if (this.selectedStruct.Equals("Arvore")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ element +"...\n");
                    this.arvoreDao.InsertElement(element);
                    this.arvoreDao.SaveDAO();
                    grid_tabelaOutput.DataSource = this.arvoreDao.List().Select(k=> new {Valor = k}).ToList();

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
            btn_pilha_Click_1(sender , e);
        }

        private void btn_qtde_Click(object sender, EventArgs e) {
            output_txt.Clear();
            OperationCounter.Reset();

            int totalOperacoes = 0;
            
            Stopwatch sw, stopWatchTotal;
            stopWatchTotal= Stopwatch.StartNew();
            
            //Pilha
            sw = Stopwatch.StartNew();
            
            try {
                pilhaDao.LoadDAO();
            } catch {}
            
            output_txt.AppendText("Pilha: "+ pilhaDao.GetQuant() + "\n");
            output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");            
            output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");

            totalOperacoes += OperationCounter.QuantOperacoes;
            OperationCounter.Reset();
            sw.Stop();
            
            //Lista
            this.output_txt.AppendText("================================\n");
            sw = Stopwatch.StartNew();
            
            try {
                listaDao.LoadDAO();
            } catch {}
            
            output_txt.AppendText("Lista: "+ listaDao.GetQuant() + "\n");
            output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
            
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            totalOperacoes += OperationCounter.QuantOperacoes;

            OperationCounter.Reset();
            sw.Stop();

            //Fila
            this.output_txt.AppendText("================================\n");
            sw = Stopwatch.StartNew();

            try {
                filaDao.LoadDAO();
            } catch {}

            output_txt.AppendText("Fila: "+ filaDao.GetQuant() + "\n");
            output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            totalOperacoes += OperationCounter.QuantOperacoes;

            OperationCounter.Reset();
            sw.Stop();


            //Árvore
            this.output_txt.AppendText("================================\n");
            sw = Stopwatch.StartNew();
            
            try {
                arvoreDao.LoadDAO();
            } catch {}
            
            output_txt.AppendText("Árvore: "+ arvoreDao.GetQuant() + "\n");
            output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");            
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");

            totalOperacoes += OperationCounter.QuantOperacoes;
            OperationCounter.Reset();
            sw.Stop();

            //Hash
            this.output_txt.AppendText("================================\n");
            sw = Stopwatch.StartNew();
            
            try {
                hashDao.LoadDAO();
            } catch {}
            
            output_txt.AppendText("Tabela Hash: "+ hashDao.GetQuant() + "\n");
            output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");            
            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");

            totalOperacoes += OperationCounter.QuantOperacoes;
            OperationCounter.Reset();
            sw.Stop();
            
            //Total
            this.output_txt.AppendText("================================\n");

            int total = pilhaDao.GetQuant() + 
                        hashDao.GetQuant() + 
                        filaDao.GetQuant() + 
                        arvoreDao.GetQuant() +
                        listaDao.GetQuant(); 
            
            output_txt.AppendText("Total de elementos: "+ total + "\n");
            output_txt.AppendText("Total de operações: "+ totalOperacoes + "\n");
            output_txt.AppendText("Tempo total de execução: "+ stopWatchTotal.ElapsedMilliseconds.ToString() + "ms \n");

            stopWatchTotal.Stop();
        }

        private void btn_limpar_Click(object sender, EventArgs e) {
            OperationCounter.Reset();
            output_txt.Clear();

            if (this.selectedStruct.Equals("Pilha")) {
                pilhaDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Fila")) {
                filaDao.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDao.List().Select(k => new { Valor = k }).ToList();
            } 

            else if (this.selectedStruct.Equals("Lista")) {
                listaDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.listaDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Arvore")) {
                arvoreDao.CleanDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.arvoreDao.List().Select(k => new { Valor = k }).ToList();
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
            output_txt.Clear();
            OperationCounter.Reset();
            Stopwatch sw;
            
            if (this.selectedStruct.Equals("Lista")) {
                sw = Stopwatch.StartNew();
                
                this.output_txt.AppendText("Ordenando Lista...\n");
                listaDao.SortDao();
                this.output_txt.AppendText("Lista ordenada!...\n");

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
                
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.listaDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Pilha")) {
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Ordenando a Pilha...");
                pilhaDao.SortDao();
                output_txt.AppendText("Pilha Ordenada!");
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
                
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Fila")) {
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Ordenando a Fila...");
                filaDao.SortDao();
                output_txt.AppendText("Fila Ordenada!");
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
                
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDao.List().Select(k => new { Valor = k }).ToList();
            }

            else if (this.selectedStruct.Equals("Arvore")) 
                output_txt.AppendText("Não é possível ordenar uma àrvore ABP!\n");            

            else if (this.selectedStruct.Equals("Hash")) {
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Ordenando Tabela Hash...");
                hashDao.SortDao();
                output_txt.AppendText("Tabela Hash Ordenada!");
                
                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();

                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.hashDao.List().Select(k => new { Valores = k }).ToList();
            }

            this.output_txt.AppendText("Quantidade de operações: " + OperationCounter.QuantOperacoes + "\n");
            OperationCounter.Reset();
        }
    }
}