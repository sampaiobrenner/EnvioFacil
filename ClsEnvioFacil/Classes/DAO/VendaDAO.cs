using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class VendaDAO : DAOBasicAbstract<VendaDTO>
    {

        PostgreDB _Pg;

        public VendaDAO ()
        {
            _Pg = new PostgreDB();
        }

        string sqlInsert =
         @"
            Insert Into
            venda (   idPessoa
                    , idFormaPagamento
                    , vlTotal
                    , vlDesconto
                    , vlRecebido
                    , excluida
                    , cancelada
                    , dataFinalizacao
                    , dataRetorno
                    , dataCancelamento)
            Values
            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})
            ";

        string sqlUpdate =
            @"
            Update venda Set
	            , excluida               = {0}
	            , cancelada              = {1}
	            , dataFinalizacao        = {2}
	            , dataRetorno            = {3}
	            , dataCancelamento       = {4}
            Where
	            id = {5}
            ";

        string sqlSelect =
            @"
            Select
	            id                 
	            , idPessoa
                , idFormaPagamento
                , vlTotal
                , vlDesconto
                , vlRecebido
                , excluida
                , cancelada
                , dataCadastro
                , dataFinalizacao
                , dataRetorno
                , dataCancelamento
            From
	            venda
            Where 1 = 1             
            ";

        string sqlCount =
            @"
            Select
	            Count(0)  
            From
	            venda
            Where 1 = 1             
            ";

        public override bool Atualizar(VendaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }

        public override int Count(VendaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<VendaDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(VendaDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto VendaDTO não pode ser nulo");

            string strSQL = string.Format(
                this.sqlInsert
                , obj.idPessoa
                , obj.idFormaPagamento
                , obj.vlTotal
                , obj.vlDesconto
                , obj.vlRecebido
                , obj.excluida
                , obj.cancelada
                , obj.dataFinalizacao
                , obj.dataRetorno
                , obj.dataCancelamento
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

        public override List<VendaDTO> ObterListagem(VendaDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
