using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class PessoaTelefoneDTO
    {
        public int Id { get; set; }
        public int Ativo { get; set; }
        public int IdPessoa { get; set; }
        public int IdTipoTelefone { get; set; }
        public int IdOperadora { get; set; }
        public string Ddi { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public string Observacao { get; set; }
    }
}
