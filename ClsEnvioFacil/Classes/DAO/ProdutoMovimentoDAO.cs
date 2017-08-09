using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ProdutoMovimentoDAO : DAOBasicAbstract<ProdutoMovimentoDTO>
    {

        public PostgreDB _PG;

        public ProdutoMovimentoDAO ()
        {
            this._PG = new PostgreDB();
        }

        private string sqlInsert =
          @"
            Insert Into 
            produto_movimento 
            (idProduto, idTipoMovimento, idVenda, qtdEntrada, qtdSaida, qtdFinal, qntAnterior)
            Values
            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) Returning Id
            ";

        private string sqlSelect =
            @"
            Select
	            idProduto, idTipoMovimento, idVenda, qtdEntrada, qtdSaida, qtdFinal, qntAnterior
            From
	            produto_movimento
            Where
	            1 = 1
            ";

        public override bool Atualizar(ProdutoMovimentoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }

        public override int Count(ProdutoMovimentoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<ProdutoMovimentoDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ProdutoMovimentoDTO obj)
        {
            string strSQL = string.Format(
                this.sqlInsert
                , obj.idProduto
                , obj.idTipoMovimento
                , obj.idVenda
                , obj.qtdEntrada
                , obj.qtdFinal
                , obj.qtdFinal
                , obj.qtdAnterior
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

        public override List<ProdutoMovimentoDTO> ObterListagem(ProdutoMovimentoDTO obj)
        {
            if (obj == null)
                throw new Exception("Objeto ProdutoMovimentoDTO não pode ser nulo");

            string strFiltro = string.Empty;

            if (obj.id > 0)
                strFiltro += string.Format(" And id = {0}", obj.id);

            //-------------------------------------------------------------------


            string strSQL = string.Format(this.sqlSelect, strFiltro);

            List<ProdutoMovimentoDTO> lstProdutoMovimento = new List<ProdutoMovimentoDTO>();

            NpgsqlDataReader dr = null;

            try
            {
                dr = this._PG.ExecuteReader(strSQL);

                while (dr.Read())
                {

                    ProdutoMovimentoDTO pDTO = new ProdutoMovimentoDTO();
                    pDTO.id = Convert.ToInt32(dr["id"].ToString());
                    pDTO.idProduto = Convert.ToInt32(dr["idProduto"].ToString());
                    pDTO.idVenda = Convert.ToInt32(dr["idVenda"].ToString());
                    pDTO.idTipoMovimento = Convert.ToInt32(dr["idTipoMovimento"].ToString());
                    pDTO.qtdEntrada = Convert.ToInt32(dr["qtdEntrada"].ToString());
                    pDTO.qtdSaida = Convert.ToInt32(dr["qtdSaida"].ToString());
                    pDTO.qtdAnterior = Convert.ToInt32(dr["qtdAnterior"].ToString());
                    pDTO.qtdFinal = Convert.ToInt32(dr["qtdFinal"].ToString());
                    lstProdutoMovimento.Add(pDTO);
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            finally
            {
                this._PG.FecharDataReader(dr);
            }

            return lstProdutoMovimento;
        }
    }
}
