using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class SmsLoteDetalhoDTO
    {
        public int Id { get; set; }
        public int Ativo { get; set; }
        public int IdSmsLote { get; set; }
        public int IdPessoaDestinatario { get; set; }
        public int IdPessoaTelefone { get; set; }
        public string Mensagem { get; set; }
        public int Status { get; set; }
        public string Retorno { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataRetorno { get; set; }
    }
}
