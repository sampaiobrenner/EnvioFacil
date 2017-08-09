using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    public class LogExcessaoDAO : DAOBasicAbstract<LogExcessaoDTO>
    {
        private PostgreDB _PG;
        private readonly string SqlInsert =
            @"Insert Into log_excessao (modulo, mensagem, pilhaDeChamada, versao) Values ('{0}', '{1}', '{2}', '{3}') Returning Id";
        private readonly string SqlCount =
            @"Select Count(0) From log_excessao Where True ";


        public LogExcessaoDAO()
        {
            this._PG = new PostgreDB();
        }

        /// <summary>
        /// Insere um novo registro de log
        /// </summary>
        /// <param name="p_DTO"></param>
        /// <returns></returns>
        public override int Inserir(LogExcessaoDTO p_DTO)
        {
            this._PG.PrepararConexao();

            string strSQL = string.Format(
                this.SqlInsert
                , p_DTO.Modulo
                , p_DTO.Mensagem
                , p_DTO.PilhaDeChamada
                , p_DTO.Versao
                );           

            try
            {
                //this._PG.BeginTransaction();
                return Convert.ToInt32(this._PG.ExecuteScalar(strSQL));
                //this._PG.CommitTransaction();
            }
            catch (NpgsqlException ex)
            {
                //this._PG.RollbackTransaction();
                throw ex;
            }
            catch (Exception ex)
            {
                //this._PG.RollbackTransaction();
                throw ex;
            }
            finally
            {
                this._PG.FecharConexao();
            }

        }

        /// <summary>
        /// Insere uma lista de logs
        /// </summary>
        /// <param name="p_lstDTO"></param>
        /// <returns></returns>
        public override bool Inserir(List<LogExcessaoDTO> p_lstDTO)
        {
            bool bRet = false;
            this._PG.PrepararConexao();
            try
            {
                this._PG.BeginTransaction();
                foreach (LogExcessaoDTO pDTO in p_lstDTO)
                {
                    string strSQL = string.Format(
                                        this.SqlInsert
                                        , pDTO.Modulo
                                        , pDTO.Mensagem
                                        , pDTO.PilhaDeChamada
                                        , pDTO.Versao
                                    );

                    this._PG.ExecCommand(strSQL);
                }

                this._PG.CommitTransaction();
                bRet = true;
            }
            catch (NpgsqlException ex)
            {
                this._PG.RollbackTransaction();
                throw ex;
            }
            finally
            {
                this._PG.FecharConexao();
            }

            return bRet;
        }

        /// <summary>
        /// Retorna a quantidade de registros da tabela log_excessoes
        /// Pode ou não possui parâmetros
        /// </summary>
        /// <param name="p_dto"></param>
        /// <returns></returns>
        public override int Count(LogExcessaoDTO p_dto = null)
        {
            string strCondicao = string.Empty;
            this._PG.PrepararConexao();

            if (p_dto != null)
            {
                if (p_dto.Id > 0)
                    strCondicao += string.Format(" And Id = {0}", p_dto.Id);

                if (!string.IsNullOrEmpty(p_dto.Mensagem))
                    strCondicao += string.Format(" And Mensagem Like'%{0}%' ", p_dto.Mensagem);

                if (!string.IsNullOrEmpty(p_dto.Modulo))
                    strCondicao += string.Format(" And Mensagem = '{0}' ", p_dto.Modulo);

                if (!string.IsNullOrEmpty(p_dto.Versao))
                    strCondicao += string.Format(" And Mensagem = '{0}' ", p_dto.Versao);
            }

            string strSQL = string.Format(this.SqlCount, strCondicao);
            int iCount = 0;

            try
            {
                iCount = Convert.ToInt32(this._PG.ExecuteScalar(strSQL));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._PG.FecharConexao();
            }

            return iCount;
        }

        public override bool Atualizar(LogExcessaoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<LogExcessaoDTO> ObterListagem(LogExcessaoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }
    }
}
