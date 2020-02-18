using Exame_Zurich.Domain.ValueObjects;
using Exame_Zurich.Domain.ValueObjects.Comum;

namespace Exame_Zurich.Domain.Seguro
{
    public sealed class Veiculo : ValueObject
    {
        #region Assessores
        
        /// <summary>
        /// Modelo e Marca e valor do carro
        /// </summary>
        public Carro Carro { get; private set; }

        #endregion

        #region Metodos
        public Veiculo(Carro carro)
        {
            Carro = carro;
            AddNotifications(Carro);
        }

        #endregion
    }
}
