using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    class FormaPagamentoDAO : DAOBasicAbstract<FormaPagamentoDTO>

    {
        private PostgreDB _PG;

        private string sqlInsert =
        @"
            Insert Into forma_pagamento
            (descricao, numeroMaximoParcelas)
            Values
            ('{0}', {1}) Returning Id
        ";

        private string sqlSelect =
        @"
            Select
	            , id              
	            , ativo           
	            , descricao        
	            , numeroMaximoParcelas 
            From
	            forma_pagamento
            Where 1 = 1    
        ";

        private string sqlUpdate =
        @"
            Update
                forma_pagamento
            set
                ativo = {0}
                ,descricao = '{1}'
                ,numeroMaximoParcelas = {2} 
            where
                id = {3}
        ";

        public FormaPagamentoDAO()
        {
            this._PG = new PostgreDB();
        }

        public override bool Atualizar(FormaPagamentoDTO obj)
        {
            if (obj.id <= 0)
                throw new Exception("O parametro FormaPagamentoDTO.ID não pode ser nulo.");

            bool bRet = false;

            string strSQL = string.Format(this.sqlUpdate,
                obj.ativo
                , obj.descricao
                , obj.numeroMaximoParcelas
                , obj.id);

            try
            {
                this._PG.ExecCommand(strSQL);
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

        public override int Count(FormaPagamentoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<FormaPagamentoDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(FormaPagamentoDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto FormaPagamentoDTO não pode ser nulo");

            string strSQL = string.Format(
                this.sqlInsert
                , obj.descricao
                , obj.numeroMaximoParcelas
                );

            try
            {
                return Convert.ToInt32(this._PG.ExecuteScalar(strSQL));
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
                this._PG.FecharConexao();
            }

        }

        public override List<FormaPagamentoDTO> ObterListagem(FormaPagamentoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
