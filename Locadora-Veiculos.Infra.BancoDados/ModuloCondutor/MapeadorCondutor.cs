using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
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
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("DATA_VALIDADE_CNH", registro.DataValidadeCnh);
            comando.Parameters.AddWithValue("ID_CLIENTE", registro.Cliente.Id);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["CONDUTOR_ID"]);
            var nome = Convert.ToString(leitorRegistro["CONDUTOR_NOME"]);
            var email = Convert.ToString(leitorRegistro["CONDUTOR_EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["CONDUTOR_TELEFONE"]);
            var cpf = Convert.ToString(leitorRegistro["CONDUTOR_CPF"]);
            var cnh = Convert.ToString(leitorRegistro["CONDUTOR_CNH"]);
            var dataValidadeCnh = Convert.ToDateTime(leitorRegistro["CONDUTOR_DATA_VALIDADE_CNH"]);

            var endereco = new Endereco();
            endereco.Estado = Convert.ToString(leitorRegistro["CONDUTOR_ESTADO"]);
            endereco.Cidade = Convert.ToString(leitorRegistro["CONDUTOR_CIDADE"]);
            endereco.Bairro = Convert.ToString(leitorRegistro["CONDUTOR_BAIRRO"]);
            endereco.Logradouro = Convert.ToString(leitorRegistro["CONDUTOR_RUA"]);
            endereco.Numero = Convert.ToInt32(leitorRegistro["CONDUTOR_NUMERO"]);

            Condutor condutor = new Condutor()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                Cpf = cpf,
                Cnh = cnh,
                DataValidadeCnh = dataValidadeCnh
            };

            var cliente = new MapeadorCliente().ConverterRegistro(leitorRegistro);
            condutor.Cliente = cliente;

            return condutor;
        }
    }
}