using System;

namespace Locadora_Veiculos.Dominio.Compartilhado
{
    public class NaoPodeExcluirEsteRegistroException : Exception
    {

        public NaoPodeExcluirEsteRegistroException(Exception ex) : base("", ex)
        {

        }
    }
}