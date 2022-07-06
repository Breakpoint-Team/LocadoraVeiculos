using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ESTADO", registro.Endereco.Estado);
            comando.Parameters.AddWithValue("CIDADE", registro.Endereco.Cidade);
            comando.Parameters.AddWithValue("BAIRRO", registro.Endereco.Bairro);
            comando.Parameters.AddWithValue("RUA", registro.Endereco.Logradouro);
            comando.Parameters.AddWithValue("NUMERO", registro.Endereco.Numero);
            comando.Parameters.AddWithValue("TIPO_CLIENTE", registro.TipoCliente);
            comando.Parameters.AddWithValue("DOCUMENTO", registro.Documento);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            var nome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            var email = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);
            var tipo = Convert.ToInt32(leitorRegistro["CLIENTE_TIPO_CLIENTE"]);
            var documento = Convert.ToString(leitorRegistro["CLIENTE_DOCUMENTO"]);

            var endereco = new Endereco();
            endereco.Estado = Convert.ToString(leitorRegistro["CLIENTE_ESTADO"]);
            endereco.Cidade = Convert.ToString(leitorRegistro["CLIENTE_CIDADE"]);
            endereco.Bairro = Convert.ToString(leitorRegistro["CLIENTE_BAIRRO"]);
            endereco.Logradouro = Convert.ToString(leitorRegistro["CLIENTE_RUA"]);
            endereco.Numero = Convert.ToInt32(leitorRegistro["CLIENTE_NUMERO"]);


            Cliente cliente = new Cliente()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Documento = documento,
                Endereco = endereco
            };

            cliente.TipoCliente = ConfigurarTipoCliente(tipo);

            return cliente;
        }

        private TipoCliente ConfigurarTipoCliente(int tipo)
        {
            TipoCliente retorno = TipoCliente.PessoaFisica;

            if (tipo == 0)
                retorno = TipoCliente.PessoaFisica;
            else if (tipo == 1)
                retorno = TipoCliente.PessoaJuridica;

            return retorno;
        }
    }
}