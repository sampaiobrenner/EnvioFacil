using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ProdutoPlanoVendaDAO : DAOBasicAbstract<ProdutoPlanoVendaDTO>
    {

        public PostgreDB _Pg;

        public ProdutoPlanoVendaDAO ()
        {
            this._Pg = new PostgreDB();
        }

        string sqlInsert =
          @"
                Insert Into
                produto_plano_venda (     idProduto
                                        , descricao
                                        , observacao
                                        , quantidade
                                        , vlUnitario
                                        ,vlFinal )
                Values
                    ({0}, '{1}', '{2}', {3}, {4}, {})
            ";

        public override bool Atualizar(ProdutoPlanoVendaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }

        public override int Count(ProdutoPlanoVendaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ProdutoPlanoVendaDTO obj)
        {
            string strSQL = string.Format(
               this.sqlInsert
               , obj.descricao
               , obj.observacao
               , obj.quantidade
               , obj.vlUnitario
               , obj.vlFinal
               );

            try
            {
                return Convert.ToInt32(this._Pg.ExecuteScalar(strSQL));
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
                this._Pg.FecharConexao();
            }
        }

        public override bool Inserir(List<ProdutoPlanoVendaDTO> obj)
        {
            throw new NotImplementedException();
        }


        public override List<ProdutoPlanoVendaDTO> ObterListagem(ProdutoPlanoVendaDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
