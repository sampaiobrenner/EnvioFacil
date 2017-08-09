using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class PessoaBO : BOBasicAbstract<PessoaDTO>
    {
        private PessoaDAO _DAO;

        public PessoaBO()
        {
            this._DAO = new PessoaDAO();
        }

        public override int Salvar(PessoaDTO obj)
        {
            if (obj == null)
                throw new ArgumentNullException("O parâmetro PessoaTelefoneDTO não pode ser nulo");

            bool bRet = false;
            int iCount = this._DAO.Count(obj.Id);

            ValidarCampos(ref obj);

            if (iCount == 0)
            {
                return this._DAO.Inserir(obj);
            }
            else
            {
                bRet = this._DAO.Atualizar(obj);

                if (bRet)
                    return obj.Id;
                else
                    return 0;
            }

        }

        public List<PessoaDTO> ObterListagemPessoa(int p_iIdCliente)
        {
            PessoaDTO pDTO = new PessoaDTO();
            pDTO.IdCliente = p_iIdCliente;

            return this._DAO.ObterListagem(pDTO);
        }

        public PessoaDTO ObterPessoa(int p_iId)
        {
            PessoaDTO pDTO = new PessoaDTO();
            pDTO.Id = p_iId;

            return this._DAO.ObterListagem(pDTO)[0];
        }

        public override PessoaDTO Obter(PessoaDTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PessoaDTO> ObterLista(PessoaDTO obj)
        {
            throw new NotImplementedException();
        }

        private void ValidarCampos(ref PessoaDTO p_pDTO)
        {
            if (string.IsNullOrEmpty(p_pDTO.TipoPessoa) || (p_pDTO.TipoPessoa != "F" && p_pDTO.TipoPessoa != "J"))
            {
                p_pDTO.TipoPessoa = (!string.IsNullOrEmpty(p_pDTO.Cnpj)) ? "J" : "F";
            }

        }
    }
}
