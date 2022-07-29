namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
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
            this.tabControlPlanos = new System.Windows.Forms.TabControl();
            this.tabPageDiario = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageKmControlado = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageKmLivre = new System.Windows.Forms.TabPage();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.tabControlPlanos.SuspendLayout();
            this.tabPageDiario.SuspendLayout();
            this.tabPageKmControlado.SuspendLayout();
            this.tabPageKmLivre.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPlanos
            // 
            this.tabControlPlanos.Controls.Add(this.tabPageDiario);
            this.tabControlPlanos.Controls.Add(this.tabPageKmControlado);
            this.tabControlPlanos.Controls.Add(this.tabPageKmLivre);
            this.tabControlPlanos.Controls.Add(this.tabPage1);
            this.tabControlPlanos.Location = new System.Drawing.Point(12, 28);
            this.tabControlPlanos.Name = "tabControlPlanos";
            this.tabControlPlanos.SelectedIndex = 0;
            this.tabControlPlanos.Size = new System.Drawing.Size(386, 445);
            this.tabControlPlanos.TabIndex = 2;
            // 
            // tabPageDiario
            // 
            this.tabPageDiario.Controls.Add(this.listBox1);
            this.tabPageDiario.Controls.Add(this.comboBox1);
            this.tabPageDiario.Controls.Add(this.label3);
            this.tabPageDiario.Location = new System.Drawing.Point(4, 29);
            this.tabPageDiario.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tabPageDiario.Name = "tabPageDiario";
            this.tabPageDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiario.Size = new System.Drawing.Size(378, 412);
            this.tabPageDiario.TabIndex = 0;
            this.tabPageDiario.Text = "Cliente";
            this.tabPageDiario.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.AccessibleName = "";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(31, 183);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(292, 204);
            this.listBox1.TabIndex = 8;
            this.listBox1.Tag = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(130, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 28);
            this.comboBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cliente:";
            // 
            // tabPageKmControlado
            // 
            this.tabPageKmControlado.Controls.Add(this.listBox2);
            this.tabPageKmControlado.Controls.Add(this.comboBox3);
            this.tabPageKmControlado.Controls.Add(this.comboBox2);
            this.tabPageKmControlado.Controls.Add(this.label5);
            this.tabPageKmControlado.Controls.Add(this.label4);
            this.tabPageKmControlado.Location = new System.Drawing.Point(4, 29);
            this.tabPageKmControlado.Name = "tabPageKmControlado";
            this.tabPageKmControlado.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKmControlado.Size = new System.Drawing.Size(378, 412);
            this.tabPageKmControlado.TabIndex = 1;
            this.tabPageKmControlado.Text = "Veículo";
            this.tabPageKmControlado.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(130, 122);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(194, 28);
            this.comboBox3.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(130, 45);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(194, 28);
            this.comboBox2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Veículos";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grupo de \r\nVeículos:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tabPageKmLivre
            // 
            this.tabPageKmLivre.Controls.Add(this.listBox3);
            this.tabPageKmLivre.Controls.Add(this.comboBox4);
            this.tabPageKmLivre.Controls.Add(this.label7);
            this.tabPageKmLivre.Location = new System.Drawing.Point(4, 29);
            this.tabPageKmLivre.Name = "tabPageKmLivre";
            this.tabPageKmLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKmLivre.Size = new System.Drawing.Size(378, 412);
            this.tabPageKmLivre.TabIndex = 2;
            this.tabPageKmLivre.Text = "Plano de Cobrança";
            this.tabPageKmLivre.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(130, 45);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(194, 28);
            this.comboBox4.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 40);
            this.label7.TabIndex = 5;
            this.label7.Text = "Plano de \r\nCobrança:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkedListBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(378, 412);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Taxas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data de \r\ndevolução:\r\n";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(107, 498);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(284, 27);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(309, 569);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 31);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(217, 569);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(86, 31);
            this.btnLimpar.TabIndex = 8;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(125, 569);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(86, 31);
            this.btnGravar.TabIndex = 7;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.AccessibleName = "";
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(32, 183);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(292, 204);
            this.listBox2.TabIndex = 10;
            this.listBox2.Tag = "";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(372, 400);
            this.checkedListBox1.TabIndex = 0;
            // 
            // listBox3
            // 
            this.listBox3.AccessibleName = "";
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(32, 183);
            this.listBox3.Name = "listBox3";
            this.listBox3.ScrollAlwaysVisible = true;
            this.listBox3.Size = new System.Drawing.Size(292, 204);
            this.listBox3.TabIndex = 10;
            this.listBox3.Tag = "";
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 609);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tabControlPlanos);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.ShowIcon = false;
            this.Text = "Cadastro de Locação";
            this.Load += new System.EventHandler(this.TelaCadastroLocacaoForm_Load);
            this.tabControlPlanos.ResumeLayout(false);
            this.tabPageDiario.ResumeLayout(false);
            this.tabPageDiario.PerformLayout();
            this.tabPageKmControlado.ResumeLayout(false);
            this.tabPageKmControlado.PerformLayout();
            this.tabPageKmLivre.ResumeLayout(false);
            this.tabPageKmLivre.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlanos;
        private System.Windows.Forms.TabPage tabPageDiario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageKmControlado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageKmLivre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}