using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int Ativo { get; set; }
        public int IdPessoa { get; set; }
        public int LicencaLiberada { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string AvisoSistema { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string ChaveCripto { get; set; }
        public PessoaDTO Pessoa { get; set; }
    }
}
