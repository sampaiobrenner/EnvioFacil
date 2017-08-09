using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClsEnvioFacil.Classes
{
    public class PessoaTelefoneDAO : DAOBasicAbstract<PessoaTelefoneDTO>
    {
        private PostgreDB _PG;
        private string sqlInsert =
            @"
            Insert Into pessoa_telefone
            (idPessoa, idTipoTelefone, idOperadora, ddi, ddd, numero, observacao)
            Values
            ({0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}')
            ";

        private string sqlSelect =
            @"
            Select
	            idPessoa
	            , idTipoTelefone
	            , idOperadora
	            , ddi
	            , ddd
	            , numero
	            , observacao
            From
	            pessoa_telefone
            Where
	            True
            ";

        public PessoaTelefoneDAO()
        {
            this._PG = new PostgreDB();
        }

        public override bool Atualizar(PessoaTelefoneDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Count(PessoaTelefoneDTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Inserir(List<PessoaTelefoneDTO> obj)
        {
            throw new NotImplementedException();
        }

        public override int Inserir(PessoaTelefoneDTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PessoaTelefoneDTO> ObterListagem(PessoaTelefoneDTO obj)
        {
            if (obj == null)
                throw new Exception("O objeto PessoaTelefoneDTO não pode ser nulo");

            string strSQL = string.Empty;
            if (obj.IdPessoa > 0)
                strSQL = string.Format(this.sqlSelect, " And idPessoa = " + obj.IdPessoa);

            List<PessoaTelefoneDTO> lstPessoaTel = new List<PessoaTelefoneDTO>();

            NpgsqlDataReader dr = this._PG.ExecuteReader(strSQL);
            while(dr.Read())
            {
                lstPessoaTel.Add(
                    new PessoaTelefoneDTO
                    {
                        Ativo = Convert.ToInt32(dr["ativo"].ToString()),
                        Ddd = dr["ddd"].ToString(),
                        Ddi = dr["ddi"].ToString(),
                        Id = Convert.ToInt32(dr["id"].ToString()),
                        IdOperadora = Convert.ToInt32(dr["idOperadora"].ToString()),
                        IdPessoa = Convert.ToInt32(dr["idPessoa"].ToString()),
                        IdTipoTelefone = Convert.ToInt32(dr["idTipoTelefone"].ToString()),
                        Numero = dr["numero"].ToString(),
                        Observacao = dr["observacao"].ToString()
                    }
                );
            };

            this._PG.FecharDataReader(dr);

            return lstPessoaTel;
        }

        public override int Count(int p_Id)
        {
            throw new NotImplementedException();
        }
    }
}
