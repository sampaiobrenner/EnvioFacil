using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    class ProdutoMovimentoDTO
    {
        public int id { get; set; }
        public int idProduto { get; set; }
        public int idTipoMovimento { get; set; }
        public int idVenda { get; set; }
        public decimal qtdEntrada { get; set; }
        public decimal qtdSaida { get; set; }
        public decimal qtdFinal { get; set; }
        public decimal qtdAnterior { get; set; }
    }
}
