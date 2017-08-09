using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class LogExcessaoDTO
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public string Mensagem { get; set; }
        public string PilhaDeChamada { get; set; }
        public string Versao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}