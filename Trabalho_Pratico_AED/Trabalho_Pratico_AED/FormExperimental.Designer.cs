namespace Trabalho_Pratico_AED {
    partial class FormExperimental {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cBoxEstruturas = new System.Windows.Forms.ComboBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxExibicao = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(539, 12);
            this.txtNumero.MaxLength = 5;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(81, 20);
            this.txtNumero.TabIndex = 0;
            // 
            // cBoxEstruturas
            // 
            this.cBoxEstruturas.FormattingEnabled = true;
            this.cBoxEstruturas.Items.AddRange(new object[] {
            "Pilha",
            "Fila",
            "Lista",
            "Árvore",
            "Hashtable"});
            this.cBoxEstruturas.Location = new System.Drawing.Point(539, 43);
            this.cBoxEstruturas.Name = "cBoxEstruturas";
            this.cBoxEstruturas.Size = new System.Drawing.Size(81, 21);
            this.cBoxEstruturas.TabIndex = 1;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(539, 70);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(81, 23);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Novo número:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(428, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Estrutura de dados:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 255);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estruturas de dados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selecione a estrutura de exibição:";
            // 
            // cBoxExibicao
            // 
            this.cBoxExibicao.FormattingEnabled = true;
            this.cBoxExibicao.Items.AddRange(new object[] {
            "Pilha",
            "Fila",
            "Lista",
            "Árvore",
            "Hashtable"});
            this.cBoxExibicao.Location = new System.Drawing.Point(185, 273);
            this.cBoxExibicao.Name = "cBoxExibicao";
            this.cBoxExibicao.Size = new System.Drawing.Size(81, 21);
            this.cBoxExibicao.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // FormExperimental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 310);
            this.Controls.Add(this.cBoxExibicao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.cBoxEstruturas);
            this.Controls.Add(this.txtNumero);
            this.Name = "FormExperimental";
            this.Text = "FormExperimental";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.ComboBox cBoxEstruturas;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxExibicao;
    }
}