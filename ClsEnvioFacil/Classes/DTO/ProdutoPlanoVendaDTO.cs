using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ProdutoPlanoVendaDTO
    {
        public int id { get; set; }
        public int ativo { get; set; }
        public int idProduto { get; set; }
        public string descricao { get; set; }
        public string observacao { get; set; }
        public float quantidade { get; set; }
        public float vlUnitario { get; set; }
        public float vlFinal { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}
