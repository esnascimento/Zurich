using Exame_Zurich.Domain.Seguro;

namespace Exame_Zurich.ServicesExt.Repositorio
{
    public interface ISeguradoRep
    {
        Segurado Consultar(string cpf);
    }
}
