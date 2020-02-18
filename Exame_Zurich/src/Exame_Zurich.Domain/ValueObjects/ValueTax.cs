namespace Exame_Zurich.Domain.ValueObjects
{
    public class ValueTax
    {
        #region Assessores

        /// <summary>
        /// Taxa de Risco
        /// </summary>
        public decimal TaxRc { get;  set; }
        /// <summary>
        /// Prêmio de Risco
        /// </summary>
        public decimal PmRc { get;  set; }
        /// <summary>
        /// Prêmio Puro
        /// </summary>
        public decimal PmPr { get;  set; }
        /// <summary>
        /// Prêmio Comercial
        /// </summary>
        public decimal PmCm{ get;  set; }
        /// <summary>
        /// Margem de Segurança
        /// </summary>
        public decimal MargSeg { get;  set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Lcr { get;  set; }

        #endregion
        #region Metodos
        public ValueTax(decimal taxRc, decimal pmRc, decimal pmPr, decimal pmMc, int margSeg, int lcr)
        {
            TaxRc = taxRc;
            PmRc = pmRc;
            PmPr = pmPr;
            PmCm = pmMc;
            MargSeg = margSeg;
            Lcr = lcr;
        }
        #endregion

    }
}
