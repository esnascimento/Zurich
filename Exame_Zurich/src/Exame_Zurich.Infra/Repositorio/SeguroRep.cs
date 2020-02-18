using Exame_Zurich.Domain.Parametros.Output;
using Exame_Zurich.Domain.Repositorio;
using Exame_Zurich.Domain.Seguro;
using Exame_Zurich.Domain.ValueObjects;
using Exame_Zurich.Infra.Conexao;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;

namespace Exame_Zurich.Infra.Repositorio
{
    public class SeguroRep : ISeguroRep
    {
        private readonly ConnOracle _connOracle;

        public SeguroRep()
        {
            _connOracle = new ConnOracle();
        }

        public SeguroOutput ConsultarSeguro(string CPF)
        {
            // List<Seguro> ListSeguro = new List<Seguro>(); 
            Seguro seguro = new Seguro();
            using (OracleCommand cmd = _connOracle.GetConnection())
            {
                try
                {
                    cmd.CommandText = "zurich.ExameZurichPk.ConsultarSeguro";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pDocument", OracleDbType.Varchar2, 11).Value = CPF;
                    cmd.Parameters["pDocument"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pCursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();


                    OracleDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        if (Reader.Read())
                        {
                            seguro.Segurado = new Segurado(new Name(Reader["FIRSTNAME"].ToString()
                                                           , Reader["LASTNAME"].ToString())
                                                  , new Documento(Reader["Document"].ToString())
                                                  , new Idade(Convert.ToInt32(Reader["AGE"])));

                            seguro.Veiculo = new Veiculo(new Carro(Reader["MARCA"].ToString()
                                                            , Reader["Modelo"].ToString()
                                                            , Convert.ToDecimal(Reader["Value"])));

                            seguro.ValorSeguro = Convert.ToDecimal(Reader["Value"]);
                        }
                       
                    }
                    if (!Reader.IsClosed) Reader.Close();
                }
                catch (Exception e)
                {
                    throw e;

                }
                finally
                {
                    cmd.Dispose();
                    cmd.Connection.Close();
                }
                return new SeguroOutput(Domain.Enums.EStatusCode.OK, seguro);
            }
        }

        public void IncluirSeguro(Seguro seguro)
        {

            using (OracleCommand cmd = _connOracle.GetConnection())
            {
                try
                {
                    cmd.CommandText = "zurich.ExameZurichPk.IncluirSeguro";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pFIRSTNAME", OracleDbType.Varchar2, 250).Value = seguro.Segurado.Nome.FirstName;
                    cmd.Parameters["pFIRSTNAME"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pLASTNAME", OracleDbType.Varchar2,500).Value = seguro.Segurado.Nome.LastName;
                    cmd.Parameters["pLASTNAME"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pDOCUMENT", OracleDbType.Varchar2, 14).Value = seguro.Segurado.Documento.CPF ;
                    cmd.Parameters["pDOCUMENT"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pDOCUMENTTYPE", OracleDbType.Varchar2,4).Value = seguro.Segurado.Documento.CPF.Length.Equals(11) ? "CPF" : "CNPJ" ;
                    cmd.Parameters["pDOCUMENTTYPE"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pAge", OracleDbType.Int32).Value = seguro.Segurado.Idade.Age;
                    cmd.Parameters["pAge"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pMARCA", OracleDbType.Varchar2, 250).Value = seguro.Veiculo.Carro.Marca;
                    cmd.Parameters["pMARCA"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pMODELO", OracleDbType.Varchar2, 250).Value = seguro.Veiculo.Carro.Modelo;
                    cmd.Parameters["pMODELO"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pVALOR", OracleDbType.Decimal).Value = seguro.ValorSeguro;
                    cmd.Parameters["pVALOR"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pLUCRO", OracleDbType.Decimal).Value = seguro.ValueTax.Lcr;
                    cmd.Parameters["pLUCRO"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pTAXRC", OracleDbType.Decimal).Value = seguro.ValueTax.TaxRc;
                    cmd.Parameters["pTAXRC"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pMARGEMSEG", OracleDbType.Decimal).Value = seguro.ValueTax.MargSeg;
                    cmd.Parameters["pMARGEMSEG"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pPREMIORC", OracleDbType.Decimal).Value = seguro.ValueTax.PmRc;
                    cmd.Parameters["pPREMIORC"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pPREMIOPR", OracleDbType.Decimal).Value = seguro.ValueTax.PmPr;
                    cmd.Parameters["pPREMIOPR"].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("pPREMIOCM", OracleDbType.Decimal).Value = seguro.ValueTax.PmCm;
                    cmd.Parameters["pPREMIOCM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("pSaida", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                    
                        
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;

                }
                finally
                {
                    cmd.Dispose();
                    cmd.Connection.Close();
                }
            }
        }
    }
}


