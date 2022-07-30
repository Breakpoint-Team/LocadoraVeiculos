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
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxCondutores = new System.Windows.Forms.ComboBox();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageVeiculo = new System.Windows.Forms.TabPage();
            this.labelKmInicial = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelPlaca = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelModelo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVeiculos = new System.Windows.Forms.ComboBox();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPagePlanoCobranca = new System.Windows.Forms.TabPage();
            this.labelKmLivreValorDia = new System.Windows.Forms.Label();
            this.labelKmControladoLimiteKm = new System.Windows.Forms.Label();
            this.labelKmControladoValorKm = new System.Windows.Forms.Label();
            this.labelKmControladoValorDia = new System.Windows.Forms.Label();
            this.labelDiarioValorKm = new System.Windows.Forms.Label();
            this.labelDiarioValorDia = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButtonKmLivre = new System.Windows.Forms.RadioButton();
            this.radioButtonKmControlado = new System.Windows.Forms.RadioButton();
            this.radioButtonPlanoDiario = new System.Windows.Forms.RadioButton();
            this.labelGrupoVeiculos = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
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
            this.tabPageCliente.Controls.Add(this.label18);
            this.tabPageCliente.Controls.Add(this.comboBoxCondutores);
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 152);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 15);
            this.label18.TabIndex = 9;
            this.label18.Text = "Condutor:";
            // 
            // comboBoxCondutores
            // 
            this.comboBoxCondutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCondutores.FormattingEnabled = true;
            this.comboBoxCondutores.Location = new System.Drawing.Point(80, 144);
            this.comboBoxCondutores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCondutores.Name = "comboBoxCondutores";
            this.comboBoxCondutores.Size = new System.Drawing.Size(225, 23);
            this.comboBoxCondutores.TabIndex = 8;
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(80, 111);
            this.comboBoxClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(225, 23);
            this.comboBoxClientes.TabIndex = 7;
            this.comboBoxClientes.SelectedIndexChanged += new System.EventHandler(this.comboBoxClientes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cliente:";
            // 
            // tabPageVeiculo
            // 
            this.tabPageVeiculo.Controls.Add(this.labelKmInicial);
            this.tabPageVeiculo.Controls.Add(this.label17);
            this.tabPageVeiculo.Controls.Add(this.pictureBoxImagem);
            this.tabPageVeiculo.Controls.Add(this.label8);
            this.tabPageVeiculo.Controls.Add(this.labelPlaca);
            this.tabPageVeiculo.Controls.Add(this.label10);
            this.tabPageVeiculo.Controls.Add(this.labelModelo);
            this.tabPageVeiculo.Controls.Add(this.label6);
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
            // labelKmInicial
            // 
            this.labelKmInicial.AutoSize = true;
            this.labelKmInicial.Location = new System.Drawing.Point(112, 93);
            this.labelKmInicial.Name = "labelKmInicial";
            this.labelKmInicial.Size = new System.Drawing.Size(0, 15);
            this.labelKmInicial.TabIndex = 24;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 93);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 15);
            this.label17.TabIndex = 23;
            this.label17.Text = "Km inicial:";
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxImagem.Location = new System.Drawing.Point(114, 187);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(198, 114);
            this.pictureBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagem.TabIndex = 22;
            this.pictureBoxImagem.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "Imagem: ";
            // 
            // labelPlaca
            // 
            this.labelPlaca.AutoSize = true;
            this.labelPlaca.Location = new System.Drawing.Point(112, 152);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(0, 15);
            this.labelPlaca.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Placa:";
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(112, 123);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(0, 15);
            this.labelModelo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Modelo:";
            // 
            // comboBoxVeiculos
            // 
            this.comboBoxVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVeiculos.FormattingEnabled = true;
            this.comboBoxVeiculos.Location = new System.Drawing.Point(114, 57);
            this.comboBoxVeiculos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxVeiculos.Name = "comboBoxVeiculos";
            this.comboBoxVeiculos.Size = new System.Drawing.Size(198, 23);
            this.comboBoxVeiculos.TabIndex = 9;
            this.comboBoxVeiculos.SelectedIndexChanged += new System.EventHandler(this.comboBoxVeiculos_SelectedIndexChanged);
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
            this.comboBoxGrupoVeiculos.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrupoVeiculos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 65);
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
            this.tabPagePlanoCobranca.Controls.Add(this.labelKmLivreValorDia);
            this.tabPagePlanoCobranca.Controls.Add(this.labelKmControladoLimiteKm);
            this.tabPagePlanoCobranca.Controls.Add(this.labelKmControladoValorKm);
            this.tabPagePlanoCobranca.Controls.Add(this.labelKmControladoValorDia);
            this.tabPagePlanoCobranca.Controls.Add(this.labelDiarioValorKm);
            this.tabPagePlanoCobranca.Controls.Add(this.labelDiarioValorDia);
            this.tabPagePlanoCobranca.Controls.Add(this.label16);
            this.tabPagePlanoCobranca.Controls.Add(this.label15);
            this.tabPagePlanoCobranca.Controls.Add(this.label14);
            this.tabPagePlanoCobranca.Controls.Add(this.label13);
            this.tabPagePlanoCobranca.Controls.Add(this.label12);
            this.tabPagePlanoCobranca.Controls.Add(this.label7);
            this.tabPagePlanoCobranca.Controls.Add(this.label11);
            this.tabPagePlanoCobranca.Controls.Add(this.radioButtonKmLivre);
            this.tabPagePlanoCobranca.Controls.Add(this.radioButtonKmControlado);
            this.tabPagePlanoCobranca.Controls.Add(this.radioButtonPlanoDiario);
            this.tabPagePlanoCobranca.Controls.Add(this.labelGrupoVeiculos);
            this.tabPagePlanoCobranca.Controls.Add(this.label9);
            this.tabPagePlanoCobranca.Location = new System.Drawing.Point(4, 24);
            this.tabPagePlanoCobranca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePlanoCobranca.Name = "tabPagePlanoCobranca";
            this.tabPagePlanoCobranca.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePlanoCobranca.Size = new System.Drawing.Size(330, 306);
            this.tabPagePlanoCobranca.TabIndex = 2;
            this.tabPagePlanoCobranca.Text = "Plano de Cobrança";
            this.tabPagePlanoCobranca.UseVisualStyleBackColor = true;
            // 
            // labelKmLivreValorDia
            // 
            this.labelKmLivreValorDia.AutoSize = true;
            this.labelKmLivreValorDia.Location = new System.Drawing.Point(211, 260);
            this.labelKmLivreValorDia.Name = "labelKmLivreValorDia";
            this.labelKmLivreValorDia.Size = new System.Drawing.Size(0, 15);
            this.labelKmLivreValorDia.TabIndex = 28;
            // 
            // labelKmControladoLimiteKm
            // 
            this.labelKmControladoLimiteKm.AutoSize = true;
            this.labelKmControladoLimiteKm.Location = new System.Drawing.Point(211, 220);
            this.labelKmControladoLimiteKm.Name = "labelKmControladoLimiteKm";
            this.labelKmControladoLimiteKm.Size = new System.Drawing.Size(0, 15);
            this.labelKmControladoLimiteKm.TabIndex = 27;
            // 
            // labelKmControladoValorKm
            // 
            this.labelKmControladoValorKm.AutoSize = true;
            this.labelKmControladoValorKm.Location = new System.Drawing.Point(211, 194);
            this.labelKmControladoValorKm.Name = "labelKmControladoValorKm";
            this.labelKmControladoValorKm.Size = new System.Drawing.Size(0, 15);
            this.labelKmControladoValorKm.TabIndex = 26;
            // 
            // labelKmControladoValorDia
            // 
            this.labelKmControladoValorDia.AutoSize = true;
            this.labelKmControladoValorDia.Location = new System.Drawing.Point(211, 168);
            this.labelKmControladoValorDia.Name = "labelKmControladoValorDia";
            this.labelKmControladoValorDia.Size = new System.Drawing.Size(0, 15);
            this.labelKmControladoValorDia.TabIndex = 25;
            // 
            // labelDiarioValorKm
            // 
            this.labelDiarioValorKm.AutoSize = true;
            this.labelDiarioValorKm.Location = new System.Drawing.Point(211, 128);
            this.labelDiarioValorKm.Name = "labelDiarioValorKm";
            this.labelDiarioValorKm.Size = new System.Drawing.Size(0, 15);
            this.labelDiarioValorKm.TabIndex = 24;
            // 
            // labelDiarioValorDia
            // 
            this.labelDiarioValorDia.AutoSize = true;
            this.labelDiarioValorDia.Location = new System.Drawing.Point(211, 102);
            this.labelDiarioValorDia.Name = "labelDiarioValorDia";
            this.labelDiarioValorDia.Size = new System.Drawing.Size(0, 15);
            this.labelDiarioValorDia.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(119, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 15);
            this.label16.TabIndex = 22;
            this.label16.Text = "Valor por dia:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(119, 220);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 15);
            this.label15.TabIndex = 21;
            this.label15.Text = "Limite de Km:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(119, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = "Valor por Km:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(119, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 19;
            this.label13.Text = "Valor por dia:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Valor por Km:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Valor por dia:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(213, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "Seleione um dos tipos de plano abaixo:";
            // 
            // radioButtonKmLivre
            // 
            this.radioButtonKmLivre.AutoSize = true;
            this.radioButtonKmLivre.Enabled = false;
            this.radioButtonKmLivre.Location = new System.Drawing.Point(69, 238);
            this.radioButtonKmLivre.Name = "radioButtonKmLivre";
            this.radioButtonKmLivre.Size = new System.Drawing.Size(68, 19);
            this.radioButtonKmLivre.TabIndex = 15;
            this.radioButtonKmLivre.Text = "Km livre";
            this.radioButtonKmLivre.UseVisualStyleBackColor = true;
            this.radioButtonKmLivre.CheckedChanged += new System.EventHandler(this.radioButtonKmLivre_CheckedChanged);
            // 
            // radioButtonKmControlado
            // 
            this.radioButtonKmControlado.AutoSize = true;
            this.radioButtonKmControlado.Enabled = false;
            this.radioButtonKmControlado.Location = new System.Drawing.Point(69, 146);
            this.radioButtonKmControlado.Name = "radioButtonKmControlado";
            this.radioButtonKmControlado.Size = new System.Drawing.Size(104, 19);
            this.radioButtonKmControlado.TabIndex = 14;
            this.radioButtonKmControlado.Text = "Km controlado";
            this.radioButtonKmControlado.UseVisualStyleBackColor = true;
            this.radioButtonKmControlado.CheckedChanged += new System.EventHandler(this.radioButtonKmControlado_CheckedChanged);
            // 
            // radioButtonPlanoDiario
            // 
            this.radioButtonPlanoDiario.AutoSize = true;
            this.radioButtonPlanoDiario.Enabled = false;
            this.radioButtonPlanoDiario.Location = new System.Drawing.Point(69, 80);
            this.radioButtonPlanoDiario.Name = "radioButtonPlanoDiario";
            this.radioButtonPlanoDiario.Size = new System.Drawing.Size(88, 19);
            this.radioButtonPlanoDiario.TabIndex = 13;
            this.radioButtonPlanoDiario.Text = "Plano diário";
            this.radioButtonPlanoDiario.UseVisualStyleBackColor = true;
            this.radioButtonPlanoDiario.CheckedChanged += new System.EventHandler(this.radioButtonPlanoDiario_CheckedChanged);
            // 
            // labelGrupoVeiculos
            // 
            this.labelGrupoVeiculos.AutoSize = true;
            this.labelGrupoVeiculos.Location = new System.Drawing.Point(180, 13);
            this.labelGrupoVeiculos.Name = "labelGrupoVeiculos";
            this.labelGrupoVeiculos.Size = new System.Drawing.Size(0, 15);
            this.labelGrupoVeiculos.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Grupo de veículos:";
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
            this.checkedListBoxTaxas.SelectedValueChanged += new System.EventHandler(this.checkedListBoxTaxas_SelectedValueChanged);
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
            this.dateTimePickerDataDevolucaoPrevista.ValueChanged += new System.EventHandler(this.dateTimePickerDataDevolucaoPrevista_ValueChanged);
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
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageTaxas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataDevolucaoPrevista;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ComboBox comboBoxVeiculos;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelValorPrevisto;
        private System.Windows.Forms.Label labelPlaca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelGrupoVeiculos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioButtonKmLivre;
        private System.Windows.Forms.RadioButton radioButtonKmControlado;
        private System.Windows.Forms.RadioButton radioButtonPlanoDiario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelKmLivreValorDia;
        private System.Windows.Forms.Label labelKmControladoLimiteKm;
        private System.Windows.Forms.Label labelKmControladoValorKm;
        private System.Windows.Forms.Label labelKmControladoValorDia;
        private System.Windows.Forms.Label labelDiarioValorKm;
        private System.Windows.Forms.Label labelDiarioValorDia;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelKmInicial;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBoxCondutores;
    }
}