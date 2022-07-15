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

        }



        public Veiculo(string modelo, string marca, int ano, string cor, string placa,
            string tipoCombustivel, int quilometragemPercorrida,
            decimal capacidadeTanque, GrupoVeiculos grupoVeiculos, byte[] img)
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
        public byte[] Imagem { get; set; }




        #endregion

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
                   Imagem.SequenceEqual(veiculo.Imagem);
        }

    }
}
