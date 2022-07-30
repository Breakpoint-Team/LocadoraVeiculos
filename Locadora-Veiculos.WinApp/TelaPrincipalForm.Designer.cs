namespace Locadora_Veiculos.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionariosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupoVeiculosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veiculosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planosDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnGerarPDF = new System.Windows.Forms.ToolStripButton();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.statusStripRodape = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.statusStripRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesMenuItem,
            this.funcionariosMenuItem,
            this.grupoVeiculosMenuItem,
            this.taxasMenuItem,
            this.veiculosMenuItem,
            this.condutoresToolStripMenuItem,
            this.planosDeCobrançaToolStripMenuItem,
            this.locaçõesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // clientesMenuItem
            // 
            this.clientesMenuItem.Name = "clientesMenuItem";
            this.clientesMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.clientesMenuItem.Size = new System.Drawing.Size(196, 22);
            this.clientesMenuItem.Text = "Clientes";
            this.clientesMenuItem.ToolTipText = "Clientes";
            this.clientesMenuItem.Click += new System.EventHandler(this.clientesMenuItem_Click);
            // 
            // funcionariosMenuItem
            // 
            this.funcionariosMenuItem.Name = "funcionariosMenuItem";
            this.funcionariosMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.funcionariosMenuItem.Size = new System.Drawing.Size(196, 22);
            this.funcionariosMenuItem.Text = "Funcionários";
            this.funcionariosMenuItem.ToolTipText = "Funcionários";
            this.funcionariosMenuItem.Click += new System.EventHandler(this.funcionariosMenuItem_Click);
            // 
            // grupoVeiculosMenuItem
            // 
            this.grupoVeiculosMenuItem.Name = "grupoVeiculosMenuItem";
            this.grupoVeiculosMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.grupoVeiculosMenuItem.Size = new System.Drawing.Size(196, 22);
            this.grupoVeiculosMenuItem.Text = "Grupos de veículos";
            this.grupoVeiculosMenuItem.ToolTipText = "Grupo de veículos";
            this.grupoVeiculosMenuItem.Click += new System.EventHandler(this.grupoVeiculosMenuItem_Click);
            // 
            // taxasMenuItem
            // 
            this.taxasMenuItem.Name = "taxasMenuItem";
            this.taxasMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.taxasMenuItem.Size = new System.Drawing.Size(196, 22);
            this.taxasMenuItem.Text = "Taxas";
            this.taxasMenuItem.ToolTipText = "Taxas";
            this.taxasMenuItem.Click += new System.EventHandler(this.taxasMenuItem_Click);
            // 
            // veiculosMenuItem
            // 
            this.veiculosMenuItem.Name = "veiculosMenuItem";
            this.veiculosMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.veiculosMenuItem.Size = new System.Drawing.Size(196, 22);
            this.veiculosMenuItem.Text = "Veículos";
            this.veiculosMenuItem.Click += new System.EventHandler(this.veiculosMenuItem_Click);
            // 
            // condutoresToolStripMenuItem
            // 
            this.condutoresToolStripMenuItem.Name = "condutoresToolStripMenuItem";
            this.condutoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.condutoresToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.condutoresToolStripMenuItem.Text = "Condutores";
            this.condutoresToolStripMenuItem.Click += new System.EventHandler(this.condutoresToolStripMenuItem_Click);
            // 
            // planosDeCobrançaToolStripMenuItem
            // 
            this.planosDeCobrançaToolStripMenuItem.Name = "planosDeCobrançaToolStripMenuItem";
            this.planosDeCobrançaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.planosDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.planosDeCobrançaToolStripMenuItem.Text = "Planos de cobrança";
            this.planosDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planosDeCobrançaToolStripMenuItem_Click);
            // 
            // locaçõesToolStripMenuItem
            // 
            this.locaçõesToolStripMenuItem.Name = "locaçõesToolStripMenuItem";
            this.locaçõesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.locaçõesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.locaçõesToolStripMenuItem.Text = "Locações";
            this.locaçõesToolStripMenuItem.Click += new System.EventHandler(this.locacoesToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // toolbox
            // 
            this.toolbox.Enabled = false;
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.btnGerarPDF,
            this.labelTipoCadastro});
            this.toolbox.Location = new System.Drawing.Point(0, 24);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(800, 41);
            this.toolbox.TabIndex = 1;
            this.toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInserir.DoubleClickEnabled = true;
            this.btnInserir.Image = global::Locadora_Veiculos.WinApp.Properties.Resources.add_box_FILL0_wght200_GRAD0_opsz24;
            this.btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Padding = new System.Windows.Forms.Padding(5);
            this.btnInserir.Size = new System.Drawing.Size(38, 38);
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Visible = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.DoubleClickEnabled = true;
            this.btnEditar.Image = global::Locadora_Veiculos.WinApp.Properties.Resources.edit_note_FILL0_wght200_GRAD0_opsz24;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.DoubleClickEnabled = true;
            this.btnExcluir.Image = global::Locadora_Veiculos.WinApp.Properties.Resources.delete_FILL0_wght200_GRAD0_opsz24;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(38, 38);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnGerarPDF
            // 
            this.btnGerarPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGerarPDF.DoubleClickEnabled = true;
            this.btnGerarPDF.Image = global::Locadora_Veiculos.WinApp.Properties.Resources.picture_as_pdf_FILL0_wght200_GRAD0_opsz24;
            this.btnGerarPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGerarPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGerarPDF.Name = "btnGerarPDF";
            this.btnGerarPDF.Padding = new System.Windows.Forms.Padding(5);
            this.btnGerarPDF.Size = new System.Drawing.Size(38, 38);
            this.btnGerarPDF.Text = "Gerar PDF";
            this.btnGerarPDF.Visible = false;
            this.btnGerarPDF.Click += new System.EventHandler(this.btnGerarPDF_Click);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.labelTipoCadastro.LinkColor = System.Drawing.Color.LightSeaGreen;
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(94, 38);
            this.labelTipoCadastro.Text = "toolStripLabel1";
            // 
            // statusStripRodape
            // 
            this.statusStripRodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStripRodape.Location = new System.Drawing.Point(0, 428);
            this.statusStripRodape.Name = "statusStripRodape";
            this.statusStripRodape.Size = new System.Drawing.Size(800, 22);
            this.statusStripRodape.TabIndex = 2;
            this.statusStripRodape.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(75, 17);
            this.labelRodape.Text = "Label rodapé";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 65);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(800, 363);
            this.panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.statusStripRodape);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menu;
            this.Name = "TelaPrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora de Veículos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.statusStripRodape.ResumeLayout(false);
            this.statusStripRodape.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionariosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupoVeiculosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxasMenuItem;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.StatusStrip statusStripRodape;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripMenuItem veiculosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condutoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planosDeCobrançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preçoCombustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnGerarPDF;
    }
}