using Exame_Zurich.Domain.ValueObjects;
using Exame_Zurich.Domain.ValueObjects.Comum;

namespace Exame_Zurich.Domain.Seguro
{
    public sealed class Segurado : ValueObject
    {

        #region Assessores
        ///// <summary>
        ///// Nome e Sobrenome do Segurado
        ///// </summary>
        public Name Nome { get; private set; }
        ///// <summary>
        ///// Documento do Segurado (CPF/CNPJ)
        ///// </summary>
        public Documento Documento { get; private set; }
        /// <summary>
        /// Idade do Segurado(Permitido acima de 18)   
        /// </summary>
        public Idade Idade { get; private set; }

        #endregion

        #region Metodos
        public Segurado(Name nome, Documento documento, Idade idade)
        {
            Nome = nome;
            Documento = documento;
            Idade = idade;
            AddNotifications(nome, documento, idade);
        }

        #endregion

    }
}
