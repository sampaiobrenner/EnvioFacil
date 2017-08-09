using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ItemVendaDTO
    {
        public int id { get; set; }
        public int idVenda { get; set; }
        public int idProduto { get; set; }
        public float vlUnitario { get; set; }
        public float quantidade { get; set; }
        public float vlTotal { get; set; }
        public int excluido { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataExclusao { get; set; }
    }
}
