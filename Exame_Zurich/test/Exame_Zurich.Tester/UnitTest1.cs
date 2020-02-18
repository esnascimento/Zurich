using Exame_Zurich.App.SeguroApp;
using Exame_Zurich.Domain.Parametros.Input;
using Exame_Zurich.Domain.Parametros.Output;
using Exame_Zurich.Domain.Seguro;
using Exame_Zurich.Infra.Repositorio;
using Exame_Zurich.ServicesExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exame_Zurich.Tester
{
    [TestClass]
    public class UnitTest1
    {
        private readonly SeguroApp _App;

        public UnitTest1()
        {
            _App = new SeguroApp(new SeguroRep(), new SeguradoService());
        }

        //[TestMethod]
        //public void Calcular()
        //{

        //    SeguroInput SeguroInput = new SeguroInput()
        //    {
        //        CPF = "30227544854",
        //        ValorVeiculo = 10000,
        //        Marca = "Ford",
        //        Modelo = "Fiesta"
        //    };
        //    SeguroOutput SeguroOutput = _App.CalcularSeguro(SeguroInput);
        //    Assert.AreNotEqual(null, SeguroOutput);
        //    Assert.AreEqual((SeguroOutput.Value as Seguro).ValorSeguro, (decimal)270.37);
        //}
        [TestMethod]
        public void ConsultarSeguro()
        {
            string CPF = "30227544854";
            SeguroOutput SeguroOutput = _App.ConsultarSeguro(CPF);
            Assert.AreNotEqual(null, SeguroOutput);
        }
    }
}
