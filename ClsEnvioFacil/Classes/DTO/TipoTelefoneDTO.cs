using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class TipoTelefoneDTO
    {
        public int id { get; set; }
        public int ativo { get; set; }
        public string descricao { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}
