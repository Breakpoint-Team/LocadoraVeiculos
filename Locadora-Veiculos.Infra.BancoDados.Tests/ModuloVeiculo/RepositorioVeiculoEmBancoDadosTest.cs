using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTest
    {
        private RepositorioVeiculoEmBancoDados repositorioVeiculo;
        private ServicoVeiculo servicoVeiculo;

        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public RepositorioVeiculoEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA");
            Db.ExecutarSql("DELETE FROM TBVEICULO");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS");

            repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //arrange
            var veiculo = NovoVeiculo();

            //action
            var resultadoInsercao =  servicoVeiculo.Inserir(veiculo);

            //assert
            var resultadoSelecao = servicoVeiculo.SelecionarPorId(veiculo.Id);

            var registroEncontrado = resultadoSelecao.Value;

            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(veiculo, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //arrange
            var veiculo = NovoVeiculo();

            servicoVeiculo.Inserir(veiculo);

            veiculo.Cor = "Preto";

            //action
            var resultadoEdicao = servicoVeiculo.Editar(veiculo);

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(veiculo.Id);
         
            var registroEncontrado = resultadoSelecao.Value;
            //assert

            Assert.AreEqual(true, resultadoEdicao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(veiculo, registroEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //arrange
            var veiculo = NovoVeiculo();
            servicoVeiculo.Inserir(veiculo);

            //action
            var resultadoExclusao = servicoVeiculo.Excluir(veiculo);

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(veiculo.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoExclusao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //arrange
            var veiculo = NovoVeiculo();

            servicoVeiculo.Inserir(veiculo);

            //action
            var resultadoSelecao = servicoVeiculo.SelecionarPorId(veiculo.Id);
            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(veiculo, registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //arrange
            var veiculos = NovosVeiculos();
            foreach (var v in veiculos)
                servicoVeiculo.Inserir(v);


            //action
            var resultadoSelecao = servicoVeiculo.SelecionarTodos();
            var registrosEncontrados = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.AreEqual(3, registrosEncontrados.Count);
            Assert.AreEqual(true, registrosEncontrados.Contains(veiculos[0]));
            Assert.AreEqual(true, registrosEncontrados.Contains(veiculos[1]));
            Assert.AreEqual(true, registrosEncontrados.Contains(veiculos[2]));

        }

        [TestMethod]
        public void Nao_deve_inserir_veiculo_com_placa_duplicada()
        {
            //arrange
            var v1 = NovoVeiculo();
            var resultadoInsercaoV1 = servicoVeiculo.Inserir(v1);
            var v2 = NovoVeiculo();
            

            //action
            var resultadoInsercaoV2 = servicoVeiculo.Inserir(v2);

            //assert
            Assert.AreEqual(true, resultadoInsercaoV1.IsSuccess);
            Assert.AreEqual(true, resultadoInsercaoV2.IsFailed);
            Assert.AreEqual("Placa já está cadastrada!", resultadoInsercaoV2.Errors[0].Message);
        }

        #region MÉTODOS PRIVADOS
        private Veiculo NovoVeiculo()
        {

            var gv = NovoGrupoVeiculos();
            servicoGrupoVeiculos.Inserir(gv);

            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABC0J97";
            veiculo.QuilometragemPercorrida = 200;
            veiculo.CapacidadeTanque = 30.00m;
            veiculo.TipoCombustivel = "Gasolina";
            veiculo.Imagem = new byte[3] { 1, 2, 3 };
            veiculo.GrupoVeiculos = gv;

            return veiculo;
        }

        private List<Veiculo> NovosVeiculos()
        {
            var gv = NovoGrupoVeiculos();
            servicoGrupoVeiculos.Inserir(gv);

            var v1 = new Veiculo("Carro Um", "MarcaUm", 2022, "Cinza", "BRA2E19", "Gasolina", 200, 20.00m, gv, new byte[3] { 1, 2, 3 });
            var v2 = new Veiculo("Carro Dois", "MarcaDois", 2022, "Cinza", "PIA2E18", "Gasolina", 200, 20.00m, gv, new byte[3] { 1, 2, 3 });
            var v3 = new Veiculo("Carro Três", "MarcaTres", 2022, "Cinza", "YBC1G29", "Gasolina", 200, 20.00m, gv, new byte[3] { 1, 2, 3 });

            List<Veiculo> veiculos = new List<Veiculo>();
            veiculos.Add(v1);
            veiculos.Add(v2);
            veiculos.Add(v3);

            return veiculos;
        }

        private GrupoVeiculos NovoGrupoVeiculos()
        {
            var g = new GrupoVeiculos();
            g.Nome = "UBER";
            return g;
        }

        #endregion

    }
}
