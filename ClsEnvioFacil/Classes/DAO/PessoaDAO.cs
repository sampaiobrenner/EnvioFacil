using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClsEnvioFacil.Classes
{
    class PessoaDAO : DAOBasicAbstract<PessoaDTO>
    {
        public PostgreDB _PG;
        private string sqlInsert =
            @"
            Insert Into 
            pessoa 
            (idCliente, nome, primeiroNome, sobreNome, razaoSocial, nomeFantasia, email, login, senha, tipoPessoa, rg, inscricaoEstadual, inscricaoMunicipal, cpf, cnpj, dataNascimento, usuarioSistema)
            Values
            ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', {14}) Returning Id
            ";

        private string sqlUpdate =
            @"
            Update 
	            pessoa 
            Set 
	            idCliente = {0}
	            , nome = '{1}'
	            , primeiroNome = '{2}'
	            , sobreNome = '{3}'
	            , razaoSocial = '{4}'
	            , nomeFantasia = '{5}'
	            , email = '{6}'
	            , tipoPessoa = '{7}'
	            , rg = '{8}'
	            , inscricaoEstadual = '{9}'
	            , inscricaoMunicipal = '{10}'
	            , cpf = '{11}'
	            , cnpj = '{12}'
	            , dataNascimento = '{13}'
	            , usuarioSistema = {14}
            Where
	            Codigo = {15}
             ";

        private string sqlSelect =
            @"
            Select
	            idCliente
	            , nome
	            , primeiroNome
	            , sobreNome
	            , razaoSocial
	            , nomeFantasia
	            , email
	            , tipoPessoa
	            , rg
	            , inscricaoEstadual
	            , inscricaoMunicipal
	            , cpf
	            , cnpj
	            , dataNascimento
	            , usuarioSistema
            From
	            pessoa
            Where
	            1 = 1
            ";

        private string sqlCount = "Select Count(0) From pessoa Where 1 = 1 ";

        public PessoaDAO()
        {
            this._PG = new PostgreDB();
        }

        public override int Inserir(PessoaDTO obj)
        {
            string strSQL = string.Format(
                this.sqlInsert
                , obj.IdCliente
                , obj.Nome
                , obj.PrimeiroNome
                , obj.SobreNome
                , obj.RazaoSocial
                , obj.NomeFantasia
                , obj.Email
                , obj.TipoPessoa
                , obj.Rg
                , obj.InscricaoEstadual
                , obj.InscricaoMunicipal
                , obj.Cpf
                , obj.Cnpj
                , obj.DataNascimento
                , obj.UsuarioSistema
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




        //idCliente, nome, primeiroNome, sobreNome, razaoSocial, nomeFantasia, 
        //email, login, senha, tipoPessoa, rg, inscricaoEstadual, inscricaoMunicipal, 
        //cpf, cnpj, dataNascimento, usuarioSistema

        public override bool Inserir(List<PessoaDTO> obj)
        {
            throw new NotImplementedException("");
        }

        public override int Count(PessoaDTO obj = null)
        {
            string strFiltro = string.Empty;

            if (obj != null)
            {
                if (!string.IsNullOrEmpty(obj.Nome))
                    strFiltro += string.Format(" And nome Like '%{0}%' ", obj.Nome);

                if (obj.IdCliente > 0)
                    strFiltro += string.Format(" And idCliente = {0} ", obj.IdCliente);
            }

            string strSQL = string.Concat(this.sqlCount, strFiltro);

            int iRet = 0;
            try
            {
                iRet = (int)this._PG.ExecuteScalar(strSQL);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iRet;
        }

        public override int Count(int p_iID)
        {
            if (p_iID == 0)
                return 0;

            string strFiltro = string.Empty;

            strFiltro += string.Format(" And id = {0} ", p_iID);

            string strSQL = string.Concat(this.sqlCount, strFiltro);

            int iRet = 0;
            try
            {
                iRet = (int)this._PG.ExecuteScalar(strSQL);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iRet;
        }

        public override bool Atualizar(PessoaDTO obj)
        {
            bool bRet = false;
            string strSQL = string.Format(
                this.sqlUpdate
                , obj.IdCliente
                , obj.Nome
                , obj.PrimeiroNome
                , obj.SobreNome
                , obj.RazaoSocial
                , obj.NomeFantasia
                , obj.Email
                , obj.TipoPessoa
                , obj.Rg
                , obj.InscricaoEstadual
                , obj.InscricaoMunicipal
                , obj.Cpf
                , obj.Cnpj
                , obj.DataNascimento
                , obj.UsuarioSistema
                , obj.Id
                );

            try
            {
                //this._PG.BeginTransaction();
                this._PG.ExecCommand(strSQL);
                //this._PG.CommitTransaction();
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

            return bRet;
        }

        public override List<PessoaDTO> ObterListagem(PessoaDTO obj)
        {
            if (obj == null)
                throw new Exception("Objeto PessoaDTO não pode ser nulo");

            string strFiltro = string.Empty;

            if (obj.Id > 0)
                strFiltro += string.Format(" And Id = {0}", obj.Id);

            if (!string.IsNullOrEmpty(obj.Nome))
                strFiltro += string.Format(" And Nome Like '%{0}%'", obj.Nome);

            if (obj.IdCliente > 0)
                strFiltro += string.Format(" And idCliente = {0}", obj.IdCliente);

            //-------------------------------------------------------------------


            string strSQL = string.Format(this.sqlSelect, strFiltro);

            List<PessoaDTO> lstPessoa = new List<PessoaDTO>();

            NpgsqlDataReader dr = null;

            try
            {
                dr = this._PG.ExecuteReader(strSQL);

                PessoaTelefoneDAO pFoneDAO = new PessoaTelefoneDAO();

                while (dr.Read())
                {

                    PessoaDTO pDTO = new PessoaDTO();
                    pDTO.Id = Convert.ToInt32(dr["id"].ToString());
                    pDTO.Nome = dr["nome"].ToString();
                    pDTO.Ativo = Convert.ToInt32(dr["ativo"].ToString());
                    pDTO.Cnpj = dr["cnpj"].ToString();
                    pDTO.Cpf = dr["cpf"].ToString();
                    pDTO.DataAtualizacao = Convert.ToDateTime(dr["dataAtualizacao"].ToString());
                    pDTO.DataCadastro = Convert.ToDateTime(dr["DataCadastro"].ToString());
                    pDTO.DataNascimento = Convert.ToDateTime(dr["DataNascimento"].ToString());
                    pDTO.Email = dr["email"].ToString();
                    pDTO.IdCliente = Convert.ToInt32(dr["idCliente"].ToString());
                    pDTO.InscricaoEstadual = dr["InscricaoEstadual"].ToString();
                    pDTO.InscricaoMunicipal = dr["InscricaoMunicipal"].ToString();
                    pDTO.NomeFantasia = dr["NomeFantasia"].ToString();
                    pDTO.RazaoSocial = dr["RazaoSocial"].ToString();
                    pDTO.Rg = dr["Rg"].ToString();
                    pDTO.Sexo = dr["Sexo"].ToString();
                    pDTO.TipoPessoa = dr["TipoPessoa"].ToString();
                    pDTO.UsuarioSistema = Convert.ToInt32(dr["UsuarioSistema"].ToString());

                    List<PessoaTelefoneDTO> pLstFoneDTO = new List<PessoaTelefoneDTO>();
                    pLstFoneDTO = pFoneDAO.ObterListagem(new PessoaTelefoneDTO { IdPessoa = pDTO.Id });

                    pDTO.PessoaTelefones = pLstFoneDTO;

                    lstPessoa.Add(pDTO);
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

            return lstPessoa;
        }
    }
}
