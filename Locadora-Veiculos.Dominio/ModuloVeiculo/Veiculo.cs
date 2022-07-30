using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_Veiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {

        #region CONSTRUTORES

        public Veiculo()
        {
            this.StatusVeiculo = StatusVeiculo.Disponivel;
        }

        public Veiculo(string modelo, string marca, int ano, string cor, string placa,
            string tipoCombustivel, int quilometragemPercorrida,
            decimal capacidadeTanque, GrupoVeiculos grupoVeiculos, byte[] img) : this()
        {
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Cor = cor;
            Placa = placa;
            TipoCombustivel = tipoCombustivel;
            QuilometragemPercorrida = quilometragemPercorrida;
            CapacidadeTanque = capacidadeTanque;
            GrupoVeiculos = grupoVeiculos;
            Imagem = img;

        }

        #endregion

        #region PROPS

        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string TipoCombustivel { get; set; }
        public int QuilometragemPercorrida { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }
        public StatusVeiculo StatusVeiculo { get; set; }

        public byte[] Imagem { get; set; }




        #endregion

        public void ConfigurarGrupoVeiculos(GrupoVeiculos grupo)
        {
            if (grupo == null)
                return;

            GrupoVeiculos = grupo;
            GrupoVeiculosId = grupo.Id;
        }

        public void AtualizarStatus()
        {
            switch (StatusVeiculo)
            {
                case StatusVeiculo.Locado:
                    StatusVeiculo = StatusVeiculo.Disponivel;
                    break;
                case StatusVeiculo.Disponivel:
                    StatusVeiculo = StatusVeiculo.Locado;
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", Modelo, Marca, Ano, Cor, Placa, TipoCombustivel, QuilometragemPercorrida, CapacidadeTanque, GrupoVeiculos);
        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   Id.Equals(veiculo.Id) &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Ano == veiculo.Ano &&
                   Cor == veiculo.Cor &&
                   Placa == veiculo.Placa &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   QuilometragemPercorrida == veiculo.QuilometragemPercorrida &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, veiculo.GrupoVeiculos) &&
                   StatusVeiculo == veiculo.StatusVeiculo &&
                   Imagem.SequenceEqual(veiculo.Imagem);
        }

    }
}
