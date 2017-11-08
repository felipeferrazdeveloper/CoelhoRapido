using CoelhoRapido.Model.Utils;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using System;
using System.Web;
using CoelhoRapido.Model.Database.Repository;

namespace CoelhoRapido.Model.Database
{
    public class DBConfig
    {
        private static DBConfig _instance = null;

        private ISessionFactory _sessionFactory;

        public RepositoryCliente RepositoryCliente { get; set; }
        public RepositoryEndereco RepositoryEndereco { get; set; }
        public RepositoryEntrega RepositoryEntrega { get; set; }
        public RepositoryVolume RepositoryVolume { get; set; }

        private DBConfig()
        {
            Conectar();

            this.RepositoryCliente = new RepositoryCliente(Session);
            this.RepositoryEndereco = new RepositoryEndereco(Session);
            this.RepositoryEntrega = new RepositoryEntrega(Session);
            this.RepositoryVolume = new RepositoryVolume(Session);
        }

        public static DBConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBConfig();
                }

                return _instance;
            }
        }



        private void Conectar()
        {
            try
            {
                var iniFile = IniUtils.LerArquivoIni();

                var stringConexao = "Persist Security Info=True;"
                                    + "server=" + iniFile["DbConfig"]["host"] + ";"
                                    + "port=" + iniFile["DbConfig"]["port"] + ";"
                                    + "database=" + iniFile["DbConfig"]["db"] + ";"
                                    + "uid=" + iniFile["DbConfig"]["user"] + ";"
                                    + "pwd=" + iniFile["DbConfig"]["pwd"];

                var mysql = new MySqlConnection(stringConexao);
                try
                {
                    mysql.Open();
                }
                catch
                {
                    CriarSchemaBanco(iniFile["DbConfig"]["host"], iniFile["DbConfig"]["port"], iniFile["DbConfig"]["db"], iniFile["DbConfig"]["pwd"], iniFile["DbConfig"]["user"]);
                }
                finally
                {
                    mysql.Close();
                }
                ConectarNHibernate(stringConexao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao banco de dados.", ex);
            }
        }

        private void ConectarNHibernate(string stringConexao)
        {
            try
            {
                var config = new Configuration();

                ConfigureLog4Net();

                //configira a conexao com o banco
                config.DataBaseIntegration(db =>
                {
                    //dialeto do SQL
                    db.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //string de conexao
                    db.ConnectionString = stringConexao;
                    //driver de conexao
                    db.Driver<NHibernate.Driver.MySqlDataDriver>();
                    //provedor de conexao
                    db.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    //Jeito de Criacao do banco de dados
                    db.SchemaAction = SchemaAutoAction.Update;

                    db.LogSqlInConsole = true;
                    db.LogFormattedSql = true;
                });

                var maps = this.Mapeamento();

                config.AddMapping(maps);

                if (HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }

                this._sessionFactory = config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar o NHibernate.", ex);
            }
        }

        private HbmMapping Mapeamento()
        {
            try
            {
                var modelMapper = new ModelMapper();

                //modelMapper.AddMappings(

                //Assembly.GetAssembly(typeof(InstituicaoMap)).GetTypes());

                return modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch (Exception ex)
            {
                throw new Exception("Nao foi possível fazer o mapeamento.", ex);
            }
        }

        private void CriarSchemaBanco(string server, string port, string dbName, string psw, string user)
        {
            try
            {
                var stringConexao = "server=" + server + ";"
                                    + "port=" + port + ";"
                                    + "uid=" + user + ";"
                                    + "pwd=" + psw + ";";

                var mysql = new MySqlConnection(stringConexao);
                var cmd = mysql.CreateCommand();

                mysql.Open();
                cmd.CommandText = "CREATE DATABASE IF NOT EXISTS `" + dbName + "`;";
                cmd.ExecuteNonQuery();
                mysql.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível criar o banco de dados.", ex);
            }
        }

        private ISession Session
        {
            get
            {
                try
                {
                    if (CurrentSessionContext.HasBind(_sessionFactory))
                    {
                        return _sessionFactory.GetCurrentSession();
                    }

                    var session = _sessionFactory.OpenSession();

                    CurrentSessionContext.Bind(session);

                    return session;
                }
                catch (Exception ex)
                {

                    throw new Exception("Não foi possível criar a sessão", ex);
                }
            }
        }

        public static void ConfigureLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}