using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    public class ClienteDAO : DAOBasicAbstract<ClienteDTO>
    {
        private PostgreDB _PG;
        private string sqlInsert =
        @"
        Insert Into Cliente
        (idPessoa, avisoSistema, login, senha, chaveCripto)
        Values
        ({0}, '{1}', '{2}', '{3}', (Select MD5(Random()::Text))) Returning Id
        ";

        private string sqlUpdate = "Update cliente Set ativo = {0}, licencaLiberada = {1}, avisoSistema = '{2}', dataAtualizacao = Now() Where Id = {3}";

        private string sqlSelect =
            @"
            Select
	            , id              
	            , ativo           
	            , idPessoa        
	            , licencaLiberada 
	            , avisoSistema    
	            , dataCadastro    
	            , dataAtualizacao 
	            , chaveCripto
                , login
                , senha
            From
	            cliente
            Where 1 = 1    
            ";

        private string sqlCount = "Select Count(0) From pessoa Where 1 = 1 ";

        public ClienteDAO()
        {
            this._PG = new PostgreDB();
        }

        public override bool Atualizar(ClienteDTO obj)
        {
            if (obj.Id <= 0)
                throw new Exception("O parâmetro ClienteDTO.ID não pode ser nulo");

            bool bRet = false;

            string strSQL = string.Format(this.sqlUpdate, obj.Ativo, obj.LicencaLiberada, obj.AvisoSistema, obj.Login, obj.Senha, obj.Id);

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

        //[Obsolete]
        public override int Count(ClienteDTO obj)
        { 
            int iRet = 0;

            try
            {
                iRet = (int)this._PG.ExecuteScalar(sqlCount);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            return iRet;
        }

        public override bool Inserir(List<ClienteDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ClienteDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto ClienteDTO não pode ser nulo");

            string strSQL = string.Format(
                this.sqlInsert
                , obj.IdPessoa
                , obj.AvisoSistema
                , obj.Login
                , obj.Senha
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

        public override List<ClienteDTO> ObterListagem(ClienteDTO obj)
        {
            List<ClienteDTO> lstCDTO = new List<ClienteDTO>();
            string strFiltro = string.Empty;

            if (obj.Id > 0)
                strFiltro += string.Format(" And Id = {0}", obj.Id);

            if (!string.IsNullOrEmpty(obj.Login))
                strFiltro += string.Format(" And Login = '{0}'", obj.Login);

            if (!string.IsNullOrEmpty(obj.Senha))
                strFiltro += string.Format(" And Senha = '{0}'", obj.Senha);

            string strSQL = sqlSelect + strFiltro;

            NpgsqlDataReader dr = this._PG.ExecuteReader(strSQL);
            try
            {              
                while(dr.Read())
                {
                    ClienteDTO cDTO = new ClienteDTO();
                    cDTO.Ativo = Convert.ToInt32(dr["Ativo"].ToString());
                    cDTO.AvisoSistema = dr["AvisoSistema"].ToString();
                    cDTO.LicencaLiberada = Convert.ToInt32(dr["LicencaLiberada"].ToString());
                    cDTO.IdPessoa = Convert.ToInt32(dr["IdPessoa"].ToString());
                    cDTO.Id = Convert.ToInt32(dr["Id"].ToString());
                    cDTO.Login = dr["Login"].ToString();
                    cDTO.Senha = dr["Senha"].ToString();

                    lstCDTO.Add(cDTO);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._PG.FecharConexao();
                this._PG.FecharDataReader(dr);
            }

            return lstCDTO;
        }

        public override int Count(int p_Id)
        {
            int iRet = 0;

            string strSQL = string.Format(this.sqlCount, " And Id = " + p_Id);

            try
            {
                iRet = (int)this._PG.ExecuteScalar(strSQL);
            }
            catch (NpgsqlException npgEx)
            {
                throw npgEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iRet;
        }
    }
}
