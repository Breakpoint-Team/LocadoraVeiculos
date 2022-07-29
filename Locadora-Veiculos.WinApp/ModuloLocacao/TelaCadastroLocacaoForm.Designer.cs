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
            this.tabControlLocacao = new System.Windows.Forms.TabControl();
            this.tabPageCliente = new System.Windows.Forms.TabPage();
            this.listBoxCondutores = new System.Windows.Forms.ListBox();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageVeiculo = new System.Windows.Forms.TabPage();
            this.listBoxInformacoesVeiculo = new System.Windows.Forms.ListBox();
            this.comboBoxVeiculos = new System.Windows.Forms.ComboBox();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPagePlanoCobranca = new System.Windows.Forms.TabPage();
            this.listBoxInformacoesPlanoCobranca = new System.Windows.Forms.ListBox();
            this.comboBoxPlanosCobranca = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageTaxas = new System.Windows.Forms.TabPage();
            this.checkedListBoxTaxas = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDataDevolucaoPrevista = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelValorPrevisto = new System.Windows.Forms.Label();
            this.tabControlLocacao.SuspendLayout();
            this.tabPageCliente.SuspendLayout();
            this.tabPageVeiculo.SuspendLayout();
            this.tabPagePlanoCobranca.SuspendLayout();
            this.tabPageTaxas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlLocacao
            // 
            this.tabControlLocacao.Controls.Add(this.tabPageCliente);
            this.tabControlLocacao.Controls.Add(this.tabPageVeiculo);
            this.tabControlLocacao.Controls.Add(this.tabPagePlanoCobranca);
            this.tabControlLocacao.Controls.Add(this.tabPageTaxas);
            this.tabControlLocacao.Location = new System.Drawing.Point(10, 21);
            this.tabControlLocacao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlLocacao.Name = "tabControlLocacao";
            this.tabControlLocacao.SelectedIndex = 0;
            this.tabControlLocacao.Size = new System.Drawing.Size(338, 334);
            this.tabControlLocacao.TabIndex = 2;
            // 
            // tabPageCliente
            // 
            this.tabPageCliente.Controls.Add(this.listBoxCondutores);
            this.tabPageCliente.Controls.Add(this.comboBoxClientes);
            this.tabPageCliente.Controls.Add(this.label3);
            this.tabPageCliente.Location = new System.Drawing.Point(4, 24);
            this.tabPageCliente.Margin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.tabPageCliente.Name = "tabPageCliente";
            this.tabPageCliente.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCliente.Size = new System.Drawing.Size(330, 306);
            this.tabPageCliente.TabIndex = 0;
            this.tabPageCliente.Text = "Cliente";
            this.tabPageCliente.UseVisualStyleBackColor = true;
            // 
            // listBoxCondutores
            // 
            this.listBoxCondutores.AccessibleName = "";
            this.listBoxCondutores.FormattingEnabled = true;
            this.listBoxCondutores.ItemHeight = 15;
            this.listBoxCondutores.Location = new System.Drawing.Point(27, 107);
            this.listBoxCondutores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxCondutores.Name = "listBoxCondutores";
            this.listBoxCondutores.ScrollAlwaysVisible = true;
            this.listBoxCondutores.Size = new System.Drawing.Size(257, 184);
            this.listBoxCondutores.TabIndex = 8;
            this.listBoxCondutores.Tag = "";
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(80, 34);
            this.comboBoxClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(204, 23);
            this.comboBoxClientes.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cliente:";
            // 
            // tabPageVeiculo
            // 
            this.tabPageVeiculo.Controls.Add(this.listBoxInformacoesVeiculo);
            this.tabPageVeiculo.Controls.Add(this.comboBoxVeiculos);
            this.tabPageVeiculo.Controls.Add(this.comboBoxGrupoVeiculos);
            this.tabPageVeiculo.Controls.Add(this.label5);
            this.tabPageVeiculo.Controls.Add(this.label4);
            this.tabPageVeiculo.Location = new System.Drawing.Point(4, 24);
            this.tabPageVeiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageVeiculo.Name = "tabPageVeiculo";
            this.tabPageVeiculo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageVeiculo.Size = new System.Drawing.Size(330, 306);
            this.tabPageVeiculo.TabIndex = 1;
            this.tabPageVeiculo.Text = "Veículo";
            this.tabPageVeiculo.UseVisualStyleBackColor = true;
            // 
            // listBoxInformacoesVeiculo
            // 
            this.listBoxInformacoesVeiculo.AccessibleName = "";
            this.listBoxInformacoesVeiculo.FormattingEnabled = true;
            this.listBoxInformacoesVeiculo.ItemHeight = 15;
            this.listBoxInformacoesVeiculo.Location = new System.Drawing.Point(28, 122);
            this.listBoxInformacoesVeiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInformacoesVeiculo.Name = "listBoxInformacoesVeiculo";
            this.listBoxInformacoesVeiculo.ScrollAlwaysVisible = true;
            this.listBoxInformacoesVeiculo.Size = new System.Drawing.Size(284, 169);
            this.listBoxInformacoesVeiculo.TabIndex = 10;
            this.listBoxInformacoesVeiculo.Tag = "";
            // 
            // comboBoxVeiculos
            // 
            this.comboBoxVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVeiculos.FormattingEnabled = true;
            this.comboBoxVeiculos.Location = new System.Drawing.Point(114, 69);
            this.comboBoxVeiculos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxVeiculos.Name = "comboBoxVeiculos";
            this.comboBoxVeiculos.Size = new System.Drawing.Size(198, 23);
            this.comboBoxVeiculos.TabIndex = 9;
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(114, 25);
            this.comboBoxGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(198, 23);
            this.comboBoxGrupoVeiculos.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Veículos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grupo de \r\nVeículos:";
            // 
            // tabPagePlanoCobranca
            // 
            this.tabPagePlanoCobranca.Controls.Add(this.listBoxInformacoesPlanoCobranca);
            this.tabPagePlanoCobranca.Controls.Add(this.comboBoxPlanosCobranca);
            this.tabPagePlanoCobranca.Controls.Add(this.label7);
            this.tabPagePlanoCobranca.Location = new System.Drawing.Point(4, 24);
            this.tabPagePlanoCobranca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePlanoCobranca.Name = "tabPagePlanoCobranca";
            this.tabPagePlanoCobranca.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePlanoCobranca.Size = new System.Drawing.Size(330, 306);
            this.tabPagePlanoCobranca.TabIndex = 2;
            this.tabPagePlanoCobranca.Text = "Plano de Cobrança";
            this.tabPagePlanoCobranca.UseVisualStyleBackColor = true;
            // 
            // listBoxInformacoesPlanoCobranca
            // 
            this.listBoxInformacoesPlanoCobranca.AccessibleName = "";
            this.listBoxInformacoesPlanoCobranca.FormattingEnabled = true;
            this.listBoxInformacoesPlanoCobranca.ItemHeight = 15;
            this.listBoxInformacoesPlanoCobranca.Location = new System.Drawing.Point(28, 77);
            this.listBoxInformacoesPlanoCobranca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInformacoesPlanoCobranca.Name = "listBoxInformacoesPlanoCobranca";
            this.listBoxInformacoesPlanoCobranca.ScrollAlwaysVisible = true;
            this.listBoxInformacoesPlanoCobranca.Size = new System.Drawing.Size(281, 214);
            this.listBoxInformacoesPlanoCobranca.TabIndex = 10;
            this.listBoxInformacoesPlanoCobranca.Tag = "";
            // 
            // comboBoxPlanosCobranca
            // 
            this.comboBoxPlanosCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanosCobranca.FormattingEnabled = true;
            this.comboBoxPlanosCobranca.Location = new System.Drawing.Point(114, 34);
            this.comboBoxPlanosCobranca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPlanosCobranca.Name = "comboBoxPlanosCobranca";
            this.comboBoxPlanosCobranca.Size = new System.Drawing.Size(195, 23);
            this.comboBoxPlanosCobranca.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "Plano de \r\nCobrança:";
            // 
            // tabPageTaxas
            // 
            this.tabPageTaxas.Controls.Add(this.checkedListBoxTaxas);
            this.tabPageTaxas.Location = new System.Drawing.Point(4, 24);
            this.tabPageTaxas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTaxas.Name = "tabPageTaxas";
            this.tabPageTaxas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTaxas.Size = new System.Drawing.Size(330, 306);
            this.tabPageTaxas.TabIndex = 3;
            this.tabPageTaxas.Text = "Taxas";
            this.tabPageTaxas.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTaxas
            // 
            this.checkedListBoxTaxas.FormattingEnabled = true;
            this.checkedListBoxTaxas.Location = new System.Drawing.Point(3, 4);
            this.checkedListBoxTaxas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxTaxas.Name = "checkedListBoxTaxas";
            this.checkedListBoxTaxas.Size = new System.Drawing.Size(326, 292);
            this.checkedListBoxTaxas.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data de \r\ndevolução:\r\n";
            // 
            // dateTimePickerDataDevolucaoPrevista
            // 
            this.dateTimePickerDataDevolucaoPrevista.Location = new System.Drawing.Point(94, 374);
            this.dateTimePickerDataDevolucaoPrevista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerDataDevolucaoPrevista.Name = "dateTimePickerDataDevolucaoPrevista";
            this.dateTimePickerDataDevolucaoPrevista.Size = new System.Drawing.Size(249, 23);
            this.dateTimePickerDataDevolucaoPrevista.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(268, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(186, 442);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 8;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(106, 442);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 7;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Valor total previsto:";
            // 
            // labelValorPrevisto
            // 
            this.labelValorPrevisto.AutoSize = true;
            this.labelValorPrevisto.Location = new System.Drawing.Point(132, 413);
            this.labelValorPrevisto.Name = "labelValorPrevisto";
            this.labelValorPrevisto.Size = new System.Drawing.Size(0, 15);
            this.labelValorPrevisto.TabIndex = 11;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 479);
            this.Controls.Add(this.labelValorPrevisto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.dateTimePickerDataDevolucaoPrevista);
            this.Controls.Add(this.tabControlLocacao);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Locação";
            this.tabControlLocacao.ResumeLayout(false);
            this.tabPageCliente.ResumeLayout(false);
            this.tabPageCliente.PerformLayout();
            this.tabPageVeiculo.ResumeLayout(false);
            this.tabPageVeiculo.PerformLayout();
            this.tabPagePlanoCobranca.ResumeLayout(false);
            this.tabPagePlanoCobranca.PerformLayout();
            this.tabPageTaxas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlLocacao;
        private System.Windows.Forms.TabPage tabPageCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageVeiculo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPagePlanoCobranca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPageTaxas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataDevolucaoPrevista;
        private System.Windows.Forms.ListBox listBoxCondutores;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ComboBox comboBoxVeiculos;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.ComboBox comboBoxPlanosCobranca;
        private System.Windows.Forms.ListBox listBoxInformacoesVeiculo;
        private System.Windows.Forms.ListBox listBoxInformacoesPlanoCobranca;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelValorPrevisto;
    }
}