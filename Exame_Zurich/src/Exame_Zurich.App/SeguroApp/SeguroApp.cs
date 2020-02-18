using Exame_Zurich.Domain.Enums;
using Exame_Zurich.Domain.Parametros.Input;
using Exame_Zurich.Domain.Parametros.Output;
using Exame_Zurich.Domain.Repositorio;
using Exame_Zurich.Domain.Seguro;
using Exame_Zurich.Domain.ValueObjects;
using Exame_Zurich.Domain.ValueObjects.Comum;
using Exame_Zurich.ServicesExt.Repositorio;

namespace Exame_Zurich.App.SeguroApp
{
    public class SeguroApp : ValueObject
    {
        private readonly ISeguroRep _ISeguroRep;
        private readonly ISeguradoRep _ISeguradoRep;

        public SeguroApp(ISeguroRep ISeguroRep, ISeguradoRep ISeguradoRep)
        {
            _ISeguroRep = ISeguroRep;
            _ISeguradoRep = ISeguradoRep;
        }

        public SeguroOutput CalcularSeguro(SeguroInput Input)
        {
            Segurado segurado = _ISeguradoRep.Consultar(Input.CPF);
            if (segurado.Notifications.Count > 0)
                return new SeguroOutput(EStatusCode.InternalError, segurado.Notifications);

            Veiculo veiculo = new Veiculo(new Carro(Input.Marca, Input.Modelo, Input.ValorVeiculo));
            Seguro seguro = new Seguro(segurado,veiculo);

          
            if(veiculo.Notifications.Count>0)
                return new SeguroOutput(EStatusCode.InternalError, veiculo.Notifications);
            seguro.CalcularSeguro();
            _ISeguroRep.IncluirSeguro(seguro);

            return new SeguroOutput(EStatusCode.OK, seguro);
        }

        public SeguroOutput ConsultarSeguro(string CPF)
        {
            Segurado segurado = _ISeguradoRep.Consultar(CPF);
            if (segurado == null)
                return new SeguroOutput(EStatusCode.NotFound, " Não foi encontrado registros para este CPF.");
            if (segurado.Invalid)
                return new SeguroOutput(EStatusCode.InternalError, segurado.Notifications);

            var SeguroResult = _ISeguroRep.ConsultarSeguro(CPF);

            if (SeguroResult == null)
                return new SeguroOutput(EStatusCode.NotFound, " Não foi encontrado registros para este CPF.");
            Veiculo veiculo = new Veiculo((SeguroResult.Value as Seguro).Veiculo.Carro);

            if (veiculo.Invalid)
                return new SeguroOutput(EStatusCode.InternalError, veiculo.Notifications);

            var seguro = new Seguro(segurado, veiculo);

            return new SeguroOutput(EStatusCode.OK, seguro);
        }
    }
}
