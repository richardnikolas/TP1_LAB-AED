namespace Trabalho_Pratico_AED
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tabelaOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_pilha
            // 
            this.btn_pilha.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_pilha.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_pilha.ForeColor = System.Drawing.Color.White;
            this.btn_pilha.Location = new System.Drawing.Point(8, 83);
            this.btn_pilha.Name = "btn_pilha";
            this.btn_pilha.Size = new System.Drawing.Size(64, 20);
            this.btn_pilha.TabIndex = 0;
            this.btn_pilha.Text = "Pilha";
            this.btn_pilha.UseVisualStyleBackColor = false;
            this.btn_pilha.Click += new System.EventHandler(this.btn_pilha_Click_1);
            // 
            // grid_tabelaOutput
            // 
            this.grid_tabelaOutput.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_tabelaOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_tabelaOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_tabelaOutput.Location = new System.Drawing.Point(6, 19);
            this.grid_tabelaOutput.Name = "grid_tabelaOutput";
            this.grid_tabelaOutput.Size = new System.Drawing.Size(328, 190);
            this.grid_tabelaOutput.TabIndex = 1;
            // 
            // btn_lista
            // 
            this.btn_lista.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_lista.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_lista.ForeColor = System.Drawing.Color.White;
            this.btn_lista.Location = new System.Drawing.Point(78, 83);
            this.btn_lista.Name = "btn_lista";
            this.btn_lista.Size = new System.Drawing.Size(64, 20);
            this.btn_lista.TabIndex = 2;
            this.btn_lista.Text = "Lista";
            this.btn_lista.UseVisualStyleBackColor = false;
            this.btn_lista.Click += new System.EventHandler(this.btn_lista_Click);
            // 
            // btn_fila
            // 
            this.btn_fila.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_fila.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_fila.ForeColor = System.Drawing.Color.White;
            this.btn_fila.Location = new System.Drawing.Point(147, 83);
            this.btn_fila.Name = "btn_fila";
            this.btn_fila.Size = new System.Drawing.Size(64, 20);
            this.btn_fila.TabIndex = 3;
            this.btn_fila.Text = "Fila";
            this.btn_fila.UseVisualStyleBackColor = false;
            this.btn_fila.Click += new System.EventHandler(this.btn_fila_Click);
            // 
            // btn_arvore
            // 
            this.btn_arvore.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_arvore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_arvore.ForeColor = System.Drawing.Color.White;
            this.btn_arvore.Location = new System.Drawing.Point(217, 83);
            this.btn_arvore.Name = "btn_arvore";
            this.btn_arvore.Size = new System.Drawing.Size(64, 20);
            this.btn_arvore.TabIndex = 4;
            this.btn_arvore.Text = "Árvore";
            this.btn_arvore.UseVisualStyleBackColor = false;
            this.btn_arvore.Click += new System.EventHandler(this.btn_arvore_Click);
            // 
            // btn_hash
            // 
            this.btn_hash.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_hash.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_hash.ForeColor = System.Drawing.Color.White;
            this.btn_hash.Location = new System.Drawing.Point(286, 83);
            this.btn_hash.Name = "btn_hash";
            this.btn_hash.Size = new System.Drawing.Size(64, 20);
            this.btn_hash.TabIndex = 5;
            this.btn_hash.Text = "Hash";
            this.btn_hash.UseVisualStyleBackColor = false;
            this.btn_hash.Click += new System.EventHandler(this.btn_hash_Click);
            // 
            // btn_inserir
            // 
            this.btn_inserir.Location = new System.Drawing.Point(514, 339);
            this.btn_inserir.Name = "btn_inserir";
            this.btn_inserir.Size = new System.Drawing.Size(64, 35);
            this.btn_inserir.TabIndex = 6;
            this.btn_inserir.Text = "Inserir";
            this.btn_inserir.UseVisualStyleBackColor = true;
            this.btn_inserir.Click += new System.EventHandler(this.btn_inserir_Click);
            // 
            // inserir_txt
            // 
            this.inserir_txt.Location = new System.Drawing.Point(436, 347);
            this.inserir_txt.Name = "inserir_txt";
            this.inserir_txt.Size = new System.Drawing.Size(73, 20);
            this.inserir_txt.TabIndex = 7;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(367, 339);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(64, 34);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Deletar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // output_txt
            // 
            this.output_txt.BackColor = System.Drawing.Color.RoyalBlue;
            this.output_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_txt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.output_txt.Location = new System.Drawing.Point(6, 18);
            this.output_txt.Name = "output_txt";
            this.output_txt.ReadOnly = true;
            this.output_txt.Size = new System.Drawing.Size(212, 191);
            this.output_txt.TabIndex = 9;
            this.output_txt.Text = "";
            // 
            // btn_ordenar
            // 
            this.btn_ordenar.Location = new System.Drawing.Point(132, 340);
            this.btn_ordenar.Name = "btn_ordenar";
            this.btn_ordenar.Size = new System.Drawing.Size(103, 34);
            this.btn_ordenar.TabIndex = 10;
            this.btn_ordenar.Text = "Ordenar";
            this.btn_ordenar.UseVisualStyleBackColor = true;
            // 
            // btn_qtde
            // 
            this.btn_qtde.Location = new System.Drawing.Point(241, 340);
            this.btn_qtde.Name = "btn_qtde";
            this.btn_qtde.Size = new System.Drawing.Size(103, 34);
            this.btn_qtde.TabIndex = 11;
            this.btn_qtde.Text = "Quantidade de Elementos";
            this.btn_qtde.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(-2, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Manipulador de Estruturas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_tabelaOutput);
            this.groupBox1.Location = new System.Drawing.Point(10, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 215);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualização da estrutura de dados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.output_txt);
            this.groupBox2.Location = new System.Drawing.Point(356, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 215);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro de mudanças";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Selecione uma estrutura de dado:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(601, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_qtde);
            this.Controls.Add(this.btn_ordenar);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.inserir_txt);
            this.Controls.Add(this.btn_inserir);
            this.Controls.Add(this.btn_hash);
            this.Controls.Add(this.btn_arvore);
            this.Controls.Add(this.btn_fila);
            this.Controls.Add(this.btn_lista);
            this.Controls.Add(this.btn_pilha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Manipulador de Estruturas";
            ((System.ComponentModel.ISupportInitialize)(this.grid_tabelaOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
    }
}