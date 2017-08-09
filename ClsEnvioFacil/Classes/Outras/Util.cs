using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClsEnvioFacil.Classes
{
    public class Util
    {
        /// <summary>
        /// Retorna a versão atual do Assembly da aplicação: v.2.2.4.2000
        /// </summary>
        /// <returns></returns>
        public static string ObterVersaoApp()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Define algumas propriedades padrões para um datagridview, para que fique um padrão
        /// </summary>
        /// <param name="grd">Grid que se deseja deixar no padrão</param>
        public static void PropriedadesPadroesDataGridView(DataGridView grd)
        {
            grd.RowHeadersVisible = false;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd.AllowUserToAddRows = false;
            grd.AllowUserToResizeRows = false;
            grd.AllowUserToResizeColumns = false;
            grd.EditMode = DataGridViewEditMode.EditOnEnter;
            grd.ReadOnly = true;
        }

        /// <summary>
        /// Remove os principais caracteres especiais que uma string pode conter: |'&\'
        /// </summary>
        /// <param name="p_strPalavra">String X na qual se deseja remover os caracteres especiais</param>
        /// <returns>Retorna uma string X sem os caracteres epseciais</returns>
        public static string RemoveCaracteresEspeciais(string p_strPalavra)
        {
            string p_strRemover = "|'&\'";
            string strCaracterParaRemover;
            int intTamanho = p_strRemover.Length;

            for (int i = 0; i < intTamanho; i++)
            {
                strCaracterParaRemover = p_strRemover.Substring(i, 1);

                p_strPalavra = p_strPalavra.Replace(Convert.ToChar(strCaracterParaRemover), ' ');
            }

            return p_strPalavra;
        }

        /// <summary>
        /// Remove de uma string, caracteres especiais definidos pelo programados
        /// </summary>
        /// <param name="p_strPalavra">String na qual se deseja remover os caracteres especiais</param>
        /// <param name="p_strRemover">Caracteres a remover</param>
        /// <returns>Retorna a string sem os caracteres epseciais</returns>
        public static string RemoveCaracteresEspeciais(string p_strPalavra, string p_strRemover)
        {
            int intTamanho = p_strRemover.Length;
            string strCaracterParaRemover;

            for (int i = 0; i < intTamanho; i++)
            {
                strCaracterParaRemover = p_strRemover.Substring(i, 1);
                p_strPalavra = p_strPalavra.Replace(Convert.ToChar(strCaracterParaRemover), ' ');
            }

            return p_strPalavra;
        }

        /// <summary>
        /// Retorna um booleano que informa se a string possui somente números
        /// </summary>
        /// <returns>True ou false</returns>
        public static bool ContemSomenteNumero(String p_sTexto)
        {
            bool blnTelefone = Regex.IsMatch(p_sTexto, "^[0-9]+$");

            return blnTelefone;
        }
    }
}
