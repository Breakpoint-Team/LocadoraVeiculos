namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    partial class ConfiguracaoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGravar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txturlseq = new System.Windows.Forms.TextBox();
            this.txtDiretorioLogs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDataAtualizacao = new System.Windows.Forms.Label();
            this.numPrecoGNV = new System.Windows.Forms.NumericUpDown();
            this.numPrecoGasolina = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPrecoAlcool = new System.Windows.Forms.NumericUpDown();
            this.numPrecoDiesel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGasolina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoAlcool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoDiesel)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(393, 342);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(152, 23);
            this.btnGravar.TabIndex = 1;
            this.btnGravar.Text = "Gravar Configurações";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txturlseq);
            this.tabPage2.Controls.Add(this.txtDiretorioLogs);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(517, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Escrita de Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txturlseq
            // 
            this.txturlseq.Location = new System.Drawing.Point(121, 70);
            this.txturlseq.Name = "txturlseq";
            this.txturlseq.Size = new System.Drawing.Size(227, 23);
            this.txturlseq.TabIndex = 3;
            // 
            // txtDiretorioLogs
            // 
            this.txtDiretorioLogs.Location = new System.Drawing.Point(121, 31);
            this.txtDiretorioLogs.Name = "txtDiretorioLogs";
            this.txtDiretorioLogs.Size = new System.Drawing.Size(227, 23);
            this.txtDiretorioLogs.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "URL de Logs Seq: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Diretório de Logs:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDataAtualizacao);
            this.tabPage1.Controls.Add(this.numPrecoGNV);
            this.tabPage1.Controls.Add(this.numPrecoGasolina);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numPrecoAlcool);
            this.tabPage1.Controls.Add(this.numPrecoDiesel);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preço dos Combustíveis ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDataAtualizacao
            // 
            this.txtDataAtualizacao.AutoSize = true;
            this.txtDataAtualizacao.Location = new System.Drawing.Point(121, 41);
            this.txtDataAtualizacao.Name = "txtDataAtualizacao";
            this.txtDataAtualizacao.Size = new System.Drawing.Size(106, 15);
            this.txtDataAtualizacao.TabIndex = 1;
            this.txtDataAtualizacao.Text = "txtDataAtualizacao";
            // 
            // numPrecoGNV
            // 
            this.numPrecoGNV.DecimalPlaces = 2;
            this.numPrecoGNV.Location = new System.Drawing.Point(107, 168);
            this.numPrecoGNV.Name = "numPrecoGNV";
            this.numPrecoGNV.Size = new System.Drawing.Size(120, 23);
            this.numPrecoGNV.TabIndex = 17;
            // 
            // numPrecoGasolina
            // 
            this.numPrecoGasolina.DecimalPlaces = 2;
            this.numPrecoGasolina.Location = new System.Drawing.Point(107, 81);
            this.numPrecoGasolina.Name = "numPrecoGasolina";
            this.numPrecoGasolina.Size = new System.Drawing.Size(120, 23);
            this.numPrecoGasolina.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Diesel:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "GNV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Gasolina:";
            // 
            // numPrecoAlcool
            // 
            this.numPrecoAlcool.DecimalPlaces = 2;
            this.numPrecoAlcool.Location = new System.Drawing.Point(107, 139);
            this.numPrecoAlcool.Name = "numPrecoAlcool";
            this.numPrecoAlcool.Size = new System.Drawing.Size(120, 23);
            this.numPrecoAlcool.TabIndex = 15;
            // 
            // numPrecoDiesel
            // 
            this.numPrecoDiesel.DecimalPlaces = 2;
            this.numPrecoDiesel.Location = new System.Drawing.Point(107, 110);
            this.numPrecoDiesel.Name = "numPrecoDiesel";
            this.numPrecoDiesel.Size = new System.Drawing.Size(120, 23);
            this.numPrecoDiesel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atualizado em: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Álcool:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 390);
            this.tabControl1.TabIndex = 19;
            // 
            // ConfiguracaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGravar);
            this.Name = "ConfiguracaoControl";
            this.Size = new System.Drawing.Size(574, 390);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGasolina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoAlcool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoDiesel)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txturlseq;
        private System.Windows.Forms.TextBox txtDiretorioLogs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label txtDataAtualizacao;
        private System.Windows.Forms.NumericUpDown numPrecoGNV;
        private System.Windows.Forms.NumericUpDown numPrecoGasolina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPrecoAlcool;
        private System.Windows.Forms.NumericUpDown numPrecoDiesel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
