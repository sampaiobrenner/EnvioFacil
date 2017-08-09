using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public int Ativo { get; set; }
        public int IdCliente { get; set; }
        private string _Nome;

        public string Nome
        {
            get
            {
                return this._Nome;
            }
            set
            {
                this._Nome = value;

                string[] strArrPalavras = this._Nome.Split(' ');
                int iQtdPalavras = strArrPalavras.Length;

                if(iQtdPalavras > 1)
                {
                    this.PrimeiroNome = strArrPalavras[0].ToString();
                    this.SobreNome = strArrPalavras[iQtdPalavras - 1].ToString();
                }
            }
        }
        
        public string PrimeiroNome { get; set; }
        public string SobreNome { get;  set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string TipoPessoa { get; set; }
        public string Rg { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioSistema { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public List<PessoaTelefoneDTO> PessoaTelefones { get; set; }
    }
}
