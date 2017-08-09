using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace ClsEnvioFacil.Classes
{
    public class PostgreDB
    {
        private string serverName { get; set; }
        private int port { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
        private string databaseName { get; set; }
        private string connString { get; set; }
        private readonly string connString_Modelo = "Server={0};Port={1};User Id={2};Password={3};Database={4};Pooling=true;";
        private NpgsqlConnection pgSqlConnection = null;
        private NpgsqlTransaction pgTransaction;

        public PostgreDB()
        {
            this.serverName = AppConfig.ObterPorNome("server");
            this.port = int.Parse(AppConfig.ObterPorNome("port"));
            this.userName = AppConfig.ObterPorNome("user");
            this.password = AppConfig.ObterPorNome("password");
            this.databaseName = AppConfig.ObterPorNome("database");

            SetStringConexao();
            InicializarVariaveis();           
        }

        public PostgreDB(string p_sIpServidor, int p_iPorta, string p_sUsuario, string p_sSenha, string p_sBdNome)
        {
            this.serverName = p_sIpServidor;
            this.port = p_iPorta;
            this.userName = p_sUsuario;
            this.password = p_sSenha;
            this.databaseName = p_sBdNome;
            
            SetStringConexao();
            InicializarVariaveis();
        }

        private void InicializarVariaveis()
        {
            this.pgSqlConnection = new NpgsqlConnection();
            this.pgSqlConnection.ConnectionString = this.connString;         
        }

        private void SetStringConexao()
        {
            this.connString = string.Format(this.connString_Modelo, this.serverName, this.port, this.userName, this.password, this.databaseName);
        }

        public NpgsqlDataReader ExecuteReader(string p_sql)
        {
            FecharConexao();
            this.pgSqlConnection = new NpgsqlConnection(connString);
            this.pgSqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand(p_sql, this.pgSqlConnection);
            
            NpgsqlDataReader dr = command.ExecuteReader();

            return dr;
        }

        public object ExecuteScalar(string p_sql)
        {
            FecharConexao();
            this.pgSqlConnection = new NpgsqlConnection(connString);
            AbrirConexao();

            NpgsqlCommand command = new NpgsqlCommand(p_sql, this.pgSqlConnection);

            object obj = command.ExecuteScalar();

            return obj;
        }

        public void ExecCommand(string p_sql)
        {
            try
            {
                //using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                //using (this.pgSqlConnection = new NpgsqlConnection(connString))
                //{
                    AbrirConexao();
                    //this.BeginTransaction();

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(p_sql, this.pgSqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();                        
                    }
                //}
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void FecharDataReader(NpgsqlDataReader dr)
        {
            if (!dr.IsClosed)
                dr.Close();
        }

        /// <summary>
        /// Finaliza a conexão de NpgsqlConnection
        /// </summary>
        /// <param name="pgConn"></param>
        public void FecharConexao()
        {
            if (this.pgSqlConnection.State != ConnectionState.Closed)
                this.pgSqlConnection.Close();
        }


        public void AbrirConexao()
        {
            if (this.pgSqlConnection.State != ConnectionState.Open)
                this.pgSqlConnection.Open();
        }


        public void BeginTransaction()
        {
            AbrirConexao();

            this.pgTransaction = (NpgsqlTransaction)this.pgSqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.pgTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            this.pgTransaction.Rollback();
        }

        public void PrepararConexao()
        {
            FecharConexao();
            AbrirConexao();
        }

    }
}
