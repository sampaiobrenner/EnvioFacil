using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using ClsEnvioFacil.Classes;
using WebServiceEF.Classes;

namespace WebServiceEF
{
    /// <summary>
    /// Summary description for WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS : System.Web.Services.WebService
    {

        public Autenticacao _Autenticacao { get; set; }

        private bool UsuarioAutenticado()
        {
            if (string.IsNullOrEmpty(this._Autenticacao.Login) || string.IsNullOrEmpty(this._Autenticacao.Senha))
                return false;

            ClienteBO cBO = new ClienteBO();
            int idCliente = cBO.Obter(new ClienteDTO { Login = this._Autenticacao.Login, Senha = this._Autenticacao.Senha }).Id;

            if (idCliente > 0)
                return true;
            else
                return false;
        }

        [SoapHeader("_Autenticacao")]
        [WebMethod]
        public PessoaDTO GetPessoa(int p_id)
        {
            if (!UsuarioAutenticado())
                throw new Exception("Login inválido");

            if (p_id == 0)
                return null;

            PessoaBO pBO = new PessoaBO();
            return pBO.ObterPessoa(p_id);
        }

        [SoapHeader("_Autenticacao")]
        [WebMethod]
        public int SalvarPessoa(PessoaDTO p_pDTO)
        {
            if (!UsuarioAutenticado())
                throw new Exception("Login inválido");

            PessoaBO pBO = new PessoaBO();
            return pBO.Salvar(p_pDTO);
        }

    }
}
