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
            ((System.ComponentModel.ISupportInitialize) (this.grid_tabelaOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pilha
            // 
            this.btn_pilha.Location = new System.Drawing.Point(12, 78);
            this.btn_pilha.Name = "btn_pilha";
            this.btn_pilha.Size = new System.Drawing.Size(75, 23);
            this.btn_pilha.TabIndex = 0;
            this.btn_pilha.Text = "Pilha";
            this.btn_pilha.UseVisualStyleBackColor = true;
            this.btn_pilha.Click += new System.EventHandler(this.btn_pilha_Click_1);
            // 
            // grid_tabelaOutput
            // 
            this.grid_tabelaOutput.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_tabelaOutput.Location = new System.Drawing.Point(12, 123);
            this.grid_tabelaOutput.Name = "grid_tabelaOutput";
            this.grid_tabelaOutput.Size = new System.Drawing.Size(399, 235);
            this.grid_tabelaOutput.TabIndex = 1;
            // 
            // btn_lista
            // 
            this.btn_lista.Location = new System.Drawing.Point(93, 78);
            this.btn_lista.Name = "btn_lista";
            this.btn_lista.Size = new System.Drawing.Size(75, 23);
            this.btn_lista.TabIndex = 2;
            this.btn_lista.Text = "Lista";
            this.btn_lista.UseVisualStyleBackColor = true;
            this.btn_lista.Click += new System.EventHandler(this.btn_lista_Click);
            // 
            // btn_fila
            // 
            this.btn_fila.Location = new System.Drawing.Point(174, 78);
            this.btn_fila.Name = "btn_fila";
            this.btn_fila.Size = new System.Drawing.Size(75, 23);
            this.btn_fila.TabIndex = 3;
            this.btn_fila.Text = "Fila";
            this.btn_fila.UseVisualStyleBackColor = true;
            this.btn_fila.Click += new System.EventHandler(this.btn_fila_Click);
            // 
            // btn_arvore
            // 
            this.btn_arvore.Location = new System.Drawing.Point(255, 78);
            this.btn_arvore.Name = "btn_arvore";
            this.btn_arvore.Size = new System.Drawing.Size(75, 23);
            this.btn_arvore.TabIndex = 4;
            this.btn_arvore.Text = "Árvore";
            this.btn_arvore.UseVisualStyleBackColor = true;
            this.btn_arvore.Click += new System.EventHandler(this.btn_arvore_Click);
            // 
            // btn_hash
            // 
            this.btn_hash.Location = new System.Drawing.Point(336, 78);
            this.btn_hash.Name = "btn_hash";
            this.btn_hash.Size = new System.Drawing.Size(75, 23);
            this.btn_hash.TabIndex = 5;
            this.btn_hash.Text = "Hash";
            this.btn_hash.UseVisualStyleBackColor = true;
            this.btn_hash.Click += new System.EventHandler(this.btn_hash_Click);
            // 
            // btn_inserir
            // 
            this.btn_inserir.Location = new System.Drawing.Point(588, 239);
            this.btn_inserir.Name = "btn_inserir";
            this.btn_inserir.Size = new System.Drawing.Size(75, 40);
            this.btn_inserir.TabIndex = 6;
            this.btn_inserir.Text = "Inserir";
            this.btn_inserir.UseVisualStyleBackColor = true;
            this.btn_inserir.Click += new System.EventHandler(this.btn_inserir_Click);
            // 
            // inserir_txt
            // 
            this.inserir_txt.Location = new System.Drawing.Point(497, 248);
            this.inserir_txt.Name = "inserir_txt";
            this.inserir_txt.Size = new System.Drawing.Size(84, 23);
            this.inserir_txt.TabIndex = 7;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(416, 239);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 39);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Deletar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // output_txt
            // 
            this.output_txt.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.output_txt.ForeColor = System.Drawing.SystemColors.Info;
            this.output_txt.Location = new System.Drawing.Point(416, 12);
            this.output_txt.Name = "output_txt";
            this.output_txt.ReadOnly = true;
            this.output_txt.Size = new System.Drawing.Size(247, 220);
            this.output_txt.TabIndex = 9;
            this.output_txt.Text = "";
            // 
            // btn_ordenar
            // 
            this.btn_ordenar.Location = new System.Drawing.Point(12, 363);
            this.btn_ordenar.Name = "btn_ordenar";
            this.btn_ordenar.Size = new System.Drawing.Size(120, 39);
            this.btn_ordenar.TabIndex = 10;
            this.btn_ordenar.Text = "Ordenar";
            this.btn_ordenar.UseVisualStyleBackColor = true;
            // 
            // btn_qtde
            // 
            this.btn_qtde.Location = new System.Drawing.Point(153, 363);
            this.btn_qtde.Name = "btn_qtde";
            this.btn_qtde.Size = new System.Drawing.Size(120, 39);
            this.btn_qtde.TabIndex = 11;
            this.btn_qtde.Text = "Quantidade de Elementos";
            this.btn_qtde.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 422);
            this.Controls.Add(this.btn_qtde);
            this.Controls.Add(this.btn_ordenar);
            this.Controls.Add(this.output_txt);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.inserir_txt);
            this.Controls.Add(this.btn_inserir);
            this.Controls.Add(this.btn_hash);
            this.Controls.Add(this.btn_arvore);
            this.Controls.Add(this.btn_fila);
            this.Controls.Add(this.btn_lista);
            this.Controls.Add(this.grid_tabelaOutput);
            this.Controls.Add(this.btn_pilha);
            this.Name = "Form1";
            this.Text = "Manipulador de Estruturas";
            ((System.ComponentModel.ISupportInitialize) (this.grid_tabelaOutput)).EndInit();
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
    }
}