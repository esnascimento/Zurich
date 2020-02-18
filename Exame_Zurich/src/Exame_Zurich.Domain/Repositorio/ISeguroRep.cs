using Exame_Zurich.Domain.Parametros.Output;

namespace Exame_Zurich.Domain.Repositorio
{
    public interface ISeguroRep
    {
        void IncluirSeguro(Seguro.Seguro seguro);
        SeguroOutput ConsultarSeguro(string CPF);
    }
}
