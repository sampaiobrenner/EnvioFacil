using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebServiceEF.Classes
{
    [Serializable]
    public class Autenticacao : SoapHeader
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        //public string MD5 { get; set; }
    }
}