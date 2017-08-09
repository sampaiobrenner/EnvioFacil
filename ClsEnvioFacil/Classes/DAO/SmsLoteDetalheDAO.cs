using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    public class SmsLoteDetalheDAO : DAOBasicAbstract<SmsLoteDetalhoDTO>
    {
        private PostgreDB _PG;
        private string sqlInsert =
        @"
        Insert Into sms_lote_detalhe
        (         
	        IdSmsLote           
	        , IdPessoaDestinatario
	        , IdPessoaTelefone    
	        , Mensagem            
	        , Status              
	        , Retorno             
	        , DataCadastro        
	        , DataRetorno         
        )
        Values
        (
	        {0}           
	        , {1}
	        , {2}    
	        , '{3}'            
	        , {4}              
	        , '{5}'             
	        , '{6}'        
	        , '{7}'  
        ) Returning Id
        ";

        private string sqlUpdate =
        @"
        Update sms_lote_detalhe  Set       
 	        , Status               = {0}              
 	        , Retorno              = '{1}'             
 	        , DataRetorno          = '{2}' 
        Where
	        id = {3}
        ";

        private string sqlCount = "Select Count(0) From sms_lote_detalhe Where 1 = 1 ";

        private string sqlSelect =
        @"
        Select 
	        id                  
	        , ativo               
	        , idSmsLote           
	        , idPessoaDestinatario
	        , idPessoaTelefone    
	        , mensagem            
	        , status              
	        , retorno             
	        , dataCadastro        
	        , dataRetorno
        From
	        sms_lote_detalhe
        Where
	        1 = 1        
        ";

        public SmsLoteDetalheDAO()
        {
            this._PG = new PostgreDB();
        }

        public override bool Atualizar(SmsLoteDetalhoDTO obj)
        {
            bool bRet = false;

            string strSQL = string.Format(
                this.sqlUpdate
                , obj.Status
                , obj.Retorno
                , obj.DataRetorno
                , obj.Id
                );

            try
            {
                this._PG.ExecCommand(strSQL);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._PG.FecharConexao();
            }

            return bRet;
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }

        public override int Count(SmsLoteDetalhoDTO obj)
        {
            string strFiltro = string.Empty;

            if (obj.IdSmsLote > 0)
                strFiltro += string.Format(" And idSmsLote = {0} ", obj.IdSmsLote);

            string strSQL = string.Concat(this.sqlCount, strFiltro);

            int iRet = 0;
            try
            {
                iRet = (int)this._PG.ExecuteScalar(strSQL);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex; 
            }

            return iRet;
        }

        public override bool Inserir(List<SmsLoteDetalhoDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(SmsLoteDetalhoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<SmsLoteDetalhoDTO> ObterListagem(SmsLoteDetalhoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
