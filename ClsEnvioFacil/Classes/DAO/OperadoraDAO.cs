using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    class OperadoraDAO : DAOBasicAbstract<OperadoraDTO>
    {

        private PostgreDB _PG;

        private string sqlSelect =
            @"
            Select
	            nome
	            , descricao
            From
	            operadora
            Where
	            True
            ";

        public OperadoraDAO ()
        {
            this._PG = new PostgreDB();
        }

        public override int Inserir(OperadoraDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<OperadoraDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(OperadoraDTO obj = null)
        {
            string strFiltro = string.Empty;

            if (obj != null)
            {
                if (!string.IsNullOrEmpty(obj.nome))
                    strFiltro += string.Format(" And nome Like '%{0}%' ", obj.nome);

                if (!string.IsNullOrEmpty(obj.descricao))
                    strFiltro += string.Format(" And descricao Like '%{0}%'", obj.descricao);
            }

            string strSQL = string.Concat(this.sqlSelect, strFiltro);

            int iRet = 0;
            try
            {
                iRet = (int)this._PG.ExecuteScalar(strSQL);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            return iRet;
        }

        public override bool Atualizar(OperadoraDTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<OperadoraDTO> ObterListagem(OperadoraDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto OperadoraDTO não pode ser nulo");

            string strSQL = string.Empty;
            if (obj.id > 0)
                strSQL = string.Format(this.sqlSelect, " And id = " + obj.id);

            List<OperadoraDTO> lstOperadora = new List<OperadoraDTO>();

            NpgsqlDataReader dr = this._PG.ExecuteReader(strSQL);
            while (dr.Read())
            {
                lstOperadora.Add(
                    new OperadoraDTO
                    {
                        ativo = Convert.ToInt32(dr["ativo"].ToString()),
                        nome = dr["nome"].ToString()
                    }
                );
            };

            this._PG.FecharDataReader(dr);

            return lstOperadora;
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }
    }
}
