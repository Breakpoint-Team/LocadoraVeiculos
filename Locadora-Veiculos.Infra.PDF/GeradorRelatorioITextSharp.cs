using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.Configs;
using System;
using System.IO;

namespace Locadora_Veiculos.Infra.PDF
{
    public class GeradorRelatorioITextSharp : IGeradorRelatorio
    {
        private ConfiguracaoAplicacao configuracaoAplicacao;
        public GeradorRelatorioITextSharp(ConfiguracaoAplicacao configuracaoAplicacao)
        {
            this.configuracaoAplicacao = configuracaoAplicacao;
        }
        public void GerarRelatorioLocacaoPDF(Locacao locacao)
        {

            string path = @"" + configuracaoAplicacao.ConfiguracaoRelatorio.DiretorioSaida;

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            var nomeArquivo = GerarNomeArquivo(locacao);

            var doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream($"{path}\\{nomeArquivo}.pdf", FileMode.Create));

            doc.Open();

            #region aux
            Paragraph pulaLinha = new Paragraph("\n");
            Font fontNormal = FontFactory.GetFont("Arial", 8, Font.NORMAL, new BaseColor(0, 0, 0));
            Font fontBold = FontFactory.GetFont("Arial", 8, Font.BOLD, new BaseColor(0, 0, 0));
            Chunk linebreak = new Chunk(new LineSeparator(2f, 100f, new BaseColor(192, 192, 192), Element.ALIGN_CENTER, -1));

            #endregion

            #region HEADER

            var dataEmitido = new Paragraph("Emitido em: " + DateTime.Now, fontNormal);
            dataEmitido.Alignment = Element.ALIGN_TOP;
            dataEmitido.Alignment = Element.ALIGN_RIGHT;
            doc.Add(dataEmitido);

