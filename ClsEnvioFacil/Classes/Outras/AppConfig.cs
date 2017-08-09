using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEnvioFacil.Classes
{
    public static class AppConfig
    {
        public static String ObterPorNome(String p_sAppSetting)
        {
            return ConfigurationManager.AppSettings[p_sAppSetting];
        }

        public static void DefinirPorNome(String p_sName, String p_sValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings[p_sName].Value = p_sValue;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
