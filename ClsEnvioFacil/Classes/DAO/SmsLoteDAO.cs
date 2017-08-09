using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    public class SmsLoteDAO : DAOBasicAbstract<SmsLoteDTO>
    {

        private PostgreDB _PG;
        string sqlInsert =
            @"
            Insert Into sms_lote(idClienteRemetente, qtdSms, status, envioAgendado, dataAgendada)
            Values
            ({0}, {1}, {2}, {3}, '{4}')
            ";

        string sqlUpdate =
            @"
            Update sms_lote Set
	            , ativo              = {0}
	            , processado         = {1}
	            , qtdSms             = {2}
	            , qtdEnviado         = {3}
	            , qtdErro            = {4}
	            , status             = {5}
	            , dataProcessamento  = '{6}'
            Where
	            id = {7}
            ";

        string sqlSelect =
            @"
            Select
	            id                 
	            , ativo              
	            , processado         
	            , idClienteRemetente 
	            , qtdSms             
	            , qtdEnviado         
	            , qtdErro            
	            , status             
	            , envioAgendado      
	            , dataCadastro       
	            , dataAgendada       
	            , dataProcessamento  
            From
	            sms_lote
            Where 1 = 1             
            ";

        string sqlCount =
            @"
            Select
	            Count(0)  
            From
	            sms_lote
            Where 1 = 1             
            ";


        public SmsLoteDAO()
        {
            this._PG = new PostgreDB();
        }

        public override int Inserir(SmsLoteDTO obj)
        {
            int idLote = 0;

            string strSQL = string.Format(
                this.sqlInsert
                , obj.IdClienteRemetente
                , obj.QtdSms
                , obj.Status
                , obj.EnvioAgendado
                , obj.DataAgendada
                );

            try
            {
                this._PG.BeginTransaction();

                idLote = Convert.ToInt32(this._PG.ExecuteScalar(strSQL));

                if(obj.Itens != null && obj.Itens.Count > 0)
                {
                    SmsLoteDetalheDAO smsDetDAO = new SmsLoteDetalheDAO();

                    foreach(SmsLoteDetalhoDTO smsDetDTO in obj.Itens)
                    {
                        smsDetDAO.Inserir(smsDetDTO);
                    }

                }

                this._PG.CommitTransaction();

            }
            catch (NpgsqlException ex)
            {
                this._PG.RollbackTransaction();
                throw ex;
            }
            catch (Exception ex)
            {
                this._PG.RollbackTransaction();
                throw ex;
            }
            finally
            {
                this._PG.FecharConexao();
            }

            return idLote;
        }

        //[Obsolete]
        public override bool Inserir(List<SmsLoteDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(SmsLoteDTO obj)
        {
            string strFiltro = ObterFiltro(obj);

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

        //[Obsolete]
        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }

        public override bool Atualizar(SmsLoteDTO obj)
        {
            bool bRet = false;

            string strSQL = string.Format(
                this.sqlUpdate
                , obj.Ativo
                , obj.Processado
                , obj.QtdSms
                , obj.QtdEnviado
                , obj.QtdErro
                , obj.Status
                , obj.DataProcessamento
                , obj.Id
                );

            try
            {
                //this._PG.BeginTransaction();
                this._PG.ExecCommand(strSQL);
                //this._PG.CommitTransaction();
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

        public override List<SmsLoteDTO> ObterListagem(SmsLoteDTO obj)
        {
            string strFiltro = ObterFiltro(obj);

            string strSQL = string.Format(this.sqlSelect, strFiltro);

            List<SmsLoteDTO> lstObj = new List<SmsLoteDTO>();

            NpgsqlDataReader dr = null;

            try
            {
                dr = this._PG.ExecuteReader(strSQL);
                ClienteDAO cliDAO = new ClienteDAO();                

                while (dr.Read())
                {

                    SmsLoteDTO smsLoteDTO = new SmsLoteDTO();
                    smsLoteDTO.Id = Convert.ToInt32(dr["id"].ToString());
                    smsLoteDTO.IdClienteRemetente = Convert.ToInt32(dr["idClienteRemetente"].ToString());
                    smsLoteDTO.Ativo = Convert.ToInt32(dr["ativo"].ToString());
                    smsLoteDTO.EnvioAgendado = Convert.ToInt32(dr["envioAgendado"].ToString());
                    smsLoteDTO.Processado = Convert.ToInt32(dr["processado"].ToString());
                    smsLoteDTO.QtdEnviado = Convert.ToInt32(dr["qtdEnviado"].ToString());
                    smsLoteDTO.QtdErro = Convert.ToInt32(dr["qtdErro"].ToString());
                    smsLoteDTO.QtdSms = Convert.ToInt32(dr["qtdSms"].ToString());
                    smsLoteDTO.Status = Convert.ToInt32(dr["status"].ToString());

                    ClienteDTO cliDTO = cliDAO.ObterListagem(new ClienteDTO { Id = smsLoteDTO.IdClienteRemetente })[0];

                    smsLoteDTO.Remetente = cliDTO;

                    lstObj.Add(smsLoteDTO);
                }
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
                this._PG.FecharDataReader(dr);
            }

            return lstObj;
        }

        private string ObterFiltro(SmsLoteDTO obj)
        {
            string strFiltro = string.Empty;

            if (obj.Ativo >= 0)
                strFiltro += string.Format(" And ativo = {0}", obj.Ativo);

            if (obj.EnvioAgendado >= 0)
                strFiltro += string.Format(" And envioAgendado = {0}", obj.EnvioAgendado);

            if (obj.DataAgendada != null)
                strFiltro += string.Format(" And dataAgendada = '{0}' ", obj.DataAgendada);

            if (obj.DataProcessamento != null)
                strFiltro += string.Format(" And dataProcessamento = '{0}' ", obj.DataProcessamento);

            return strFiltro;
        }
    }
}
