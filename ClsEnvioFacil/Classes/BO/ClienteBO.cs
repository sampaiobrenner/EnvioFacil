using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class ClienteBO : BOBasicAbstract<ClienteDTO>
    {
        private ClienteDAO DAO;

        public ClienteBO()
        {
            this.DAO = new ClienteDAO();
        }

        public override ClienteDTO Obter(ClienteDTO obj)
        {
            List<ClienteDTO> lstDto = this.DAO.ObterListagem(obj);

            if (lstDto != null)
                return lstDto[0];
            else
                return new ClienteDTO { };
        }

        public override List<ClienteDTO> ObterLista(ClienteDTO obj)
        {
            throw new NotImplementedException();
        }

        public override int Salvar(ClienteDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
