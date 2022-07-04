using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculoForm : Form
    {
        private Veiculo veiculo;
        private IRepositorioGrupoVeiculos repositorioGrupoVeiculos;
        public string caminhoImagem = "";

        public TelaCadastroVeiculoForm()
        {
            InitializeComponent();
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            CarregarTipoCombustivel();
            CarregarGrupoVeiculos();
        }

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;
                if (veiculo.Id != 0)
                {
                    txtModelo.Text = veiculo.Modelo;
                    txtMarca.Text = veiculo.Marca;
                    txtCor.Text = veiculo.Cor;
                    txtPlaca.Text = veiculo.Placa;
                    numericAno.Value = veiculo.Ano;
                    numericQuilometragemPercorrida.Value = veiculo.QuilometragemPercorrida;
                    numericCapacidadeTanque.Value = veiculo.CapacidadeTanque;
                    comboBoxTipoCombustivel.Text = veiculo.TipoCombustivel;
                    comboBoxGrupoVeiculos.Text = veiculo.GrupoVeiculos.Nome;
                    ExibirImagem();
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();
            var resultadoValidacao = GravarRegistro(veiculo);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            caminhoImagem = "";
            txtModelo.Clear();
            txtMarca.Clear();
            txtCor.Clear();
            txtPlaca.Clear();
            numericAno.Value = numericAno.Minimum;
            numericQuilometragemPercorrida.Value = numericQuilometragemPercorrida.Minimum;
            numericCapacidadeTanque.Value = numericCapacidadeTanque.Minimum;
            comboBoxTipoCombustivel.SelectedItem = null;
            comboBoxGrupoVeiculos.SelectedItem = null;
            pictureBoxImagem.Image = null;
        }

        private void ObterDadosTela()
        {
            veiculo.Modelo = txtModelo.Text;
            veiculo.Marca = txtMarca.Text;
            veiculo.Cor = txtCor.Text;
            veiculo.Placa = txtPlaca.Text.ToUpper();
            veiculo.Ano = (int)numericAno.Value;
            veiculo.QuilometragemPercorrida = (int)numericQuilometragemPercorrida.Value;
            veiculo.CapacidadeTanque = numericCapacidadeTanque.Value;


            if (comboBoxTipoCombustivel.SelectedItem != null)
                veiculo.TipoCombustivel = (string)comboBoxTipoCombustivel.SelectedItem;
            if (comboBoxGrupoVeiculos.SelectedItem != null)
                veiculo.GrupoVeiculos = ObterGrupoVeiculosSelecionado();
            if (caminhoImagem != "")
                veiculo.Imagem = GetImagem(caminhoImagem);
        }

        private GrupoVeiculos ObterGrupoVeiculosSelecionado()
        {
            string nome = (string)comboBoxGrupoVeiculos.SelectedItem;
            return repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(nome);
        }

        #region IMAGEM DO VEÍCULO
        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "|*.jpg; *.jpeg; *.png; *.jfif;";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = openFile.FileName;
            }

            if (caminhoImagem != "")
            {
                pictureBoxImagem.Load(caminhoImagem);
            }
        }

        private byte[] GetImagem(string caminhoImagem)
        {
            byte[] imagem;
            using (var stream = new FileStream(caminhoImagem, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    imagem = reader.ReadBytes((int)stream.Length);
                }
            }

            return imagem;
        }

        private void ExibirImagem()
        {
            using (var img = new MemoryStream(veiculo.Imagem))
            {
                pictureBoxImagem.Image = Image.FromStream(img);
            }
        }

        #endregion

        #region CARREGAR COMBOBOX
        private void CarregarTipoCombustivel()
        {
            comboBoxTipoCombustivel.Items.Clear();
            comboBoxTipoCombustivel.Items.Add("Gasolina");
            comboBoxTipoCombustivel.Items.Add("Diesel");
            comboBoxTipoCombustivel.Items.Add("Álcool");
            comboBoxTipoCombustivel.Items.Add("GNV");
            comboBoxTipoCombustivel.Items.Add("Flex");
        }

        private void CarregarGrupoVeiculos()
        {
            comboBoxGrupoVeiculos.Items.Clear();
            List<GrupoVeiculos> grupos = repositorioGrupoVeiculos.SelecionarTodos();

            foreach (var g in grupos)
            {
                comboBoxGrupoVeiculos.Items.Add(g.Nome);
            }

        }

        #endregion
    }
}