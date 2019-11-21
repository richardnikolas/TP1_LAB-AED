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
using Trabalho_Pratico_AED;
using Trabalho_Pratico_AED.Pilha;
using Trabalho_Pratico_AED.Fila;
using VS_Code;

namespace Trabalho_Pratico_AED{
    public partial class formStructures : Form{
        /*
         * Classe controladora do formulário.
         *
         * Design: André Valentim
         * Lógica: Philemon da Silva Souza
         * Classes: Adicionadas do exercício de AED's passado na mesma semana.
         *          (créditos individuais podem ser encontrados na classe)
         * Documentação: Richard Nikolas e André Valentim
         * 
         */
        public PilhaDAO pilhaDAO;

        public QueueDAO filaDAO;

        public ListaDAO listaDao;

        //TODO: inserir arvoreDAO

        //TODO: inserir hashDAO
        
        public string estruturaSelecionada;
        
        public formStructures(){
            InitializeComponent();
            this.pilhaDAO = new PilhaDAO(output_txt);
            this.listaDao = new ListaDAO(output_txt);
            this.filaDAO = new QueueDAO(output_txt);
        }

        public void disableDelete() {
            delete_txt.Enabled = false;
            btn_delete.Enabled = false;
        }
        public void enableDelete() {
            delete_txt.Enabled = true;
            btn_delete.Enabled = true;
        }
        public void changeEnabled(byte option) {
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
            changeEnabled(1);
            disableDelete();
            labelSelectedStructure.Text = "PILHA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Pilha...\n");
            ContadorOperacoes.Reset();
            grid_tabelaOutput.DataSource = null;
            this.estruturaSelecionada = "Pilha";
            try{
                this.pilhaDAO.CarregarDao();
            }
            catch (Exception ex){
                this.output_txt.AppendText("Falha ao carregar DAO.\n ");
                this.output_txt.AppendText("Excessão: \n "+ ex.Message+"\n Local : \n"+ ex.StackTrace +"\n");
            }
            grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            ContadorOperacoes.Reset();
        }

        private void btn_lista_Click(object sender, EventArgs e){
            changeEnabled(2);
            enableDelete();
            labelSelectedStructure.Text = "LISTA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Lista...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Lista";
            grid_tabelaOutput.DataSource = null;
            try{
                this.listaDao.CarregarDao();
            }
            catch (Exception ex){
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }
            grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            ContadorOperacoes.Reset();
        }

        private void btn_fila_Click(object sender, EventArgs e){
            changeEnabled(3);
            disableDelete();
            labelSelectedStructure.Text = "FILA";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Fila...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Fila";
            grid_tabelaOutput.DataSource = null;
            try {
                this.filaDAO.CarregarDAO();
            } catch(Exception ex) {
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Exceção: \n " + ex.Message + "\n Local : \n" + ex.Source + "\n");
            }
            grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
            this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
            ContadorOperacoes.Reset();
        }

        private void btn_arvore_Click(object sender, EventArgs e){
            changeEnabled(4);
            enableDelete();
            labelSelectedStructure.Text = "ÁRVORE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Árvore AVL...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Arvore";
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir arvoreDAO
        }

        private void btn_hash_Click(object sender, EventArgs e){
            changeEnabled(5);
            enableDelete();
            labelSelectedStructure.Text = "HASHTABLE";
            output_txt.Clear();
            output_txt.AppendText("Mostrando Tabela Hash...\n");
            ContadorOperacoes.Reset();
            estruturaSelecionada = "Hash";
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir hashDAO
        }

        private void btn_delete_Click(object sender, EventArgs e){
            output_txt.Clear();
            if (this.estruturaSelecionada.Equals("Pilha")){
                output_txt.AppendText("Desempilhando...\n");
                this.pilhaDAO.Desempilhar();
                this.pilhaDAO.SalvarDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
                this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
                ContadorOperacoes.Reset();
            }
            else if(this.estruturaSelecionada.Equals("Fila")){
                output_txt.AppendText("Desenfileirando...\n");
                this.filaDAO.DequeueElement();
                this.filaDAO.SalvarDAO();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();
                this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
                ContadorOperacoes.Reset();
            }
            else if (this.estruturaSelecionada.Equals("Lista")){
                output_txt.AppendText("Removendo linha "+grid_tabelaOutput.CurrentRow.Index+" da Lista...\n");
                this.listaDao.Remover(grid_tabelaOutput.CurrentRow.Index);
                this.pilhaDAO.SalvarDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
                this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
                ContadorOperacoes.Reset();
            }
            else if(this.estruturaSelecionada.Equals("Arvore")){}//TODO: inserir arvoreDAO
            else if(this.estruturaSelecionada.Equals("Hash")){}//TODO: inserir hashDAO
        }

        private void btn_inserir_Click(object sender, EventArgs e){
            output_txt.Clear();
            grid_tabelaOutput.DataSource = null;
            int elemento;
            if (int.TryParse(inserir_txt.Text, out elemento)){
                if (this.estruturaSelecionada.Equals("Pilha")){
                    output_txt.AppendText("Empilhando...\n");
                    this.pilhaDAO.Empilhar(elemento);
                    this.pilhaDAO.SalvarDao();
                    grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
                    output_txt.AppendText("Empilhado!\n");
                    this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
                    ContadorOperacoes.Reset();
                }
                else if(this.estruturaSelecionada.Equals("Fila")) {
                    output_txt.AppendText("Enfileirando...\n");
                    filaDAO.EnqueueElement(elemento);
                    filaDAO.SalvarDAO();
                    grid_tabelaOutput.DataSource = this.filaDAO.Listar().Select(k => new { Valor = k }).ToList();
                    output_txt.AppendText("Enfileirado!\n");
                    this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
                    ContadorOperacoes.Reset();

                }
                else if (this.estruturaSelecionada.Equals("Lista"))
                {
                    output_txt.AppendText("Inserindo elemento "+ elemento +"...\n");
                    this.listaDao.Inserir(elemento);
                    this.listaDao.SalvarDao();
                    grid_tabelaOutput.DataSource = this.listaDao.Listar().Select(k=> new {Valor = k}).ToList();
                    output_txt.AppendText("Elemento inserido!\n");
                    this.output_txt.AppendText("Quantidade de operações: " + ContadorOperacoes.QuantOperacoes + "\n");
                    ContadorOperacoes.Reset();
                }
                else if (this.estruturaSelecionada.Equals("Arvore"))
                {
                }
                else if (this.estruturaSelecionada.Equals("Hash"))
                {
                }
            }
            else{
                output_txt.AppendText("Não é possível inserir elementos não-inteiros!\n");
            }
        }

        private void formStructures_Load(object sender, EventArgs e) {
            disableDelete();
        }

        private void btn_qtde_Click(object sender, EventArgs e) {

        }
    }
}