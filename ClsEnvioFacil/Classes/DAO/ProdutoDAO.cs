using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ProdutoDAO : DAOBasicAbstract<ProdutoDTO>
    {

        private PostgreDB _Pg;

        public ProdutoDAO ()
        {
            this._Pg = new PostgreDB();
        }

        private string sqlInsert =
        @"
            Insert Into produto
                (nome, descricao, codigoVendavel, estoque, vlCustoUnitario, vlVendaUnitario)
            Values
                ('{0}', '{1}', '{2}', {3}, {4}, {5}) Returning Id
        ";

        private string sqlUpdate =
        @"
            Update
                produto
            Set
                ativo                   = {0}
                , nome                  = '{1}'
                , descricao             = '{2}'
                , codigoVendavel        = '{3}'
                , estoque               = {4}
                , vlCustoUnitario       = {5}
                , vlVendaUnitario       = {6}
            Where id = {7}    
        ";

        private string sqlSelect =
        @"
            Select
	            , id              
	            , ativo           
	            , nome        
	            , descricao 
	            , codigoVendavel   
                , estoque 
	            , vlCustoUnitario    
	            , vlVendaUnitario 
            From
	            produto
            Where 1 = 1    
        ";

        private string sqlCount = "Select Count(0) From produto Where 1 = 1 ";

        public override bool Atualizar(ProdutoDTO obj)
        {
            if (obj.id <= 0)
                throw new Exception("O parâmetro ProdutoDTO.ID não pode ser nulo");

            bool bRet = false;

            string strSQL = string.Format(
                this.sqlUpdate
                , obj.ativo
                , obj.nome
                , obj.descricao
                , obj.codigoVendavel
                , obj.estoque
                , obj.vlCustoUnitario
                , obj.vlvendaUnitario
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

        public override int Count(ProdutoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<ProdutoDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(ProdutoDTO obj)
        {

            if (obj == null)
                throw new Exception("O objeto ProdutoDTO não pode ser nulo");

            string strSQL = string.Format(
                this.sqlInsert
                 , obj.ativo
                , obj.nome
                , obj.descricao
                , obj.codigoVendavel
                , obj.estoque
                , obj.vlCustoUnitario
                , obj.vlvendaUnitario
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

        public override List<ProdutoDTO> ObterListagem(ProdutoDTO obj)
        {

            if (obj == null)
                throw new Exception("O objeto ProdutoDTO não pode ser nulo");

            string strSQL = string.Empty;
            if (obj.id > 0)
                strSQL = string.Format(this.sqlSelect, " And id = " + obj.id);

            List<ProdutoDTO> lstProduto = new List<ProdutoDTO>();

            NpgsqlDataReader dr = this._Pg.ExecuteReader(strSQL);
            while (dr.Read())
            {
                lstProduto.Add(
                    new ProdutoDTO
                    {
                        ativo = Convert.ToInt32(dr["ativo"].ToString()),
                        nome = dr["nome"].ToString(),
                        descricao = dr["descricao"].ToString(),
                        id = Convert.ToInt32(dr["id"].ToString()),
                        codigoVendavel = dr["codigoVendavel"].ToString(),
                        estoque = Convert.ToInt32(dr["estoque"].ToString()),
                        vlCustoUnitario = Convert.ToInt32(dr["vlCustoUnitario"].ToString()),
                        vlvendaUnitario = Convert.ToInt32(dr["vlvendaUnitario"].ToString())
                    }
                );
            };

            this._Pg.FecharDataReader(dr);

            return lstProduto;
        }
    }
}
