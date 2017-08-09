using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ConfiguracaoDTO
    {
        public int id { get; set; }
        public int ativo { get; set; }
        public string nome { get; set; }
        public string valor { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataAlteracao { get; set; }
    }
}
