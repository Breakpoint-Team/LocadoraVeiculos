using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using System;
using System.Data.SqlClient;
using System.Text;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("TIPO_COMBUSTIVEL", registro.TipoCombustivel);
            comando.Parameters.AddWithValue("QUILOMETRAGEM_PERCORRIDA", registro.QuilometragemPercorrida);
            comando.Parameters.AddWithValue("CAPACIDADE_TANQUE", registro.CapacidadeTanque);
            comando.Parameters.AddWithValue("ID_GRUPO_VEICULOS", registro.GrupoVeiculos.Id);
            comando.Parameters.AddWithValue("IMAGEM", registro.Imagem);



        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var modelo = Convert.ToString(leitorRegistro["MODELO"]);
            var marca = Convert.ToString(leitorRegistro["MARCA"]);
            var ano = Convert.ToInt32(leitorRegistro["ANO"]);
            var cor = Convert.ToString(leitorRegistro["COR"]);
            var placa = Convert.ToString(leitorRegistro["PLACA"]);
            var tipoCombustivel = Convert.ToString(leitorRegistro["TIPO_COMBUSTIVEL"]);
            var quilometragemPercorrida = Convert.ToInt32(leitorRegistro["QUILOMETRAGEM_PERCORRIDA"]);
            var capacidadeTanque = Convert.ToDecimal(leitorRegistro["CAPACIDADE_TANQUE"]);
            var imagem = Convert.ToString(leitorRegistro["IMAGEM"]);

            byte[] bytes = Encoding.ASCII.GetBytes(imagem);




            return new Veiculo()
            {
                Id = id,
                Modelo = modelo,
                Marca = marca,
                Ano = ano,
                Cor = cor,
                Placa = placa,
                TipoCombustivel = tipoCombustivel,
                QuilometragemPercorrida = quilometragemPercorrida,
                CapacidadeTanque = capacidadeTanque,
                GrupoVeiculos = new MapeadorGrupoVeiculos().ConverterRegistro(leitorRegistro),
                Imagem = bytes
            };

        }
    }
}
