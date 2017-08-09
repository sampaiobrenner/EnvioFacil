using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ConfiguracaoDAO : DAOBasicAbstract<ConfiguracaoDTO>
    {

        PostgreDB _Pg;

        public ConfiguracaoDAO ()
        {
            _Pg = new PostgreDB();
        }

        private string sqlInsert =
           @"
            Insert Into 
            configuracao 
            (nome, valor)
            Values
            ('{0}', '{1}') Returning Id
            ";

        private string sqlUpdate =
            @"
            Update 
	            configuracao 
            Set 
	            ativo = {0}
	            , nome = '{1}'
	            , valor = '{2}'
            Where
	            id = {3}
             ";

        public override bool Atualizar(ConfiguracaoDTO obj)
        {
            if (obj.id <= 0)
                throw new Exception("O parametro ConfiguracaoDTO.ID não pode ser nulo.");

            bool bRet = false;

            string strSQL = string.Format(this.sqlUpdate,
                obj.ativo
                , obj.nome
                , obj.valor
                , obj.id);

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

        public override int Count(ConfiguracaoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<ConfiguracaoDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ConfiguracaoDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto ConfiguracaoDTO não pode ser nulo");

            string strSQL = string.Format(
                this.sqlInsert
                , obj.nome
                , obj.valor
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

        public override List<ConfiguracaoDTO> ObterListagem(ConfiguracaoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
