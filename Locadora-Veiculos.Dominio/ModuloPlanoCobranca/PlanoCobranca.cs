using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        #region CONSTRUTORES

        public PlanoCobranca()
        {
        }

        public PlanoCobranca(decimal diarioValorDia, decimal diarioValorKm, decimal kmControladoValorDia,
            decimal kmControladoValorKm, decimal kmControladoLimiteKm, decimal kmLivreValorDia, GrupoVeiculos grupoVeiculos)
        {
            DiarioValorDia = diarioValorDia;
            DiarioValorKm = diarioValorKm;
            KmControladoValorDia = kmControladoValorDia;
            KmControladoValorKm = kmControladoValorKm;
            KmControladoLimiteKm = kmControladoLimiteKm;
            KmLivreValorDia = kmLivreValorDia;
            GrupoVeiculos = grupoVeiculos;
        }

        #endregion

        #region PROPS
        public decimal DiarioValorDia { get; set; }
        public decimal DiarioValorKm { get; set; }
        public decimal KmControladoValorDia { get; set; }
        public decimal KmControladoValorKm { get; set; }
        public decimal KmControladoLimiteKm { get; set; }
        public decimal KmLivreValorDia { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }
        public List<Locacao> Locacoes { get; set; }

        #endregion

        public PlanoCobranca Clone()
        {
            return MemberwiseClone() as PlanoCobranca;
        }

        public void ConfigurarGrupoVeiculos(GrupoVeiculos grupo)
        {
            if (grupo == null)
                return;

            GrupoVeiculos = grupo;
            GrupoVeiculosId = grupo.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is PlanoCobranca cobranca &&
                   Id.Equals(cobranca.Id) &&
                   DiarioValorDia == cobranca.DiarioValorDia &&
                   DiarioValorKm == cobranca.DiarioValorKm &&
                   KmControladoValorDia == cobranca.KmControladoValorDia &&
                   KmControladoValorKm == cobranca.KmControladoValorKm &&
                   KmControladoLimiteKm == cobranca.KmControladoLimiteKm &&
                   KmLivreValorDia == cobranca.KmLivreValorDia &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, cobranca.GrupoVeiculos) &&
                   GrupoVeiculosId.Equals(cobranca.GrupoVeiculosId) &&
                   EqualityComparer<List<Locacao>>.Default.Equals(Locacoes, cobranca.Locacoes);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(DiarioValorDia);
            hash.Add(DiarioValorKm);
            hash.Add(KmControladoValorDia);
            hash.Add(KmControladoValorKm);
            hash.Add(KmControladoLimiteKm);
            hash.Add(KmLivreValorDia);
            hash.Add(GrupoVeiculos);
            hash.Add(GrupoVeiculosId);
            hash.Add(Locacoes);
            return hash.ToHashCode();
        }



        //public override bool Equals(object obj)
        //{
        //    return obj is PlanoCobranca cobranca &&
        //           Id.Equals(cobranca.Id) &&
        //           DiarioValorDia == cobranca.DiarioValorDia &&
        //           DiarioValorKm == cobranca.DiarioValorKm &&
        //           KmControladoValorDia == cobranca.KmControladoValorDia &&
        //           KmControladoValorKm == cobranca.KmControladoValorKm &&
        //           KmControladoLimiteKm == cobranca.KmControladoLimiteKm &&
        //           KmLivreValorDia == cobranca.KmLivreValorDia &&
        //           EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, cobranca.GrupoVeiculos);
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Id, DiarioValorDia, DiarioValorKm, KmControladoValorDia, KmControladoValorKm, KmControladoLimiteKm, KmLivreValorDia, GrupoVeiculos);
        //}
    }
}