namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    partial class TelaConfigPrecoCombustivelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numPrecoGasolina = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numPrecoDiesel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPrecoAlcool = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPrecoGNV = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGasolina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoDiesel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoAlcool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGNV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gasolina:";
            // 
            // numPrecoGasolina
            // 
            this.numPrecoGasolina.DecimalPlaces = 3;
            this.numPrecoGasolina.Location = new System.Drawing.Point(112, 56);
            this.numPrecoGasolina.Name = "numPrecoGasolina";
            this.numPrecoGasolina.Size = new System.Drawing.Size(120, 23);
            this.numPrecoGasolina.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Atualizado em: ";
            // 
            // numPrecoDiesel
            // 
            this.numPrecoDiesel.DecimalPlaces = 3;
            this.numPrecoDiesel.Location = new System.Drawing.Point(112, 85);
            this.numPrecoDiesel.Name = "numPrecoDiesel";
            this.numPrecoDiesel.Size = new System.Drawing.Size(120, 23);
            this.numPrecoDiesel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Diesel:";
            // 
            // numPrecoAlcool
            // 
            this.numPrecoAlcool.DecimalPlaces = 3;
            this.numPrecoAlcool.Location = new System.Drawing.Point(112, 114);
            this.numPrecoAlcool.Name = "numPrecoAlcool";
            this.numPrecoAlcool.Size = new System.Drawing.Size(120, 23);
            this.numPrecoAlcool.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Álcool:";
            // 
            // numPrecoGNV
            // 
            this.numPrecoGNV.DecimalPlaces = 3;
            this.numPrecoGNV.Location = new System.Drawing.Point(112, 143);
            this.numPrecoGNV.Name = "numPrecoGNV";
            this.numPrecoGNV.Size = new System.Drawing.Size(120, 23);
            this.numPrecoGNV.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "GNV:";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(104, 180);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 12;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(185, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // data
            // 
            this.data.Enabled = false;
            this.data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data.Location = new System.Drawing.Point(127, 16);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(105, 23);
            this.data.TabIndex = 14;
            this.data.Value = new System.DateTime(2022, 7, 6, 23, 59, 59, 0);
            // 
            // TelaConfigPrecoCombustivelForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 214);
            this.Controls.Add(this.data);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.numPrecoGNV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numPrecoAlcool);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numPrecoDiesel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPrecoGasolina);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaConfigPrecoCombustivelForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preço do Combustível";
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGasolina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoDiesel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoAlcool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoGNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPrecoGasolina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPrecoDiesel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPrecoAlcool;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPrecoGNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker data;
    }
}