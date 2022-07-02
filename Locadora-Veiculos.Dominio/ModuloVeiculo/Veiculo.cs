﻿using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;

namespace Locadora_Veiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo()
        {

        }

        public Veiculo(string modelo, string marca, int ano, string cor, string placa, string tipoCombustivel, int quilometragemPercorrida, int capacidadeTanque, GrupoVeiculos grupoVeiculos)
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
        }

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
       
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", Modelo, Marca, Ano, Cor, Placa, TipoCombustivel, QuilometragemPercorrida, CapacidadeTanque, GrupoVeiculos);
        }



    }
}