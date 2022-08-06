using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCliente = repositorioCliente;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir Cliente... {@Cliente}", cliente);

            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Cliente '{ClienteId}' - {Motivo}",
                        cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + " {ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar Cliente... {@Cliente}", cliente);

            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente {ClienteId} - {Motivo}",
                        cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Cliente";

                Log.Logger.Error(ex, msgErro + " ClienteId", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir Cliente... {@Cliente}", cliente);

            try
            {
                repositorioCliente.Excluir(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "";

                if (ex is DbUpdateException || ex is InvalidOperationException)
                {
                    msgErro = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";

                    contextoPersistencia.DesfazerAlteracoes();
                }
                else
                {
                    msgErro = "Falha no sistema ao tentar excluir o Cliente";
                }

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o cliente";

                Log.Logger.Error(ex, msgErro + " {ClienteId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result<int> QuantidadeClientesCadastrados()
        {
            try
            {
                return Result.Ok(repositorioCliente.QuantidadeClientesCadastrados());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a quantidade de clientes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS

        private Result ValidarCliente(Cliente cliente)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            var resultadoComparacao = DocumentoDuplicado(cliente);

            if (resultadoComparacao.IsSuccess)
            {
                if (resultadoComparacao.Value == true)
                {
                    if (cliente.TipoCliente == TipoCliente.PessoaFisica)
                        erros.Add(new Error("CPF já está cadastrado!"));
                    else if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
                        erros.Add(new Error("CNPJ já está cadastrado!"));
                }
            }
            else
                erros.Add(new Error(resultadoComparacao.Errors[0].Message));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result<bool> DocumentoDuplicado(Cliente cliente)
        {
            try
            {
                var clienteEncontrado = repositorioCliente.SelecionarClientePorDocumento(cliente.Documento);

                var resultadoComparacao = clienteEncontrado != null &&
                       clienteEncontrado.Documento == cliente.Documento &&
                       clienteEncontrado.Id != cliente.Id;

                return Result.Ok(resultadoComparacao);
            }
            catch (ConexaoSqlException ex)
            {
                string msgErro = "Falha no sistema ao tentar comparar o Documento (CPF ou CNPJ) do cliente";

                Log.Logger.Error(ex, msgErro + " {ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        #endregion
    }
}