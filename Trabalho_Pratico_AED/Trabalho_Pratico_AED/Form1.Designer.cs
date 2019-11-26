namespace Trabalho_Pratico_AED
{
    partial class formStructures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_pilha = new System.Windows.Forms.Button();
            this.grid_tabelaOutput = new System.Windows.Forms.DataGridView();
            this.btn_lista = new System.Windows.Forms.Button();
            this.btn_fila = new System.Windows.Forms.Button();
            this.btn_arvore = new System.Windows.Forms.Button();
            this.btn_hash = new System.Windows.Forms.Button();
            this.btn_inserir = new System.Windows.Forms.Button();
            this.inserir_txt = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.output_txt = new System.Windows.Forms.RichTextBox();
            this.btn_ordenar = new System.Windows.Forms.Button();
            this.btn_qtde = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSelectedStructure = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tabelaOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_pilha
            // 
            this.btn_pilha.BackColor = System.Drawing.Color.DarkGray;
            this.btn_pilha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_pilha.ForeColor = System.Drawing.Color.Black;
            this.btn_pilha.Location = new System.Drawing.Point(6, 16);
            this.btn_pilha.Name = "btn_pilha";
            this.btn_pilha.Size = new System.Drawing.Size(64, 20);
            this.btn_pilha.TabIndex = 0;
            this.btn_pilha.TabStop = false;
            this.btn_pilha.Text = "Pilha";
            this.btn_pilha.UseVisualStyleBackColor = false;
            this.btn_pilha.Click += new System.EventHandler(this.btn_pilha_Click_1);
            // 
            // grid_tabelaOutput
            // 
            this.grid_tabelaOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_tabelaOutput.BackgroundColor = System.Drawing.Color.DimGray;
            this.grid_tabelaOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_tabelaOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_tabelaOutput.Location = new System.Drawing.Point(6, 19);
            this.grid_tabelaOutput.Name = "grid_tabelaOutput";
            this.grid_tabelaOutput.Size = new System.Drawing.Size(196, 346);
            this.grid_tabelaOutput.TabIndex = 1;
            // 
            // btn_lista
            // 
            this.btn_lista.BackColor = System.Drawing.Color.DarkGray;
            this.btn_lista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_lista.ForeColor = System.Drawing.Color.Black;
            this.btn_lista.Location = new System.Drawing.Point(76, 16);
            this.btn_lista.Name = "btn_lista";
            this.btn_lista.Size = new System.Drawing.Size(64, 20);
            this.btn_lista.TabIndex = 2;
            this.btn_lista.TabStop = false;
            this.btn_lista.Text = "Lista";
            this.btn_lista.UseVisualStyleBackColor = false;
            this.btn_lista.Click += new System.EventHandler(this.btn_lista_Click);
            // 
            // btn_fila
            // 
            this.btn_fila.BackColor = System.Drawing.Color.DarkGray;
            this.btn_fila.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_fila.ForeColor = System.Drawing.Color.Black;
            this.btn_fila.Location = new System.Drawing.Point(145, 16);
            this.btn_fila.Name = "btn_fila";
            this.btn_fila.Size = new System.Drawing.Size(64, 20);
            this.btn_fila.TabIndex = 3;
            this.btn_fila.TabStop = false;
            this.btn_fila.Text = "Fila";
            this.btn_fila.UseVisualStyleBackColor = false;
            this.btn_fila.Click += new System.EventHandler(this.btn_fila_Click);
            // 
            // btn_arvore
            // 
            this.btn_arvore.BackColor = System.Drawing.Color.DarkGray;
            this.btn_arvore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_arvore.ForeColor = System.Drawing.Color.Black;
            this.btn_arvore.Location = new System.Drawing.Point(214, 16);
            this.btn_arvore.Name = "btn_arvore";
            this.btn_arvore.Size = new System.Drawing.Size(64, 20);
            this.btn_arvore.TabIndex = 4;
            this.btn_arvore.TabStop = false;
            this.btn_arvore.Text = "Árvore";
            this.btn_arvore.UseVisualStyleBackColor = false;
            this.btn_arvore.Click += new System.EventHandler(this.btn_arvore_Click);
            // 
            // btn_hash
            // 
            this.btn_hash.BackColor = System.Drawing.Color.DarkGray;
            this.btn_hash.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_hash.ForeColor = System.Drawing.Color.Black;
            this.btn_hash.Location = new System.Drawing.Point(284, 16);
            this.btn_hash.Name = "btn_hash";
            this.btn_hash.Size = new System.Drawing.Size(64, 20);
            this.btn_hash.TabIndex = 5;
            this.btn_hash.TabStop = false;
            this.btn_hash.Text = "Hash";
            this.btn_hash.UseVisualStyleBackColor = false;
            this.btn_hash.Click += new System.EventHandler(this.btn_hash_Click);
            // 
            // btn_inserir
            // 
            this.btn_inserir.Location = new System.Drawing.Point(121, 16);
            this.btn_inserir.Name = "btn_inserir";
            this.btn_inserir.Size = new System.Drawing.Size(64, 21);
            this.btn_inserir.TabIndex = 6;
            this.btn_inserir.TabStop = false;
            this.btn_inserir.Text = "Inserir";
            this.btn_inserir.UseVisualStyleBackColor = true;
            this.btn_inserir.Click += new System.EventHandler(this.btn_inserir_Click);
            // 
            // inserir_txt
            // 
            this.inserir_txt.Location = new System.Drawing.Point(42, 17);
            this.inserir_txt.Name = "inserir_txt";
            this.inserir_txt.Size = new System.Drawing.Size(73, 20);
            this.inserir_txt.TabIndex = 30;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(42, 43);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(143, 21);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.TabStop = false;
            this.btn_delete.Text = "Deletar Selecionado";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // output_txt
            // 
            this.output_txt.BackColor = System.Drawing.Color.Indigo;
            this.output_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_txt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.output_txt.Location = new System.Drawing.Point(6, 18);
            this.output_txt.Name = "output_txt";
            this.output_txt.ReadOnly = true;
            this.output_txt.Size = new System.Drawing.Size(212, 347);
            this.output_txt.TabIndex = 9;
            this.output_txt.Text = "";
            // 
            // btn_ordenar
            // 
            this.btn_ordenar.Location = new System.Drawing.Point(10, 54);
            this.btn_ordenar.Name = "btn_ordenar";
            this.btn_ordenar.Size = new System.Drawing.Size(123, 21);
            this.btn_ordenar.TabIndex = 10;
            this.btn_ordenar.TabStop = false;
            this.btn_ordenar.Text = "Ordenar";
            this.btn_ordenar.UseVisualStyleBackColor = true;
            this.btn_ordenar.Click += new System.EventHandler(this.Btn_ordenar_Click);
            // 
            // btn_qtde
            // 
            this.btn_qtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_qtde.Location = new System.Drawing.Point(10, 81);
            this.btn_qtde.Name = "btn_qtde";
            this.btn_qtde.Size = new System.Drawing.Size(123, 50);
            this.btn_qtde.TabIndex = 11;
            this.btn_qtde.TabStop = false;
            this.btn_qtde.Text = "Quantidade de Elementos";
            this.btn_qtde.UseVisualStyleBackColor = true;
            this.btn_qtde.Click += new System.EventHandler(this.btn_qtde_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(-2, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Algoritmos e Estruturas de Dados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_tabelaOutput);
            this.groupBox1.Location = new System.Drawing.Point(155, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 373);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualização da estrutura de dados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.output_txt);
            this.groupBox2.Location = new System.Drawing.Point(373, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 373);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registros";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_limpar);
            this.groupBox3.Controls.Add(this.btn_ordenar);
            this.groupBox3.Controls.Add(this.btn_qtde);
            this.groupBox3.Location = new System.Drawing.Point(10, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 373);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Painel de controle";
            // 
            // btn_limpar
            // 
            this.btn_limpar.Location = new System.Drawing.Point(10, 27);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(123, 21);
            this.btn_limpar.TabIndex = 2;
            this.btn_limpar.TabStop = false;
            this.btn_limpar.Text = "Limpar ";
            this.btn_limpar.UseVisualStyleBackColor = true;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_pilha);
            this.groupBox4.Controls.Add(this.btn_lista);
            this.groupBox4.Controls.Add(this.btn_fila);
            this.groupBox4.Controls.Add(this.btn_arvore);
            this.groupBox4.Controls.Add(this.btn_hash);
            this.groupBox4.Location = new System.Drawing.Point(10, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 45);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selecione a estrutura de dados:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.inserir_txt);
            this.groupBox5.Controls.Add(this.btn_inserir);
            this.groupBox5.Controls.Add(this.btn_delete);
            this.groupBox5.Location = new System.Drawing.Point(373, 36);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(221, 75);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Inserir números";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Estrutura Atual:";
            // 
            // labelSelectedStructure
            // 
            this.labelSelectedStructure.BackColor = System.Drawing.Color.Indigo;
            this.labelSelectedStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedStructure.ForeColor = System.Drawing.SystemColors.Control;
            this.labelSelectedStructure.Location = new System.Drawing.Point(90, 86);
            this.labelSelectedStructure.Name = "labelSelectedStructure";
            this.labelSelectedStructure.Size = new System.Drawing.Size(267, 23);
            this.labelSelectedStructure.TabIndex = 19;
            this.labelSelectedStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formStructures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 494);
            this.Controls.Add(this.labelSelectedStructure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formStructures";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AED";
            this.Load += new System.EventHandler(this.formStructures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_tabelaOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pilha;
        private System.Windows.Forms.Button btn_lista;
        private System.Windows.Forms.Button btn_arvore;
        private System.Windows.Forms.Button btn_fila;
        private System.Windows.Forms.Button btn_inserir;
        private System.Windows.Forms.Button btn_hash;
        private System.Windows.Forms.Button btn_ordenar;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_qtde;
        private System.Windows.Forms.RichTextBox output_txt;
        private System.Windows.Forms.TextBox inserir_txt;
        private System.Windows.Forms.DataGridView grid_tabelaOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSelectedStructure;
        private System.Windows.Forms.Button btn_limpar;
    }
}