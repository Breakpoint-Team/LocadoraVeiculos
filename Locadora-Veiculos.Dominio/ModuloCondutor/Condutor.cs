using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        #region CONTRUTORES

        public Condutor()
        {
        }

        public Condutor(string nome, string telefone, string email,
            string cpf, string cnh, DateTime dataValidadeCnh,
           Endereco endereco, Cliente cliente)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            Cnh = cnh;
            DataValidadeCnh = dataValidadeCnh;
            Endereco = endereco;
            Cliente = cliente;
        }

        #endregion

        #region PROPS
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidadeCnh { get; set; }
        public Endereco Endereco { get; set; }
        public Cliente Cliente { get; set; }
        public bool ClienteCondutor
        {
            get
            {
                bool retorno = false;

                if (Cliente != null)
                    if (Cpf == Cliente.Documento)
                        retorno = true;
                    else
                        retorno = false;

                return retorno;
            }
        }

        #endregion

        public Condutor Clone()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   Telefone == condutor.Telefone &&
                   Email == condutor.Email &&
                   Cpf == condutor.Cpf &&
                   Cnh == condutor.Cnh &&
                   DataValidadeCnh == condutor.DataValidadeCnh &&
                   EqualityComparer<Endereco>.Default.Equals(Endereco, condutor.Endereco) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   ClienteCondutor == condutor.ClienteCondutor;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Telefone);
            hash.Add(Email);
            hash.Add(Cpf);
            hash.Add(Cnh);
            hash.Add(DataValidadeCnh);
            hash.Add(Endereco);
            hash.Add(Cliente);
            hash.Add(ClienteCondutor);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"Nome: {Nome} Telefone: {Telefone} Email: {Email}" +
                $" CPF: {Cpf} CNH: {Cnh} Data de validade CNH: {DataValidadeCnh}" +
                $" Cliente: {Cliente.Nome} - {Cliente.Documento}";
        }
    }
}