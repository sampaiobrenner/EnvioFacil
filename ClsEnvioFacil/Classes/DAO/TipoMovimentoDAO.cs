using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class TipoMovimentoDAO : DAOBasicAbstract<TipoTelefoneDTO>
    {

        private PostgreDB _Pg;

        public TipoMovimentoDAO ()
        {
            this._Pg = new PostgreDB();
        }

        private string sqlInsert =
       @"
        Insert Into tipo_movimento
        (descricao)
        Values
        ('{0}') Returning Id
        ";

        private string sqlUpdate =
        @"
        Update
            tipo_movimento
        Set
            ativo = {0}
            , descricao = {1}
        where
            id = {2}
        ";

        private string sqlSelect =
            @"
            Select
	            , id              
	            , ativo           
	            , descricao        
            From
	            tipo_movimento
            Where 1 = 1    
            ";

        public override bool Atualizar(TipoTelefoneDTO obj)
        {
            if (obj.id <= 0)
                throw new Exception("O parâmetro TipoTelefoneDTO.ID não pode ser nulo");

            bool bRet = false;

            string strSQL = string.Format(this.sqlUpdate, obj.ativo, obj.descricao, obj.id);

            try
            {
                this._Pg.ExecCommand(strSQL);
                bRet = true;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
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
            if (obj == null)
                throw new Exception("O objeto TipoTelefoneDTO não pode ser nulo");

            string strSQL = string.Format(
                this.sqlInsert
                , obj.descricao
                );

            try
            {
                return Convert.ToInt32(this._Pg.ExecuteScalar(strSQL));
            }
            catch (NpgsqlException npgEx)
            {
                throw npgEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._Pg.FecharConexao();
            }
        }

        public override List<TipoTelefoneDTO> ObterListagem(TipoTelefoneDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