            Paragraph t1 = new Paragraph("Registro de Locação\n\n\n", FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 0, 0)));
            t1.Alignment = Element.ALIGN_CENTER;
            doc.Add(t1);
            doc.Add(pulaLinha);
            #endregion

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

            PdfPTable tabelaDatas = new PdfPTable(2);

            PdfPCell cell = new PdfPCell(new Phrase("Datas", fontBold));
            cell.Colspan = 2;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell);

            tabelaDatas.AddCell(new Phrase("Data da locação", fontBold));
            tabelaDatas.AddCell(new Phrase("Data de devolução prevista", fontBold));


            tabelaDatas.AddCell(new Phrase($"{locacao.DataLocacao.ToShortDateString()}\n", fontNormal));
            tabelaDatas.AddCell(new Phrase($"{locacao.DataDevolucaoPrevista.ToShortDateString()}\n", fontNormal));

            doc.Add(tabelaDatas);
            doc.Add(pulaLinha);
            #endregion

            #region PLANOCOBRANCA

            if (locacao.TipoPlanoSelecionado == Dominio.ModuloPlanoCobranca.TipoPlano.Diario) //diario
            {
                PdfPTable tabelaPlanoCobrancaDiario = new PdfPTable(2);

                PdfPCell cellPlanoCobrancaDiario1 = new PdfPCell(new Phrase("Plano de Cobrança selecionado: Diário", fontBold));
                cellPlanoCobrancaDiario1.Colspan = 2;
                cellPlanoCobrancaDiario1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaDiario.AddCell(cellPlanoCobrancaDiario1);

                tabelaPlanoCobrancaDiario.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoCobranca.DiarioValorDia}", fontNormal));
                tabelaPlanoCobrancaDiario.AddCell(new Phrase($"Valor por Km: R$ {locacao.PlanoCobranca.DiarioValorKm}", fontNormal));


                doc.Add(tabelaPlanoCobrancaDiario);
            }
            else if (locacao.TipoPlanoSelecionado == Dominio.ModuloPlanoCobranca.TipoPlano.Controlado)
            {

                PdfPTable tabelaPlanoCobrancaControlado = new PdfPTable(3);

                PdfPCell cellPlanoCobrancaControladoHeader = new PdfPCell(new Phrase("Plano de Cobrança selecionado: Km Controlado", fontBold));
                cellPlanoCobrancaControladoHeader.Colspan = 3;
                cellPlanoCobrancaControladoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaControlado.AddCell(cellPlanoCobrancaControladoHeader);

                tabelaPlanoCobrancaControlado.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoCobranca.KmControladoValorDia}", fontNormal));
                tabelaPlanoCobrancaControlado.AddCell(new Phrase($"Limite de Km: R$ {locacao.PlanoCobranca.KmControladoLimiteKm}", fontNormal));
                tabelaPlanoCobrancaControlado.AddCell(new Phrase($"Valor por Km excedente: R$ {locacao.PlanoCobranca.KmControladoValorKm}", fontNormal));


                doc.Add(tabelaPlanoCobrancaControlado);
            }
            else if (locacao.TipoPlanoSelecionado == Dominio.ModuloPlanoCobranca.TipoPlano.Livre)
            {

                PdfPTable tabelaPlanoCobrancaLivre = new PdfPTable(1);

                PdfPCell cellPlanoCobrancaLivreHeader = new PdfPCell(new Phrase("Plano de Cobrança selecionado: Km Livre", fontBold));
                cellPlanoCobrancaLivreHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaLivre.AddCell(cellPlanoCobrancaLivreHeader);

                tabelaPlanoCobrancaLivre.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoCobranca.KmLivreValorDia}", fontNormal));

                doc.Add(tabelaPlanoCobrancaLivre);
            }
            doc.Add(pulaLinha);
            #endregion

            #region TAXAS
            if (locacao.TaxasSelecionadas.Count > 0)
            {

                PdfPTable tabelaTaxas = new PdfPTable(3);

                PdfPCell cell1 = new PdfPCell(new Phrase("Taxas Selecionadas", fontBold));
                cell1.Colspan = 3;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaTaxas.AddCell(cell1);

                tabelaTaxas.AddCell(new Phrase("Descrição", fontBold));
                tabelaTaxas.AddCell(new Phrase("Valor", fontBold));
                tabelaTaxas.AddCell(new Phrase("Tipo de Cálculo", fontBold));

                foreach (var t in locacao.TaxasSelecionadas)
                {
                    if (t.TipoTaxa == Dominio.ModuloTaxa.TipoTaxa.TaxaLocacao)
                    {
                        tabelaTaxas.AddCell(new Phrase($"{t.Descricao}", fontNormal));
                        tabelaTaxas.AddCell(new Phrase($"{t.Valor}", fontNormal));
                        tabelaTaxas.AddCell(new Phrase($"{t.TipoCalculo}", fontNormal));
                    }
                }
                doc.Add(tabelaTaxas);
                doc.Add(pulaLinha);
            }
            #endregion

            #region TOTALPREVISTO
            Paragraph totalPrevisto = new Paragraph($"Valor total previsto: R$ {locacao.ValorTotalPrevisto}\n", fontBold);
            totalPrevisto.Alignment = Element.ALIGN_CENTER;
            doc.Add(totalPrevisto);
            #endregion


            doc.Close();

        }

        public void GerarRelatorioDevolucaoPDF(Locacao locacao)
        {
            string path = @"" + configuracaoAplicacao.ConfiguracaoRelatorio.DiretorioSaida;

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            var nomeArquivo = GerarNomeArquivo(locacao);

            var doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream($"{path}\\{nomeArquivo}.pdf", FileMode.Create));

            doc.Open();

            #region aux
            Paragraph pulaLinha = new Paragraph("\n");
            Font fontNormal = FontFactory.GetFont("Arial", 8, Font.NORMAL, new BaseColor(0, 0, 0));
            Font fontBold = FontFactory.GetFont("Arial", 8, Font.BOLD, new BaseColor(0, 0, 0));
            Chunk linebreak = new Chunk(new LineSeparator(2f, 100f, new BaseColor(192, 192, 192), Element.ALIGN_CENTER, -1));

            #endregion

            #region HEADER

            var dataEmitido = new Paragraph("Emitido em: " + DateTime.Now, fontNormal);
            dataEmitido.Alignment = Element.ALIGN_TOP;
            dataEmitido.Alignment = Element.ALIGN_RIGHT;
            doc.Add(dataEmitido);

            Paragraph t1 = new Paragraph("Registro de Devolução\n\n\n", FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 0, 0)));
            t1.Alignment = Element.ALIGN_CENTER;
            doc.Add(t1);
            doc.Add(pulaLinha);
            #endregion

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

            PdfPTable tabelaDatas = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Phrase("Datas", fontBold));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell);

            tabelaDatas.AddCell(new Phrase("Data da locação", fontBold));
            tabelaDatas.AddCell(new Phrase("Data de devolução prevista", fontBold));
            tabelaDatas.AddCell(new Phrase("Data de devolução efetiva", fontBold));


            tabelaDatas.AddCell(new Phrase($"{locacao.DataLocacao.ToShortDateString()}\n", fontNormal));
            tabelaDatas.AddCell(new Phrase($"{locacao.DataDevolucaoPrevista.ToShortDateString()}\n", fontNormal));
            tabelaDatas.AddCell(new Phrase($"{locacao.DataDevolucaoEfetiva.Value.ToShortDateString()}\n", fontNormal));

            TimeSpan diasPrevistos = Convert.ToDateTime(locacao.DataDevolucaoPrevista) - Convert.ToDateTime(locacao.DataLocacao);
            int diasP = diasPrevistos.Days;

            TimeSpan diasLocacao = Convert.ToDateTime(locacao.DataDevolucaoEfetiva.Value) - Convert.ToDateTime(locacao.DataLocacao);
            int diasL = diasLocacao.Days;

            string statusDevolucao = diasL > diasP ? $"Atrasada" : "No prazo";

            PdfPCell cell2 = new PdfPCell(new Phrase("Status da devolução: " + statusDevolucao, fontNormal));
            cell2.Colspan = 3;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(new Phrase("Total de dias de locação: " + diasL, fontBold));
            cell3.Colspan = 3;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell3);

            doc.Add(tabelaDatas);
            doc.Add(pulaLinha);
            #endregion

            #region PLANOCOBRANCA

            if (locacao.TipoPlanoSelecionado == TipoPlano.Diario) //diario
            {
                PdfPTable tabelaPlanoCobrancaDiario = new PdfPTable(2);

                PdfPCell cellPlanoCobrancaDiario1 = new PdfPCell(new Phrase("Plano de Cobrança selecionado: Diário", fontBold));
                cellPlanoCobrancaDiario1.Colspan = 2;
                cellPlanoCobrancaDiario1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaDiario.AddCell(cellPlanoCobrancaDiario1);

                tabelaPlanoCobrancaDiario.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoCobranca.DiarioValorDia}", fontNormal));
                tabelaPlanoCobrancaDiario.AddCell(new Phrase($"Valor por Km: R$ {locacao.PlanoCobranca.DiarioValorKm}", fontNormal));


                doc.Add(tabelaPlanoCobrancaDiario);
            }
            else if (locacao.TipoPlanoSelecionado == TipoPlano.Controlado)
            {

                PdfPTable tabelaPlanoCobrancaControlado = new PdfPTable(3);

                PdfPCell cellPlanoCobrancaControladoHeader = new PdfPCell(new Phrase("Plano de Cobrança selecionado: Km Controlado", fontBold));
                cellPlanoCobrancaControladoHeader.Colspan = 3;
                cellPlanoCobrancaControladoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaControlado.AddCell(cellPlanoCobrancaControladoHeader);

                tabelaPlanoCobrancaControlado.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoCobranca.KmControladoValorDia}", fontNormal));
                tabelaPlanoCobrancaControlado.AddCell(new Phrase($"Limite de Km: R$ {locacao.PlanoCobranca.KmControladoLimiteKm}", fontNormal));
                tabelaPlanoCobrancaControlado.AddCell(new Phrase($"Valor por Km excedente: R$ {locacao.PlanoCobranca.KmControladoValorKm}", fontNormal));


                doc.Add(tabelaPlanoCobrancaControlado);
            }
            else if (locacao.TipoPlanoSelecionado == TipoPlano.Livre)
            {

                PdfPTable tabelaPlanoCobrancaLivre = new PdfPTable(1);

                PdfPCell cellPlanoCobrancaLivreHeader = new PdfPCell(new Phrase("Plano de Cobrança selecionado: Km Livre", fontBold));
                cellPlanoCobrancaLivreHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaLivre.AddCell(cellPlanoCobrancaLivreHeader);

                tabelaPlanoCobrancaLivre.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoCobranca.KmLivreValorDia}", fontNormal));

                doc.Add(tabelaPlanoCobrancaLivre);
            }
            doc.Add(pulaLinha);
            #endregion

            #region KM
            PdfPTable tabelaKM = new PdfPTable(2);

            PdfPCell cellQuilometragemHeader = new PdfPCell(new Phrase("Quilometragem", fontBold));
            cellQuilometragemHeader.Colspan = 2;
            cellQuilometragemHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaKM.AddCell(cellQuilometragemHeader);

            tabelaKM.AddCell(new Phrase($"Inicial: {locacao.QuilometragemInicialVeiculo}", fontNormal));
            tabelaKM.AddCell(new Phrase($"Final: {locacao.QuilometragemFinalVeiculo}", fontNormal));

            int nKmpercorridos = locacao.QuilometragemFinalVeiculo.Value - locacao.QuilometragemInicialVeiculo;

            PdfPCell totalKmPercorridos = new PdfPCell(new Phrase($"Km percorridos: {nKmpercorridos}", fontBold));
            totalKmPercorridos.Colspan = 2;
            totalKmPercorridos.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaKM.AddCell(totalKmPercorridos);

            doc.Add(tabelaKM);
            doc.Add(pulaLinha);
            #endregion

            #region TAXAS

            bool temTaxaLocacao = false;
            foreach (var t in locacao.TaxasSelecionadas)
            {
                if (t.TipoTaxa == TipoTaxa.TaxaLocacao)
                {
                    temTaxaLocacao = true;
                    break;
                }
            }
            if (temTaxaLocacao)
            {
                PdfPTable tabelaTaxas = new PdfPTable(3);

                PdfPCell cell1 = new PdfPCell(new Phrase("Taxas selecionadas", fontBold));
                cell1.Colspan = 3;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaTaxas.AddCell(cell1);

                tabelaTaxas.AddCell(new Phrase("Descrição", fontBold));
                tabelaTaxas.AddCell(new Phrase("Valor", fontBold));
                tabelaTaxas.AddCell(new Phrase("Tipo de Cálculo", fontBold));
                foreach (var t in locacao.TaxasSelecionadas)
                {
                    if (t.TipoTaxa == TipoTaxa.TaxaLocacao)
                    {
                        tabelaTaxas.AddCell(new Phrase($"{t.Descricao}", fontNormal));
                        tabelaTaxas.AddCell(new Phrase($"{t.Valor}", fontNormal));
                        tabelaTaxas.AddCell(new Phrase($"{t.TipoCalculo}", fontNormal));
                    }
                }
                doc.Add(tabelaTaxas);

            }


            bool temTaxaDevolucao = false;
            foreach (var t in locacao.TaxasSelecionadas)
            {
                if (t.TipoTaxa == TipoTaxa.TaxaDevolucao)
                {
                    temTaxaDevolucao = true;
                    break;
                }
            }

            if (temTaxaDevolucao)
            {
                PdfPTable tabelaTaxasDevolucao = new PdfPTable(3);

                PdfPCell cellTaxasDevolucaoHeader = new PdfPCell(new Phrase("Taxas de devolução", fontBold));
                cellTaxasDevolucaoHeader.Colspan = 3;
                cellTaxasDevolucaoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaTaxasDevolucao.AddCell(cellTaxasDevolucaoHeader);

                tabelaTaxasDevolucao.AddCell(new Phrase("Descrição", fontBold));
                tabelaTaxasDevolucao.AddCell(new Phrase("Valor", fontBold));
                tabelaTaxasDevolucao.AddCell(new Phrase("Tipo de Cálculo", fontBold));

                foreach (var t in locacao.TaxasSelecionadas)
                {
                    if (t.TipoTaxa == TipoTaxa.TaxaDevolucao)
                    {
                        tabelaTaxasDevolucao.AddCell(new Phrase($"{t.Descricao}", fontNormal));
                        tabelaTaxasDevolucao.AddCell(new Phrase($"{t.Valor}", fontNormal));
                        tabelaTaxasDevolucao.AddCell(new Phrase($"{t.TipoCalculo}", fontNormal));
                    }
                }
                doc.Add(tabelaTaxasDevolucao);
            }

            doc.Add(pulaLinha);
            #endregion

            #region VALORFINAL

            PdfPTable tabelaValores = new PdfPTable(3);
            var taxas = locacao.TaxasSelecionadas;

            PdfPCell cellValorFinalHeader = new PdfPCell(new Phrase("Valor total da locação", fontBold));
            cellValorFinalHeader.Colspan = 3;
            cellValorFinalHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaValores.AddCell(cellValorFinalHeader);

            #region planocobranca

            if (locacao.TipoPlanoSelecionado == TipoPlano.Diario) //diario
            {
                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por dia", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.DiarioValorDia} x {diasL}", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.DiarioValorDia * diasL}", fontNormal));

                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por Km", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.DiarioValorKm} x {nKmpercorridos}", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.DiarioValorKm * nKmpercorridos}", fontNormal));
            }
            else if (locacao.TipoPlanoSelecionado == TipoPlano.Controlado) //diario
            {
                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por dia", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.KmControladoValorDia} x {diasL}", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.KmControladoValorDia * diasL}", fontNormal));

                if (nKmpercorridos > locacao.PlanoCobranca.KmControladoLimiteKm)
                {
                    tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por Km Excedente", fontNormal));
                    tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.KmControladoValorKm} x {nKmpercorridos}", fontNormal));
                    tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.KmControladoValorKm * nKmpercorridos}", fontNormal));
                }
            }
            else if (locacao.TipoPlanoSelecionado == TipoPlano.Livre)
            {
                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por dia", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.KmLivreValorDia} x {diasL}", fontNormal));
                tabelaValores.AddCell(new Phrase($"{locacao.PlanoCobranca.KmLivreValorDia * diasL}", fontNormal));
            }

            #endregion

            #region taxas
            int tipoCalculo;
            foreach (var t in taxas)
            {
                tabelaValores.AddCell(new Phrase($"{t.Descricao}", fontNormal));

                if (t.TipoCalculo == 0) //diario
                    tipoCalculo = diasL;
                else
                    tipoCalculo = 1; //fixo

                tabelaValores.AddCell(new Phrase($"{t.Valor} x {tipoCalculo}", fontNormal));
                tabelaValores.AddCell(new Phrase($"{t.Valor * tipoCalculo}", fontNormal));

            }
            #endregion

            if(locacao.NivelTanqueDevolucao != NivelTanque.Cheio)
            {
                decimal preco = 0;
                string tipo = locacao.Veiculo.TipoCombustivel;
                if (tipo == "Gasolina")
                    preco = configuracaoAplicacao.ConfiguracaoPrecoCombustivel.PrecoGasolina;
                else if(tipo == "Álcool")
                    preco = configuracaoAplicacao.ConfiguracaoPrecoCombustivel.PrecoAlcool;
                else if (tipo == "Diesel")
                    preco = configuracaoAplicacao.ConfiguracaoPrecoCombustivel.PrecoDiesel;
                else if (tipo == "GNV")
                    preco = configuracaoAplicacao.ConfiguracaoPrecoCombustivel.PrecoGNV;

                decimal tanqueEmQuatro = locacao.Veiculo.CapacidadeTanque / 4;

                if (locacao.NivelTanqueDevolucao == NivelTanque.Vazio)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fontNormal));

                    tabelaValores.AddCell(new Phrase($" {preco} x {locacao.Veiculo.CapacidadeTanque}L", fontNormal));               
                  
                    tabelaValores.AddCell(new Phrase($"{Math.Round(preco * locacao.Veiculo.CapacidadeTanque, 2)}", fontNormal));

                }

                else if (locacao.NivelTanqueDevolucao == NivelTanque.UmQuarto)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fontNormal));

                    var dif = tanqueEmQuatro * 3;
                    tabelaValores.AddCell(new Phrase($" {preco} x {dif}L", fontNormal));

                    tabelaValores.AddCell(new Phrase($"{Math.Round(preco * dif, 2)}", fontNormal));
                }
                else if (locacao.NivelTanqueDevolucao == NivelTanque.Meio)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fontNormal));

                    var dif = tanqueEmQuatro * 2;
                    tabelaValores.AddCell(new Phrase($" {preco} x {dif}L", fontNormal));

                    tabelaValores.AddCell(new Phrase($"{Math.Round(preco * dif, 2)}", fontNormal));
                }
                else if (locacao.NivelTanqueDevolucao == NivelTanque.TresQuartos)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fontNormal));

                    var dif = tanqueEmQuatro;

                    tabelaValores.AddCell(new Phrase($" {preco} x {dif}L", fontNormal));

                    tabelaValores.AddCell(new Phrase($"{Math.Round(preco * dif, 2)}", fontNormal));
                }
            }

            doc.NewPage();
            PdfPCell cellValorFinal = new PdfPCell(new Phrase("Valor total", fontBold));
            cellValorFinal.Colspan = 2;
            cellValorFinal.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaValores.AddCell(cellValorFinal);
            tabelaValores.AddCell(new Phrase($"R$ {locacao.ValorTotalEfetivo}", fontBold));
            doc.Add(tabelaValores);
            #endregion

            doc.Close();

        }

        public string GerarNomeArquivo(Locacao locacao)
        {
            string nome = "";

            if (locacao.StatusLocacao == StatusLocacao.Aberta)

                nome = $"relatorio-locacao-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            else
                nome = $"relatorio-devolucao-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            return nome;
        }
    }
}
