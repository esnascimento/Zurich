using Exame_Zurich.Domain.ValueObjects;
using System;

namespace Exame_Zurich.Domain.Seguro
{
    public sealed class Seguro 
    {
        #region Constantes
        /// <summary>
        /// Porcentagem da Margem de Segurança
        /// </summary>
        private const decimal _margSeg = 3;

        /// <summary>
        /// Porcentagem de Lucro
        /// </summary>
        private const decimal _lc = 5;

        #endregion

        #region Assessores
        /// <summary>
        /// Dados do Segurado
        /// </summary>
        public Segurado Segurado { get; set; }
        
        /// <summary>
        /// Dados do Veiculo
        /// </summary>
        public Veiculo Veiculo { get; set; }

        /// <summary>
        /// Valor do Seguro
        /// </summary>
        public decimal ValorSeguro { get; set;}
        public ValueTax ValueTax { get; set; }

        #endregion
        #region Metodos

        public Seguro(Segurado segurado, Veiculo veiculo)
        {
            Segurado = segurado;
            Veiculo = veiculo;
            ValorSeguro = 0;
            ValueTax = new ValueTax(0, 0, 0, 0,0,0);
        }

        public Seguro()
        {
        }

        public void CalcularSeguro()
        {
           ValueTax.TaxRc = (Veiculo.Carro.Valor * 5) / (2 * Veiculo.Carro.Valor);
           ValueTax.PmRc = (ValueTax.TaxRc * Veiculo.Carro.Valor) / 100;
           ValueTax.PmPr = ValueTax.PmRc * (1 + (_margSeg / 100));
           ValueTax.PmCm = ((_lc * ValueTax.PmPr) / 100) + ValueTax.PmPr;
           ValorSeguro = Math.Truncate((ValueTax.PmCm * 100)) / 100;
            ValueTax.MargSeg = _margSeg;
            ValueTax.Lcr = _lc;
        }
        #endregion
    }
}
