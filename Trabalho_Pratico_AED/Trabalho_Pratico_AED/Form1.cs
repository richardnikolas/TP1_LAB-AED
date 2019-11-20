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
using VS_Code;

namespace Trabalho_Pratico_AED{
    public partial class Form1 : Form{
        /*
         * Classe controladora do formulário.
         *
         * Design: Philemon da Silva Souza
         * Lógica: Philemon da Silva Souza
         * Classes: Adicionadas do exercício de AED's passado na mesma semana.
         *          (créditos individuais podem ser encontrados na classe)
         * Documentação: Richard Nikolas e André Valentim
         * 
         */
        public PilhaDAO pilhaDAO;

        //TODO: inserir filaDAO

        public ListaDAO listaDao;

        //TODO: inserir arvoreDAO

        //TODO: inserir hashDAO
        
        public string estruturaSelecionada;
        
        public Form1(){
            InitializeComponent();
            this.pilhaDAO = new PilhaDAO(output_txt);
            this.listaDao = new ListaDAO(output_txt);
        }

        private void btn_pilha_Click_1(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Pilha...\n");
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
        }

        private void btn_lista_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Lista...\n");
            estruturaSelecionada = "Lista";
            grid_tabelaOutput.DataSource = null;
            try{
                this.pilhaDAO.CarregarDao();
            }
            catch (Exception ex){
                this.output_txt.AppendText("Falha ao carregar ListaDAO!\n ");
                this.output_txt.AppendText("Excessão: \n "+ ex.Message+"\n Local : \n"+ ex.Source +"\n");
            }
            grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            this.output_txt.AppendText("DAO Carregado!\n ");
        }

        private void btn_fila_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Fila...\n");
            estruturaSelecionada = "Fila";
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir filaDAO
        }

        private void btn_arvore_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Árvore AVL...\n");
            estruturaSelecionada = "Arvore";
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir arvoreDAO
        }

        private void btn_hash_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Tabela Hash...\n");
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
            }
            else if(this.estruturaSelecionada.Equals("Fila")){}//TODO: inserir filaDAO
            else if (this.estruturaSelecionada.Equals("Lista")){
                output_txt.AppendText("Removendo linha "+grid_tabelaOutput.CurrentRow.Index+" da Lista...\n");
                this.listaDao.Remover(grid_tabelaOutput.CurrentRow.Index);
                this.pilhaDAO.SalvarDao();
                grid_tabelaOutput.DataSource = null;
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            }
            else if(this.estruturaSelecionada.Equals("Arvore")){}//TODO: inserir arvoreDAO
            else if(this.estruturaSelecionada.Equals("Hash")){}//TODO: inserir hashDAO
        }

        private void btn_inserir_Click(object sender, EventArgs e){
            output_txt.Clear();
            grid_tabelaOutput.DataSource = null;
            int elemento;
            if (int.TryParse(inserir_txt.Text, out elemento)){
                output_txt.AppendText("Empilhando...\n");
                this.pilhaDAO.Empilhar(elemento);
                this.pilhaDAO.SalvarDao();
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
                output_txt.AppendText("Empilhado!\n");
            }
            else{
                output_txt.AppendText("Não é possível inserir elementos não-inteiros!\n");
            }
        }
    }
}