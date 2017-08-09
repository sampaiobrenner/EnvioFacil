using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    class TipoTelefoneDAO : DAOBasicAbstract<TipoTelefoneDTO>
    {
        private PostgreDB _PG;

        public TipoTelefoneDAO()
        {
            this._PG = new PostgreDB();
        }

        string sqlInsert =
            @"
            Insert Into tipo_telefone(descricao)
            Values
            ('{0}') Returning Id
            ";

        string sqlUpdate =
            @"
            Update tipo_telefone Set
	            , ativo              = {0}
	            , descricao          = '{1}'
            Where
	            id = {2}
            ";

        string sqlSelect =
            @"
            Select
	            id                 
                , ativo
                , descricao
                , dataCadastro
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

        public override bool Atualizar(TipoTelefoneDTO obj)
        {
            bool bRet = false;

            string strSQL = string.Format(
                this.sqlUpdate
                , obj.ativo
                , obj.descricao
                , obj.id
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

        public override int Count(TipoTelefoneDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<TipoTelefoneDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(TipoTelefoneDTO obj)
        {
              string strSQL = string.Format(
                this.sqlInsert
                , obj.descricao
                );

            try
            {
                return Convert.ToInt32(this._PG.ExecuteScalar(strSQL));
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

        }

        public override List<TipoTelefoneDTO> ObterListagem(TipoTelefoneDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
