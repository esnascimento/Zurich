using Exame_Zurich.Domain.ValueObjects.Comum;

namespace Exame_Zurich.Domain.ValueObjects
{
    public class Name : ValueObject
    {

        #region Assessores
        /// <summary>
        /// Nome do Segurado
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Sobrenome do Segurado
        /// </summary>
        public string LastName { get; private set; }

        #endregion

        #region Metodos

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 3 )
                AddNotification(nameof(FirstName), "Nome inválido.");
        }
        #endregion
    }
}
