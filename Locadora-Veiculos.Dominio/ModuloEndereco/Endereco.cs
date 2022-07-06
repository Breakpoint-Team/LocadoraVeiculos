using System;

namespace Locadora_Veiculos.Dominio.ModuloEndereco
{
    public class Endereco
    {
        #region CONSTRUTORES

        public Endereco()
        {
        }

        public Endereco(string estado, string cidade, string bairro,
            string logradouro, int numero)
        {
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
        }

        #endregion

        #region PROPS

        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        #endregion
        
        public override bool Equals(object obj)
        {
            return obj is Endereco endereco &&
                   Estado == endereco.Estado &&
                   Cidade == endereco.Cidade &&
                   Bairro == endereco.Bairro &&
                   Logradouro == endereco.Logradouro &&
                   Numero == endereco.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Estado, Cidade, Bairro, Logradouro, Numero);
        }
    }
}
