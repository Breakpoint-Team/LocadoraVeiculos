using Locadora_Veiculos.Dominio.ModuloCliente;
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
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("ESTADO", registro.Estado);
            comando.Parameters.AddWithValue("CIDADE", registro.Cidade);
            comando.Parameters.AddWithValue("BAIRRO", registro.Bairro);
            comando.Parameters.AddWithValue("RUA", registro.Rua);
            comando.Parameters.AddWithValue("NUMERO", registro.Numero);
            comando.Parameters.AddWithValue("TIPO_CLIENTE", registro.TipoCliente);
            comando.Parameters.AddWithValue("DOCUMENTO", registro.Documento);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var email = Convert.ToString(leitorRegistro["EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["TELEFONE"]);
            var cnh = Convert.ToString(leitorRegistro["CNH"]);
            var estado = Convert.ToString(leitorRegistro["ESTADO"]);
            var cidade = Convert.ToString(leitorRegistro["CIDADE"]);
            var bairro = Convert.ToString(leitorRegistro["BAIRRO"]);
            var rua = Convert.ToString(leitorRegistro["RUA"]);
            var numero = Convert.ToInt32(leitorRegistro["NUMERO"]);
            var tipo = Convert.ToInt32(leitorRegistro["TIPO_CLIENTE"]);
            var documento = Convert.ToString(leitorRegistro["DOCUMENTO"]);

            Cliente cliente = new Cliente()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Cnh = cnh,
                Estado = estado,
                Cidade = cidade,
                Rua = rua,
                Bairro = bairro,
                Numero = numero,
                Documento = documento
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