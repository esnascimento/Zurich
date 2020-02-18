using Exame_Zurich.Domain.ValueObjects.Comum;

namespace Exame_Zurich.Domain.ValueObjects
{
    public class Carro : ValueObject
    {
        #region Assessores
        /// <summary>
        /// Marca do Veiculo
        /// </summary>
        public string Marca { get; }
        /// <summary>
        /// Modelo do Veiculo
        /// </summary>
        public string Modelo { get; }
        /// <summary>
        /// Valor do Veiculo
        /// </summary>
        public decimal Valor { get; }


        #endregion

        #region Metodos

        public Carro(string marca, string modelo, decimal valor)
        {
            Marca = marca;
            Modelo = modelo;
            Valor = valor;
            CarroIsValid();
        }
        
        private void CarroIsValid()
        {
            if (string.IsNullOrWhiteSpace(Marca))
                AddNotification(nameof(Marca), "Marca de veículo inválida.");

            if (string.IsNullOrWhiteSpace(Modelo))
                AddNotification(nameof(Modelo), "Modelo de veículo inválido.");

            if (Valor <= 0)
                AddNotification(nameof(Valor), "Valor não pode ser menor ou igual a zero.");
        }
        #endregion
    }
}
