using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClsEnvioFacil.LocaSMSSOAP;

namespace ClsEnvioFacil.Classes
{
    public class LocaSMS
    {
        private string _strUsuario;
        private string _strSenha;
        private ServiceSMSSoapClient _serviceSoap;

        public LocaSMS(string p_sUsusario, string p_sSenha)
        {
            this._serviceSoap = new ServiceSMSSoapClient();
            this._strUsuario = p_sUsusario;
            this._strSenha = p_sSenha;

            #region Testes
            // TESTES
            /*
            Destination dest1 = new Destination();
            dest1.Name = "Nome 1";
            dest1.Number = "53984120763";

            Destination dest2 = new Destination();
            dest2.Name = "Nome 2";
            dest2.Number = "53981065455";

            Destination[] arrDest = new Destination[2];
            arrDest[0] = dest1;
            arrDest[1] = dest2;

            LocaSMSSOAP.rSMS r = new rSMS();
            r.Destinations = arrDest;
            r.Msg = "Mensagem de teste. Testando o webservice SOAP";
            r.PropertyChanged += R_PropertyChanged;


            ServiceSMSSoapClient soap = new ServiceSMSSoapClient();
            soap.SendSMS("53984120763", "70792086", r);
            */
            #endregion
        }

        private void R_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public string EnviarSMS(string p_sNomeDestinatario, string p_sNumeroFone, string p_sMsg)
        {
            string strRet = string.Empty;

            Destination[] arrDest = new Destination[1];

            Destination dest = new Destination();
            dest.Name = p_sNomeDestinatario;
            dest.Number = p_sNumeroFone;

            arrDest[0] = dest;

            rSMS sms = new rSMS();
            sms.Destinations = arrDest;

            strRet = this._serviceSoap.SendSMS(this._strUsuario, this._strSenha, sms);

            return strRet;
        }

        public string EnviarSMS(Destination[] p_arrDest, string p_sMsg)
        {
            if (p_arrDest == null)
                return "Nenhum destinatário informado";

            rSMS sms = new rSMS();
            sms.Destinations = p_arrDest;

            string strRet = this._serviceSoap.SendSMS(this._strUsuario, this._strSenha, sms);

            return strRet;
        }

        public string ObterSaldo()
        {
            string strSaldo = this._serviceSoap.GetBalance(this._strUsuario, this._strSenha);

            if (strSaldo.Length > 1)
                if (strSaldo.Substring(0, 1).ToString() == "1")
                    strSaldo = strSaldo.Substring(2, strSaldo.Length - 2);
                else
                    strSaldo = "Erro";

            return strSaldo;
        }
    }
}

