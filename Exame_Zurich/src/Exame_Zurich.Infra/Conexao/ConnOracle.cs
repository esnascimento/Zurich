using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using ConfigurationSettings = System.Configuration.ConfigurationManager;
namespace Exame_Zurich.Infra.Conexao
{
    public sealed class ConnOracle
    {
        private readonly string strOracle = ConfigurationSettings.AppSettings["Oracle"];


        public OracleCommand GetConnection()
        {
            OracleCommand cmd = new OracleCommand()
            {
                CommandTimeout = 9999,
                Connection = new OracleConnection(strOracle)
            };
            return cmd;
        }      
    }
}
