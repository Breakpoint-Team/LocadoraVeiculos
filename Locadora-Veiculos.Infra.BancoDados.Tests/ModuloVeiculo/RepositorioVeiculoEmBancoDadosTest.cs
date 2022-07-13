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
            servicoVeiculo.Inserir(veiculo);

            //assert
            var registroEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

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
            servicoVeiculo.Editar(veiculo);

            //assert
            var registroEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

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
            servicoVeiculo.Excluir(veiculo);

            var registroEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            //assert
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //arrange
            var veiculo = NovoVeiculo();

            servicoVeiculo.Inserir(veiculo);

            //action
            var registroEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            //assert
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
            var registrosEncontrados = repositorioVeiculo.SelecionarTodos();

            //assert
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
            servicoVeiculo.Inserir(v1);
            var v2 = NovoVeiculo();

            //action
            var resultado = servicoVeiculo.Inserir(v2);

            //assert
            Assert.AreEqual("Placa já está cadastrada!", resultado.Errors[0].ErrorMessage);
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
