using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsEnvioFacil.Classes;
using System.Threading;

namespace EnvioFacilServerManager.Src.Forms
{
    public partial class frmPrincipal : Form
    {
        System.Windows.Forms.Timer tmrAtualizarSaldo;

        public frmPrincipal()
        {
            InitializeComponent();
            CarregarPropriedadesTela();
            CarregarComponentes();
            IniciarTimers();
            Teste();
        }

        private void CarregarPropriedadesTela()
        {
            this.Text = string.Format("Envio Fácil Server Manager - v.{0}", Util.ObterVersaoApp());
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        private void CarregarComponentes()
        {
            Util.PropriedadesPadroesDataGridView(grdSmsEnvio);
        }

        private void IniciarTimers()
        {
            tmrAtualizarSaldo = new System.Windows.Forms.Timer();
            tmrAtualizarSaldo.Interval = 120000;
            tmrAtualizarSaldo.Tick += TmrAtualizarSaldo_Tick;
            tmrAtualizarSaldo.Start();
        }

        private void TmrAtualizarSaldo_Tick(object sender, EventArgs e)
        {
            AtualizarSaldoGeralTela_Thread();
        }

        private void AtualizarSaldoGeralTela_Thread()
        {
            Thread threadAtualizarSaldoGeralTela = new Thread(new ThreadStart(AtualizarSaldoGeralTela));
            threadAtualizarSaldoGeralTela.Start();
        }

        private void AtualizarSaldoGeralTela()
        {
            SetTextLabel(lblDscSaldoGeral, "Atualizando saldo");
            LocaSMS sms = new LocaSMS("53984120763", "792086");
            string strSaldo = sms.ObterSaldo();
            SetTextLabel(lblSaldoGeral, strSaldo);
            SetTextLabel(lblDscSaldoGeral, "Saldo");
        }

        private void SetTextLabel(Label p_label, string p_sTexto)
        {
            p_label.Invoke((Action)delegate { p_label.Text = p_sTexto; });          
        }
               
        #region Teste
        private void Teste()
        {
            //LocaSMS locaSMS = new LocaSMS("53984120763", "792086");
            //string saldo = locaSMS.ObterSaldo();

            /*
            LogExcessaoDTO dto = new LogExcessaoDTO { Mensagem = "Msg teste", Modulo = "Módulo teste" };
            LogExcessaoDTO dto2 = new LogExcessaoDTO { Mensagem = "Outra Msg teste", Modulo = "Outro Módulo teste" };
            LogExcessaoDTO dto3 = new LogExcessaoDTO { Mensagem = "3 Msg teste", Modulo = "3 Módulo teste" };
            LogExcessaoDTO dto4 = new LogExcessaoDTO { Mensagem = "4 Msg teste", Modulo = "4 Módulo teste" };
            LogExcessaoBO bo = new LogExcessaoBO();
            List<LogExcessaoDTO> listaLog = new List<LogExcessaoDTO>();
            listaLog.Add(dto);
            listaLog.Add(dto2);
            listaLog.Add(dto3);
            listaLog.Add(dto4);
            bool inseriu = bo.Salvar(dto);
            //bool inseriu2 = bo.Salvar(dto2);

           // bool inseriuLista = bo.Inserir(listaLog);

            int i = bo.Count();
            */


            PessoaDTO pessoaDTO = new PessoaDTO();
            pessoaDTO.Cpf = "12738162266";
            pessoaDTO.DataNascimento = Convert.ToDateTime("1992-10-05");
            pessoaDTO.Email = "pessoa_teste@yahoo.com.br";
            pessoaDTO.IdCliente = 2;
            pessoaDTO.Login = "cliente";
            pessoaDTO.Senha = "123456";
            pessoaDTO.Nome = "Gabriel Silveira da Rosa";



            PessoaBO pessoaBO = new PessoaBO();
            pessoaBO.Salvar(pessoaDTO);

            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.AvisoSistema = "Aviso de teste";
            clienteDTO.ChaveCripto = "123456789102030";
            clienteDTO.IdPessoa = 2;



        }
        #endregion

        #region SMS

        #endregion

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            AtualizarSaldoGeralTela_Thread();
        }
    }
}
