namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    partial class TelaCadastroPlanoCobrancaForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownDiarioValorKm = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDiarioValorDiario = new System.Windows.Forms.NumericUpDown();
            this.tabPageKmControlado = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownKmControladoLimiteKm = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKmControladoValorKm = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKmControladoValorDiario = new System.Windows.Forms.NumericUpDown();
            this.tabPageKmLivre = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownKmLivreValorDiario = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControlPlanos.SuspendLayout();
            this.tabPageDiario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiarioValorKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiarioValorDiario)).BeginInit();
            this.tabPageKmControlado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmControladoLimiteKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmControladoValorKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmControladoValorDiario)).BeginInit();
            this.tabPageKmLivre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmLivreValorDiario)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPlanos
            // 
            this.tabControlPlanos.Controls.Add(this.tabPageDiario);
            this.tabControlPlanos.Controls.Add(this.tabPageKmControlado);
            this.tabControlPlanos.Controls.Add(this.tabPageKmLivre);
            this.tabControlPlanos.Location = new System.Drawing.Point(15, 55);
            this.tabControlPlanos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPlanos.Name = "tabControlPlanos";
            this.tabControlPlanos.SelectedIndex = 0;
            this.tabControlPlanos.Size = new System.Drawing.Size(241, 141);
            this.tabControlPlanos.TabIndex = 1;
            // 
            // tabPageDiario
            // 
            this.tabPageDiario.Controls.Add(this.label3);
            this.tabPageDiario.Controls.Add(this.label2);
            this.tabPageDiario.Controls.Add(this.numericUpDownDiarioValorKm);
            this.tabPageDiario.Controls.Add(this.numericUpDownDiarioValorDiario);
            this.tabPageDiario.Location = new System.Drawing.Point(4, 24);
            this.tabPageDiario.Margin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.tabPageDiario.Name = "tabPageDiario";
            this.tabPageDiario.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDiario.Size = new System.Drawing.Size(233, 113);
            this.tabPageDiario.TabIndex = 0;
            this.tabPageDiario.Text = "Diário";
            this.tabPageDiario.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor por KM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Valor Díario:";
            // 
            // numericUpDownDiarioValorKm
            // 
            this.numericUpDownDiarioValorKm.DecimalPlaces = 2;
            this.numericUpDownDiarioValorKm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownDiarioValorKm.Location = new System.Drawing.Point(118, 58);
            this.numericUpDownDiarioValorKm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownDiarioValorKm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownDiarioValorKm.Name = "numericUpDownDiarioValorKm";
            this.numericUpDownDiarioValorKm.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownDiarioValorKm.TabIndex = 3;
            this.numericUpDownDiarioValorKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownDiarioValorDiario
            // 
            this.numericUpDownDiarioValorDiario.DecimalPlaces = 2;
            this.numericUpDownDiarioValorDiario.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownDiarioValorDiario.Location = new System.Drawing.Point(118, 31);
            this.numericUpDownDiarioValorDiario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownDiarioValorDiario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownDiarioValorDiario.Name = "numericUpDownDiarioValorDiario";
            this.numericUpDownDiarioValorDiario.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownDiarioValorDiario.TabIndex = 2;
            this.numericUpDownDiarioValorDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageKmControlado
            // 
            this.tabPageKmControlado.Controls.Add(this.label6);
            this.tabPageKmControlado.Controls.Add(this.label5);
            this.tabPageKmControlado.Controls.Add(this.label4);
            this.tabPageKmControlado.Controls.Add(this.numericUpDownKmControladoLimiteKm);
            this.tabPageKmControlado.Controls.Add(this.numericUpDownKmControladoValorKm);
            this.tabPageKmControlado.Controls.Add(this.numericUpDownKmControladoValorDiario);
            this.tabPageKmControlado.Location = new System.Drawing.Point(4, 24);
            this.tabPageKmControlado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageKmControlado.Name = "tabPageKmControlado";
            this.tabPageKmControlado.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageKmControlado.Size = new System.Drawing.Size(233, 113);
            this.tabPageKmControlado.TabIndex = 1;
            this.tabPageKmControlado.Text = "KM Controlado";
            this.tabPageKmControlado.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Limite de KM:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Valor por KM:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Valor Díario:";
            // 
            // numericUpDownKmControladoLimiteKm
            // 
            this.numericUpDownKmControladoLimiteKm.DecimalPlaces = 2;
            this.numericUpDownKmControladoLimiteKm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownKmControladoLimiteKm.Location = new System.Drawing.Point(116, 73);
            this.numericUpDownKmControladoLimiteKm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKmControladoLimiteKm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownKmControladoLimiteKm.Name = "numericUpDownKmControladoLimiteKm";
            this.numericUpDownKmControladoLimiteKm.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownKmControladoLimiteKm.TabIndex = 5;
            this.numericUpDownKmControladoLimiteKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownKmControladoValorKm
            // 
            this.numericUpDownKmControladoValorKm.DecimalPlaces = 2;
            this.numericUpDownKmControladoValorKm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownKmControladoValorKm.Location = new System.Drawing.Point(116, 46);
            this.numericUpDownKmControladoValorKm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKmControladoValorKm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownKmControladoValorKm.Name = "numericUpDownKmControladoValorKm";
            this.numericUpDownKmControladoValorKm.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownKmControladoValorKm.TabIndex = 4;
            this.numericUpDownKmControladoValorKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownKmControladoValorDiario
            // 
            this.numericUpDownKmControladoValorDiario.DecimalPlaces = 2;
            this.numericUpDownKmControladoValorDiario.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownKmControladoValorDiario.Location = new System.Drawing.Point(116, 19);
            this.numericUpDownKmControladoValorDiario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKmControladoValorDiario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownKmControladoValorDiario.Name = "numericUpDownKmControladoValorDiario";
            this.numericUpDownKmControladoValorDiario.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownKmControladoValorDiario.TabIndex = 3;
            this.numericUpDownKmControladoValorDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageKmLivre
            // 
            this.tabPageKmLivre.Controls.Add(this.label7);
            this.tabPageKmLivre.Controls.Add(this.numericUpDownKmLivreValorDiario);
            this.tabPageKmLivre.Location = new System.Drawing.Point(4, 24);
            this.tabPageKmLivre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageKmLivre.Name = "tabPageKmLivre";
            this.tabPageKmLivre.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageKmLivre.Size = new System.Drawing.Size(233, 113);
            this.tabPageKmLivre.TabIndex = 2;
            this.tabPageKmLivre.Text = "KM Livre";
            this.tabPageKmLivre.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Valor Díario:";
            // 
            // numericUpDownKmLivreValorDiario
            // 
            this.numericUpDownKmLivreValorDiario.DecimalPlaces = 2;
            this.numericUpDownKmLivreValorDiario.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownKmLivreValorDiario.Location = new System.Drawing.Point(118, 41);
            this.numericUpDownKmLivreValorDiario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKmLivreValorDiario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownKmLivreValorDiario.Name = "numericUpDownKmLivreValorDiario";
            this.numericUpDownKmLivreValorDiario.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownKmLivreValorDiario.TabIndex = 4;
            this.numericUpDownKmLivreValorDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupo de Veículos: ";
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(126, 27);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(130, 23);
            this.comboBoxGrupoVeiculos.TabIndex = 0;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(19, 201);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 2;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(100, 201);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(181, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroPlanoCobrancaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 243);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.comboBoxGrupoVeiculos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlPlanos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroPlanoCobrancaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Plano de Cobrança";
            this.tabControlPlanos.ResumeLayout(false);
            this.tabPageDiario.ResumeLayout(false);
            this.tabPageDiario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiarioValorKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiarioValorDiario)).EndInit();
            this.tabPageKmControlado.ResumeLayout(false);
            this.tabPageKmControlado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmControladoLimiteKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmControladoValorKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmControladoValorDiario)).EndInit();
            this.tabPageKmLivre.ResumeLayout(false);
            this.tabPageKmLivre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKmLivreValorDiario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlanos;
        private System.Windows.Forms.TabPage tabPageDiario;
        private System.Windows.Forms.TabPage tabPageKmControlado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownDiarioValorDiario;
        private System.Windows.Forms.TabPage tabPageKmLivre;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownDiarioValorKm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownKmControladoLimiteKm;
        private System.Windows.Forms.NumericUpDown numericUpDownKmControladoValorKm;
        private System.Windows.Forms.NumericUpDown numericUpDownKmControladoValorDiario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownKmLivreValorDiario;
    }
}