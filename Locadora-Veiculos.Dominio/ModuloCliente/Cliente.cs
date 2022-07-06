using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        #region CONTRUTORES

        public Cliente()
        {
        }

        public Cliente(string nome, string telefone, string email,
            TipoCliente tipoCliente, string documento,
            Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            TipoCliente = tipoCliente;
            Documento = documento;
            Endereco = endereco;
        }

        #endregion

        #region PROPS
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string Documento { get; set; }
        public Endereco Endereco { get; set; }

        #endregion

        public Cliente Clone()
        {
            return MemberwiseClone() as Cliente;
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Telefone == cliente.Telefone &&
                   Email == cliente.Email &&
                   TipoCliente == cliente.TipoCliente &&
                   Documento == cliente.Documento &&
                   EqualityComparer<Endereco>.Default.Equals(Endereco, cliente.Endereco);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Telefone, Email, TipoCliente, Documento, Endereco);
        }

        public override string ToString()
        {
            return $"{Nome} - {Documento}";
        }
    }
}