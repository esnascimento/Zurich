using Exame_Zurich.Domain.ValueObjects.Comum;

namespace Exame_Zurich.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        #region Assessores
        /// <summary>
        /// CPF do Segurado
        /// </summary>
        public string CPF { get; private set; }

        #endregion

        #region Metodos
        public Documento(string cPF)
        {
            CPF = cPF;

            if (string.IsNullOrWhiteSpace(CPF) || CPF.Length < 11)
                AddNotification(nameof(CPF), "CPF inválido.");
        }

        #endregion
    }
}
