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
         * Lógica: Philemon da Silva Souza, André Valentim, Richard Nikolas e Felipe Ribeiro Lisboa Moreira
         * Documentação e ajustes de Legibilidade: Richard Nikolas, André Valentim e Philemon da Silva Souza
         * Revisão, Testes e Correção de Bugs: Richard Nikolas e Felipe Ribeiro lisboa Moreira
         * 
         * Classes: Adicionadas do exercício de AED's passado na mesma semana.
         *          (créditos individuais podem ser encontrados na classe)
         * 
         */
        public PilhaDAO pilhaDAO;

        public QueueDAO filaDAO;

        public ListaDAO listaDao;

        public ArvoreDAO arvoreDao;
        
        public HashDAO hashDao;
        
        public string estruturaSelecionada;
        
        public formStructures() {
            InitializeComponent();
            this.pilhaDAO = new PilhaDAO(output_txt);
            this.listaDao = new ListaDAO(output_txt);
            this.filaDAO = new QueueDAO(output_txt);
            this.arvoreDao = new ArvoreDAO(output_txt);
            this.hashDao = new HashDAO(output_txt);
        }

        public void DisableDelete() {
            delete_txt.Enabled = false;
            btn_delete.Enabled = false;
        }

        public void EnableDelete() {
            delete_txt.Enabled = true;
            btn_delete.Enabled = true;
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
            ChangeEnabled(1);
            DisableDelete();
            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "PILHA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Pilha...\n");

            ContadorOperacoes.Reset();

            grid_tabelaOutput.DataSource = null;
            this.estruturaSelecionada = "Pilha";

            try {
                this.pilhaDAO.CarregarDao();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar DAO.\n ");
                this.output_txt.AppendText("Excessão: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }

            grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            ContadorOperacoes.Reset();
        }

        private void btn_lista_Click(object sender, EventArgs e){
            ChangeEnabled(2);
            EnableDelete();
            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "LISTA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Lista...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Lista";
            grid_tabelaOutput.DataSource = null;

            try {
                this.listaDao.CarregarDao();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }

            grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            ContadorOperacoes.Reset();
        }

        private void btn_fila_Click(object sender, EventArgs e){
            ChangeEnabled(3);
            DisableDelete();
            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "FILA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Fila...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Fila";
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
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            ContadorOperacoes.Reset();
        }

        private void btn_arvore_Click(object sender, EventArgs e){
            ChangeEnabled(4);
            EnableDelete();
            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "ÁRVORE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Árvore AVL...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Arvore";
            grid_tabelaOutput.DataSource = null;

            try {
                arvoreDao.CarregarDAO();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar Arvore!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.arvoreDao.Listar().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            ContadorOperacoes.Reset();
        }

        private void btn_hash_Click(object sender, EventArgs e) {
            ChangeEnabled(5);
            EnableDelete();
            Stopwatch sw;

            sw = Stopwatch.StartNew();

            labelSelectedStructure.Text = "HASHTABLE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Tabela Hash...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Hash";
            grid_tabelaOutput.DataSource = null;

            try {
                hashDao.CarregarDao();
            }
            catch (Exception ex) {
                this.output_txt.AppendText("Falha ao carregar Tabela Hash!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }

            grid_tabelaOutput.DataSource = this.hashDao.Listar().Select(k => new { Valores = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            this.output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

            sw.Stop();
            ContadorOperacoes.Reset();
        }

        private void btn_delete_Click(object sender, EventArgs e) {
            ContadorOperacoes.Reset();
            Stopwatch sw;

            output_txt.Clear();

            if (this.estruturaSelecionada.Equals("Pilha")) {
                sw = Stopwatch.StartNew();
                
                output_txt.AppendText("Desempilhando...\n");
                this.pilhaDAO.Desempilhar();
                this.pilhaDAO.SalvarDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if(this.estruturaSelecionada.Equals("Fila")) {
                sw = Stopwatch.StartNew();

                output_txt.AppendText("Desenfileirando...\n");
                this.filaDAO.DequeueElement();
                this.filaDAO.SalvarDAO();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.estruturaSelecionada.Equals("Lista")) {
                sw = Stopwatch.StartNew();

                output_txt.AppendText("Removendo linha "+grid_tabelaOutput.CurrentRow.Index+" da Lista...\n");
                this.listaDao.Remover(grid_tabelaOutput.CurrentRow.Index);
                this.listaDao.SalvarDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.listaDao.Listar().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.estruturaSelecionada.Equals("Arvore")) {
                sw = Stopwatch.StartNew();

                int valorASerRemovido = (int) grid_tabelaOutput.CurrentCell.Value;
                output_txt.AppendText("Removendo elemento "+valorASerRemovido+" da Árvore...\n");
                this.arvoreDao.RemoveElement(valorASerRemovido);
                this.arvoreDao.SalvarDAO();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.arvoreDao.Listar().Select(k=> new {Valor = k}).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            else if (this.estruturaSelecionada.Equals("Hash")) {
                sw = Stopwatch.StartNew();

                int valorASerRemovido = (int) grid_tabelaOutput.CurrentCell.Value;
                output_txt.AppendText("Removendo elemento "+valorASerRemovido+" da Tabela Hash...\n");
                this.hashDao.Remover(valorASerRemovido);
                this.hashDao.SalvarDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.hashDao.Listar().Select(k => new { Valores = k }).ToList();

                output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                sw.Stop();
            }

            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            ContadorOperacoes.Reset();
        }

        private void btn_inserir_Click(object sender, EventArgs e)  {
            ContadorOperacoes.Reset();
            Stopwatch sw;

            output_txt.Clear();
            grid_tabelaOutput.DataSource = null;

            int elemento;

            if (int.TryParse(inserir_txt.Text, out elemento)) {
                if (this.estruturaSelecionada.Equals("Pilha")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Empilhando...\n");
                    this.pilhaDAO.Empilhar(elemento);
                    this.pilhaDAO.SalvarDao();
                    grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Empilhado!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop(); 
                }

                else if(this.estruturaSelecionada.Equals("Fila")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Enfileirando...\n");
                    filaDAO.EnqueueElement(elemento);
                    filaDAO.SalvarDAO();
                    grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();

                    output_txt.AppendText("Enfileirado!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop();
                }

                else if (this.estruturaSelecionada.Equals("Lista")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ elemento +"...\n");
                    this.listaDao.Inserir(elemento);
                    this.listaDao.SalvarDao();
                    grid_tabelaOutput.DataSource = this.listaDao.Listar().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");

                    sw.Stop();
                }

                else if (this.estruturaSelecionada.Equals("Arvore")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ elemento +"...\n");
                    this.arvoreDao.InsertElement(elemento);
                    this.arvoreDao.SalvarDAO();
                    grid_tabelaOutput.DataSource = this.arvoreDao.Listar().Select(k=> new {Valor = k}).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                    sw.Stop();
                }

                else if (this.estruturaSelecionada.Equals("Hash")) {
                    sw = Stopwatch.StartNew();

                    output_txt.AppendText("Inserindo elemento "+ elemento +"...\n");
                    this.hashDao.Inserir(elemento);
                    this.hashDao.SalvarDao();
                    grid_tabelaOutput.DataSource = this.hashDao.Listar().Select(k => new { Valores = k }).ToList();

                    output_txt.AppendText("Elemento inserido!\n");
                    output_txt.AppendText("Tempo gasto: " + sw.ElapsedMilliseconds.ToString() + " ms\n");
                    sw.Stop();
                }
            }
            else 
                output_txt.AppendText("Não é possível inserir elementos não-inteiros!\n");
            
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            ContadorOperacoes.Reset();
        }

        private void formStructures_Load(object sender, EventArgs e) {
            DisableDelete();
        }

        private void btn_qtde_Click(object sender, EventArgs e) {

        }

        private void btn_limpar_Click(object sender, EventArgs e){
            ContadorOperacoes.Reset();
            output_txt.Clear();

            if (this.estruturaSelecionada.Equals("Pilha")) {
                pilhaDAO.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k => new { Valor = k }).ToList();
            }

            else if (this.estruturaSelecionada.Equals("Fila")) {
                filaDAO.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();
            } 

            else if (this.estruturaSelecionada.Equals("Lista")) {
                listaDao.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.listaDao.Listar().Select(k => new { Valor = k }).ToList();
            }

            else if (this.estruturaSelecionada.Equals("Arvore")) {
                arvoreDao.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.arvoreDao.Listar().Select(k => new { Valor = k }).ToList();
            }

            else if (this.estruturaSelecionada.Equals("Hash")) {
                hashDao.LimparDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.hashDao.Listar().Select(k => new { Valores = k }).ToList();
            }

            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            ContadorOperacoes.Reset();
        }

        private void Btn_ordenar_Click(object sender, EventArgs e) {
            ContadorOperacoes.Reset();
            
            if (this.estruturaSelecionada.Equals("Lista"))
                listaDao.OrdernarDao();            
        }
    }
}