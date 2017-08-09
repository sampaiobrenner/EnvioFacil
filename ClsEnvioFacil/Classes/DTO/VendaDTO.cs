using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class VendaDTO
    {
        public int id { get; set; }
        public int idPessoa { get; set; }
        public int idFormaPagamento { get; set; }
        public float vlTotal { get; set; }
        public float vlDesconto { get; set; }
        public float vlRecebido { get; set; }
        public int excluida { get; set; }
        public int cancelada { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataFinalizacao { get; set; }
        public DateTime dataRetorno { get; set; }
        public DateTime dataCancelamento { get; set; }
    }
}
