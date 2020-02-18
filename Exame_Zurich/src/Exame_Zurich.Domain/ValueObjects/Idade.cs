using Exame_Zurich.Domain.ValueObjects.Comum;

namespace Exame_Zurich.Domain.ValueObjects
{
    public class Idade : ValueObject
    {
        #region Assessores

        /// <summary>
        /// Idade do Segurado   
        /// </summary>
        public int Age { get; private set; }

        #endregion

        #region Metodos
        public Idade(int age)
        {
            Age = age;

            if (Age <18)
                AddNotification(nameof(Age), "Idade não permitida.");
        }
        #endregion
    }
}
