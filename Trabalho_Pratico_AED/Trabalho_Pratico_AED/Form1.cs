using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_Pratico_AED;
using Trabalho_Pratico_AED.Pilha;

namespace Trabalho_Pratico_AED{
    public partial class Form1 : Form
    {
        public PilhaDAO pilhaDAO;

        //TODO: inserir filaDAO

        //TODO: inserir listaDAO

        //TODO: inserir arvoreDAO

        //TODO: inserir hashDAO
        
        public EnumEstrutura estruturaSelecionada;
        
        public Form1(){
            InitializeComponent();
            this.pilhaDAO = new PilhaDAO(output_txt);
        }

        private void btn_pilha_Click_1(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Pilha...\n");
            grid_tabelaOutput.DataSource = null;
            this.estruturaSelecionada = EnumEstrutura.PILHA;
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
            estruturaSelecionada = EnumEstrutura.LISTA;
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir filaDAO
        }

        private void btn_fila_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Fila...\n");
            estruturaSelecionada = EnumEstrutura.FILA;
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir listaDAO
        }

        private void btn_arvore_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Árvore AVL...\n");
            estruturaSelecionada = EnumEstrutura.ARVORE;
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir arvoreDAO
        }

        private void btn_hash_Click(object sender, EventArgs e){
            output_txt.Clear();
            output_txt.AppendText("Mostrando Tabela Hash...\n");
            estruturaSelecionada = EnumEstrutura.HASH;
            grid_tabelaOutput.DataSource = null;
            //TODO: inserir hashDAO
        }

        private void btn_delete_Click(object sender, EventArgs e){
            output_txt.Clear();
            grid_tabelaOutput.DataSource = null;
            if (this.estruturaSelecionada == EnumEstrutura.PILHA){
                output_txt.AppendText("Desempilhando...\n");
                this.pilhaDAO.Desempilhar();
                this.pilhaDAO.SalvarDao();
                grid_tabelaOutput.DataSource = this.pilhaDAO.Listar().Select(k=> new {Valor = k}).ToList();
            }
            else if(this.estruturaSelecionada==EnumEstrutura.FILA){}//TODO: inserir filaDAO
            else if(this.estruturaSelecionada==EnumEstrutura.LISTA){}//TODO: inserir listaDAO
            else if(this.estruturaSelecionada==EnumEstrutura.ARVORE){}//TODO: inserir arvoreDAO
            else if(this.estruturaSelecionada==EnumEstrutura.HASH){}//TODO: inserir hashDAO
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