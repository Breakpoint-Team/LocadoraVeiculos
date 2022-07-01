using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
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
            int numero, string rua, string bairro, string cidade, string estado, Cliente cliente)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            Cnh = cnh;
            DataValidadeCnh = dataValidadeCnh;
            Numero = numero;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
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
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Cliente Cliente { get; set; }

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
                   Numero == condutor.Numero &&
                   Rua == condutor.Rua &&
                   Bairro == condutor.Bairro &&
                   Cidade == condutor.Cidade &&
                   Estado == condutor.Estado &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente);
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
            hash.Add(Numero);
            hash.Add(Rua);
            hash.Add(Bairro);
            hash.Add(Cidade);
            hash.Add(Estado);
            hash.Add(Cliente);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"Nome: {Nome} Telefone: {Telefone} Email: {Email}" +
                $" CPF: {Cpf} CNH: {Cnh} Data de validade CNH: {DataValidadeCnh}" +
                $" Número: {Numero} Rua: {Rua} Bairro: {Bairro}" +
                $" Cidade: {Cidade} Estado: {Estado} Cliente: {Cliente.Nome} - {Cliente.Documento}";
        }
    }
}