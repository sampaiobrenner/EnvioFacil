using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ProdutoDTO
    {
        public int id { get; set; }
        public int ativo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string codigoVendavel { get; set; }
        public float estoque { get; set; }
        public float vlCustoUnitario { get; set; }
        public float vlvendaUnitario { get; set; }
    }
}
