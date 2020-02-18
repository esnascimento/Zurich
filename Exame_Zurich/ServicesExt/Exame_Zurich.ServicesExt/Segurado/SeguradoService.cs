using Exame_Zurich.ServicesExt.Repositorio;
using Exame_Zurich.Domain.Seguro;
using Exame_Zurich.Domain.ValueObjects;
using Newtonsoft.Json;

namespace Exame_Zurich.ServicesExt
{
    public class SeguradoService : ISeguradoRep
    {
        public string Json { get; set; }

        public class DadoJson
        {
            public string Nome { get;  set; }
            public string Sobrenome { get;  set; }
            public string CPF { get;  set; }
            public int Idade { get;  set; }
        }


        public SeguradoService()
        {
            string Nome = "Edson";
            string Sobrenome = "Nascimento";
            string CPF = "302.275.448-54";
            string Idade = "85";
            Json =  $"{{\"Nome\":\"{Nome}\",\"Sobrenome\":\"{Sobrenome}\",\"CPF\":\"{CPF}\",\"Idade\":\"{Idade}\"}}";
        }

        public SeguradoService(string json)
        {
            Json = json;
        }
        public Segurado Consultar(string cpf)
        {
            cpf = cpf.ToString()
                   .Replace(".", "")
                   .Replace("-", "")
                   .Replace("/", "");

            DadoJson DadoJson = JsonConvert.DeserializeObject<DadoJson>(Json);
            Segurado Segurado = new Segurado(new Name(DadoJson.Nome, DadoJson.Sobrenome)
                   , new Documento(DadoJson.CPF.ToString()
                   .Replace(".", "")
                   .Replace("-", "")
                   .Replace("/", ""))
                   , new Idade(DadoJson.Idade));

            if (cpf.Equals(Segurado.Documento.CPF))
                return Segurado;

            return null;
        }
    }
}
