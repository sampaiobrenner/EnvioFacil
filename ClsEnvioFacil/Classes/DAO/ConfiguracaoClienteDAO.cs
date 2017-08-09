using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ConfiguracaoClienteDAO : DAOBasicAbstract<ConfiguracaoClienteDTO>
    {

        public PostgreDB _Pg;

        public ConfiguracaoClienteDAO()
        {
            _Pg = new PostgreDB();
        }

        private string sqlInsert =
        @"
            Insert Into 
            configuracao_cliente 
            (idCliente, nome, valor)
            Values
            ({0}, '{1}', '{2}') Returning Id
            ";

        private string sqlUpdate =
            @"
            Update 
	            configuracao_cliente 
            Set 
	            nome = '{0}'
	            , valor = '{1}'
            Where
	            id = {2}
             ";

        public override bool Atualizar(ConfiguracaoClienteDTO obj)
        {
            if (obj.id <= 0)
                throw new Exception("O parametro ConfiguracaoClienteDTO.ID não pode ser nulo.");

            bool bRet = false;

            string strSQL = string.Format(this.sqlUpdate,
                  obj.nome
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

        public override int Count(ConfiguracaoClienteDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<ConfiguracaoClienteDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ConfiguracaoClienteDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto ConfiguracaoClienteDTO não pode ser nulo");

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

        public override List<ConfiguracaoClienteDTO> ObterListagem(ConfiguracaoClienteDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
