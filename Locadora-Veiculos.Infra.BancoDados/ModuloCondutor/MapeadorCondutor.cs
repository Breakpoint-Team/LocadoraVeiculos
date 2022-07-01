using Locadora_Veiculos.Dominio.ModuloCondutor;
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
            comando.Parameters.AddWithValue("ESTADO", registro.Estado);
            comando.Parameters.AddWithValue("CIDADE", registro.Cidade);
            comando.Parameters.AddWithValue("BAIRRO", registro.Bairro);
            comando.Parameters.AddWithValue("RUA", registro.Rua);
            comando.Parameters.AddWithValue("NUMERO", registro.Numero);
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
            var estado = Convert.ToString(leitorRegistro["CONDUTOR_ESTADO"]);
            var cidade = Convert.ToString(leitorRegistro["CONDUTOR_CIDADE"]);
            var bairro = Convert.ToString(leitorRegistro["CONDUTOR_BAIRRO"]);
            var rua = Convert.ToString(leitorRegistro["CONDUTOR_RUA"]);
            var numero = Convert.ToInt32(leitorRegistro["CONDUTOR_NUMERO"]);
            var cpf = Convert.ToString(leitorRegistro["CONDUTOR_CPF"]);
            var cnh = Convert.ToString(leitorRegistro["CONDUTOR_CNH"]);
            var dataValidadeCnh = Convert.ToDateTime(leitorRegistro["CONDUTOR_DATA_VALIDADE_CNH"]);

            Condutor condutor = new Condutor()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Estado = estado,
                Cidade = cidade,
                Bairro = bairro,
                Rua = rua,
                Numero = numero,
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