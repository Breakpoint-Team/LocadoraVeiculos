using FluentResults;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private ListagemLocacaoControl listagemLocacoes;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoTaxa servicoTaxa;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private readonly ServicoLocacao servicoLocacao;

        public ControladorLocacao(ServicoCondutor servicoCondutor,
            ServicoCliente servicoCliente, ServicoGrupoVeiculos servicoGrupoVeiculos,
            ServicoVeiculo servicoVeiculo, ServicoTaxa servicoTaxa,
            ServicoPlanoCobranca servicoPlanoCobranca, ServicoLocacao servicoLocacao)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoTaxa = servicoTaxa;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoLocacao = servicoLocacao;
        }

        public override void Inserir()
        {
            var resultado = VerificarDependencias();

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroLocacaoForm tela =
                new TelaCadastroLocacaoForm(ObterClientes(), ObterCondutores(),
                ObterGruposDeVeiculo(), ObterVeiculos(), ObterTaxas(), ObterPlanosDeCobranca());

            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;


            if (tela.ShowDialog() == DialogResult.OK)
            {
                GerarPDF();
                CarregarLocacoes();
            }
        }

        public override void Editar()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro!",
                "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Result<Locacao> resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            TelaCadastroLocacaoForm tela =
               new TelaCadastroLocacaoForm(ObterClientes(), ObterCondutores(),
               ObterGruposDeVeiculo(), ObterVeiculos(), ObterTaxas(), ObterPlanosDeCobranca());

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();
        }

        public override void Excluir()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro!",
                "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemLocacoes == null)
                listagemLocacoes = new ListagemLocacaoControl();

            CarregarLocacoes();

            return listagemLocacoes;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                listagemLocacoes.AtualizarRegistros(locacoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locação(ões)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Locação",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Cliente> ObterClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();

            List<Cliente> lista = new List<Cliente>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private List<Condutor> ObterCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            List<Condutor> lista = new List<Condutor>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private List<GrupoVeiculos> ObterGruposDeVeiculo()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();

            List<GrupoVeiculos> lista = new List<GrupoVeiculos>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private List<Veiculo> ObterVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            List<Veiculo> lista = new List<Veiculo>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private List<Taxa> ObterTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();

            List<Taxa> lista = new List<Taxa>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private List<PlanoCobranca> ObterPlanosDeCobranca()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();

            List<PlanoCobranca> lista = new List<PlanoCobranca>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private Result VerificarDependencias()
        {
            var resultadoCondutores = servicoCondutor.QuantidadeCondutoresCadastrados();

            if (resultadoCondutores.IsFailed)
            {
                return Result.Fail(resultadoCondutores.Errors[0].Message);
            }

            var qtdCondutores = resultadoCondutores.Value;

            if (qtdCondutores == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja um condutor cadastrado!");
            }

            var resultadoVeiculos = servicoVeiculo.QuantidadeVeiculosCadastrados();

            if (resultadoVeiculos.IsFailed)
            {
                return Result.Fail(resultadoVeiculos.Errors[0].Message);
            }

            var qtdVeiculos = resultadoVeiculos.Value;

            if (qtdVeiculos == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja um veículo cadastrado!");
            }

            var resultadoTaxas = servicoTaxa.QuantidadeTaxasCadastradas();

            if (resultadoTaxas.IsFailed)
            {
                return Result.Fail(resultadoTaxas.Errors[0].Message);
            }

            var qtdTaxas = resultadoTaxas.Value;

            if (qtdTaxas == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja uma taxa cadastrada!");
            }

            var resultadoPlanos = servicoPlanoCobranca.QuantidadePlanosCadastrados();

            if (resultadoPlanos.IsFailed)
            {
                return Result.Fail(resultadoPlanos.Errors[0].Message);
            }

            var qtdPlanos = resultadoPlanos.Value;

            if (qtdPlanos == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja um plano de cobrança cadastrado!");
            }

            return Result.Ok();
        }

        #endregion

        public void GerarPDF()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro!",
                "Geração de PDF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);
            var locacao = resultadoSelecao.Value;

            DialogResult resultado = MessageBox.Show("Deseja realmente gerar um pdf da locação?",
                  "Geração de PDF", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                #region obtem local para salvar o arquivo
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File |*.pdf";
                #endregion

                #region gera o pdf 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                    doc.Open();

                    #region aux
                    Paragraph pulaLinha = new Paragraph("\n");
                    Font fontNormal = FontFactory.GetFont("Arial", 8, Font.NORMAL, new BaseColor(0, 0, 0));
                    Font fontBold = FontFactory.GetFont("Arial", 8, Font.BOLD, new BaseColor(0, 0, 0));
                    Chunk linebreak = new Chunk(new LineSeparator(2f, 100f, new BaseColor(192, 192, 192), Element.ALIGN_CENTER, -1));

                    #endregion

                    var dataEmitido = new Paragraph("Emitido em: " + DateTime.Now, fontNormal);
                    dataEmitido.Alignment = Element.ALIGN_TOP;
                    dataEmitido.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(dataEmitido);

                    Paragraph t1 = new Paragraph("Registro de Locação\n\n\n", FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 0, 0)));
                    t1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(t1);
                    doc.Add(pulaLinha);


                    #region CLIENTE
                    Paragraph infosCliente = new Paragraph("Informações do Cliente\n", fontBold);
                    Phrase cliente = new Phrase($"Nome: {locacao.Condutor.Cliente.Nome}\nDocumento: {locacao.Condutor.Cliente.Documento}\n", fontNormal);
                    doc.Add(infosCliente);
                    doc.Add(cliente);
                    doc.Add(linebreak);
                    doc.Add(pulaLinha);

                    #endregion

                    #region CONDUTOR
                    Paragraph infosCondutor = new Paragraph("Informações do Condutor\n", fontBold);

                    Phrase nomeCondutor = new Phrase($"Nome: {locacao.Condutor.Nome}\n", fontNormal);

                    Paragraph sessaoDoc = new Paragraph("Documentos\n", fontBold);
                    Phrase sessaoDocConteudo = new Phrase(
                        $"CPF: {locacao.Condutor.Cpf}\n" +
                        $"CNH: {locacao.Condutor.Cnh}\n" +
                        $"Data de Validade da CNH: {locacao.Condutor.DataValidadeCnh.ToShortDateString()}\n",
                        fontNormal);

                    Paragraph sessaoContato = new Paragraph("Contato:\n", fontBold);
                    Phrase sessaoContatoConteudo = new Phrase(
                        $"Telefone: {locacao.Condutor.Telefone}\n" +
                        $"Email: {locacao.Condutor.Email}\n",
                        fontNormal);

                    Paragraph sessaoEndereco = new Paragraph("Endereço:\n", fontBold);
                    Phrase sessaoEnderecoConteudo = new Phrase(
                        $"{locacao.Condutor.Endereco.Logradouro}, " +
                        $"{locacao.Condutor.Endereco.Numero} - " +
                        $"{locacao.Condutor.Endereco.Bairro}, " +
                        $"{locacao.Condutor.Endereco.Cidade} - " +
                        $"{locacao.Condutor.Endereco.Estado}\n", fontNormal);

                    doc.Add(infosCondutor);
                    doc.Add(nomeCondutor);
                    doc.Add(sessaoDoc);
                    doc.Add(sessaoDocConteudo);
                    doc.Add(sessaoContato);
                    doc.Add(sessaoContatoConteudo);
                    doc.Add(sessaoEndereco);
                    doc.Add(sessaoEnderecoConteudo);
                    doc.Add(linebreak);
                    doc.Add(pulaLinha);
                    #endregion

                    #region VEICULO
                    Paragraph infosVeiculo = new Paragraph("Informações do Veículo\n", fontBold);

                    Phrase sessaoVeiculoConteudo = new Phrase(
                    $"Modelo: {locacao.Veiculo.Modelo}\n" +
                    $"Marca: {locacao.Veiculo.Marca}\n" +
                    $"Ano: {locacao.Veiculo.Ano}\n" +
                    $"Cor: {locacao.Veiculo.Cor}\n" +
                    $"Placa: {locacao.Veiculo.Placa}\n" +
                    $"Combustível: {locacao.Veiculo.TipoCombustivel}\n" +
                    $"Capacidade do Tanque: {locacao.Veiculo.CapacidadeTanque}\n" +
                    $"Quilometragem: {locacao.Veiculo.QuilometragemPercorrida}\n" +
                    $"Grupo de Veículos: {locacao.Veiculo.GrupoVeiculos.Nome}\n", fontNormal);

                    doc.Add(infosVeiculo);
                    doc.Add(sessaoVeiculoConteudo);
                    doc.Add(linebreak);
                    doc.Add(pulaLinha);
                    #endregion

                    #region DATAS
                    Phrase dataLocacao = new Phrase($"Data da locação: {locacao.DataLocacao.ToShortDateString()}\n", fontBold);
                    Phrase dataDevolucaoPrevista = new Phrase($"Data de devolução prevista: {locacao.DataLocacao.ToShortDateString()}\n", fontBold);
                    doc.Add(dataLocacao);
                    doc.Add(dataDevolucaoPrevista);
                    #endregion

                    #region PLANOCOBRANCA
                    Phrase planoCobranca = new Phrase($"Plano de cobrança: {locacao.TipoPlanoSelecionado}\n", fontBold);
                    doc.Add(planoCobranca);
                    #endregion

                    #region TAXAS
                    Phrase taxa = new Phrase($"Taxas selecionadas: \n", fontBold);
                    doc.Add(taxa);
                    foreach (var t in locacao.TaxasSelecionadas)
                    {
                        doc.Add(new Paragraph(t.ToString() + "\n", fontNormal));
                    }
                    doc.Add(pulaLinha);
                    #endregion

                    #region TOTALPREVISTO
                    Phrase totalPrevisto = new Phrase($"Total previsto: R$ {locacao.ValorTotalPrevisto}\n", fontBold);
                    doc.Add(totalPrevisto);
                    #endregion

                    //#region RODAPE
                    //var rodape = new Paragraph("Breakpoint - Academia do Programador 2022", fontNormal);
                    //rodape.Alignment = Element.ALIGN_BOTTOM;
                    //rodape.Alignment = Element.ALIGN_CENTER;
                    //doc.Add(rodape);
                    //#endregion

                    doc.Close();

                    MessageBox.Show("Arquivo PDF foi salvo!",
                    "Geração de PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
            }
        }

    }



}
