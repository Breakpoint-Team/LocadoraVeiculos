﻿using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override void ConfigurarParametros(GrupoVeiculos registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
        }

        public override GrupoVeiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["GRUPOVEICULOS_ID"].ToString());
            var nome = Convert.ToString(leitorRegistro["GRUPOVEICULOS_NOME"]);

            var g = new GrupoVeiculos();
            g.Id = id;
            g.Nome = nome;

            return g;
        }
    }
}