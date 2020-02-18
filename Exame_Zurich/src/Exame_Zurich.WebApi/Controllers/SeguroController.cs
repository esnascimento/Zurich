using Exame_Zurich.App.SeguroApp;
using Exame_Zurich.Domain.Parametros.Input;
using Exame_Zurich.ServicesExt.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Exame_Zurich.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SeguroController : Controller
    {
        private readonly SeguroApp _SeguroApp;
        private readonly ISeguradoRep _ISeguradoRep;

        public SeguroController(SeguroApp SeguroApp, ISeguradoRep ISeguradoRep)
        {
            _SeguroApp = SeguroApp;
            _ISeguradoRep = ISeguradoRep;
        }

        [HttpPost]
        [Route("CalcularSeguro")]
        public IActionResult CalcularSeguro([FromBody]SeguroInput Input)
        {
            var result = _SeguroApp.CalcularSeguro(Input);
            return Ok(result.Value);
        }


        [HttpGet]
        [Route("ConsultarSeguro/{CPF}")]
        public IActionResult ObterSeguro(string CPF)
        {
            var result = _SeguroApp.ConsultarSeguro(CPF);
            return Ok(result.Value);
        }
    }
}