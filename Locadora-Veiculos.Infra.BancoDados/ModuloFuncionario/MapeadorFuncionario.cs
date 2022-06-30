using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("LOGIN", registro.Login);
            comando.Parameters.AddWithValue("SENHA", registro.Senha);
            comando.Parameters.AddWithValue("DATA_ENTRADA", registro.DataAdmissao);
            comando.Parameters.AddWithValue("SALARIO", registro.Salario);
            comando.Parameters.AddWithValue("IS_ADMIN", registro.EhAdmin);
            comando.Parameters.AddWithValue("ESTA_ATIVO", registro.EstaAtivo);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var login = Convert.ToString(leitorRegistro["LOGIN"]);
            var senha = Convert.ToString(leitorRegistro["SENHA"]);
            var dataAdmissao = Convert.ToDateTime(leitorRegistro["DATA_ENTRADA"]);
            var salario = Convert.ToDecimal(leitorRegistro["SALARIO"]);
            var ehAdmin = Convert.ToBoolean(leitorRegistro["IS_ADMIN"]);
            var estaAtivo = Convert.ToBoolean(leitorRegistro["ESTA_ATIVO"]);

            var f = new Funcionario();
            f.Id = id;
            f.Nome = nome;
            f.Login = login;
            f.Senha = senha;
            f.DataAdmissao = dataAdmissao;
            f.Salario = salario;
            f.EhAdmin = ehAdmin;
            f.EstaAtivo = estaAtivo;

            return f;
        }
    }
}