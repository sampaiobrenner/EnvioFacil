using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class LogExcessaoBO : BOBasicAbstract<LogExcessaoDTO>
    {
        private LogExcessaoDAO DAO;

        public LogExcessaoBO()
        {
            this.DAO = new LogExcessaoDAO();
        }

        public override int Salvar(LogExcessaoDTO p_dto)
        {
            return this.DAO.Inserir(p_dto);
        }

        public bool Inserir(List<LogExcessaoDTO> p_lstDTO)
        {
            if (p_lstDTO.Count == 0)
                return false;

            return DAO.Inserir(p_lstDTO);
        }

        public int Count()
        {
            return DAO.Count();
        }

        public override LogExcessaoDTO Obter(LogExcessaoDTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<LogExcessaoDTO> ObterLista(LogExcessaoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
