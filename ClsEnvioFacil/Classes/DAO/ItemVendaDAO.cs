using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ItemVendaDAO : DAOBasicAbstract<ItemVendaDTO>
    {
 
        public PostgreDB _Pg;

        public ItemVendaDAO()
        {
            _Pg = new PostgreDB();
        }

        string sqlInsert =
       @"
            Insert Into
            item_venda (  idVenda
                        , idProduto
                        , vlUnitario
                        , quantidade
                        , vlTotal )
            Values
                ({0}, {1}, {2}, {3}, {4})
        ";

        public override bool Atualizar(ItemVendaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }

        public override int Count(ItemVendaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ItemVendaDTO obj)
        {
            string strSQL = string.Format(
                 this.sqlInsert
                 , obj.idVenda
                 , obj.idProduto
                 , obj.vlUnitario
                 , obj.quantidade
                 , obj.vlTotal
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

        public override bool Inserir(List<ItemVendaDTO> obj)
        {
            throw new NotImplementedException();
        }


        public override List<ItemVendaDTO> ObterListagem(ItemVendaDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
