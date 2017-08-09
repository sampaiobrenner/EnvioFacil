using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class SmsLoteDTO
    {
        public int Id { get; set; }
        public int Ativo { get; set; }
        public int Processado { get; set; }
        public int IdClienteRemetente { get; set; }
        public int QtdSms { get; set; }
        public int QtdEnviado { get; set; }
        public int QtdErro { get; set; }
        public int Status { get; set; }
        public int EnvioAgendado { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAgendada { get; set; }
        public DateTime DataProcessamento { get; set; }
        public ClienteDTO Remetente;
        public List<SmsLoteDetalhoDTO> Itens;
    }
}
