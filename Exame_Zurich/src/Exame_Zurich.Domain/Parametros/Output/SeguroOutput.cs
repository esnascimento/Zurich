
using Exame_Zurich.Domain.Enums;

namespace Exame_Zurich.Domain.Parametros.Output
{
    public class SeguroOutput
    {
        #region Assessores
        /// <summary>
        /// Status de um Seguro
        /// </summary>
        public Enums.EStatusCode StatusCode { get; set; }

        /// <summary>
        /// Objeto de Retorno
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region Metodos
        public SeguroOutput(EStatusCode statusCode, object value)
        {
            StatusCode = statusCode;
            Value = value;
        }

        #endregion
    }
}
