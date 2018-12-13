using ESX.Data.NHibernate;
using ESX.Domain.Interfaces.UnitWork;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;
using System.Globalization;

namespace ESX.Data.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["SQLServerConn"].ConnectionString;
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the 
            // application lifetime - the first time the UnitOfWork class is used
            _sessionFactory = GetFluentConfig().BuildSessionFactory();
        }

        private static void GenerateScripSchema()
        {
            GetFluentConfig()
                 .ExposeConfiguration(c => new SchemaExport(c).SetOutputFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\schema.sql").Execute(true, false, false))
                 .BuildConfiguration();
        }

        private static void GenerateSchema()
        {
            GetFluentConfig()
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildConfiguration();
        }

        private static FluentConfiguration GetFluentConfig()
        {
            return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnStr).ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssembliesInPath())
                    .ExposeConfiguration(x => x.SetProperty("expiration", "86400"))
                    .ExposeConfiguration(x => x.SetProperty("command_timeout", TimeSpan.FromMinutes(30).TotalSeconds.ToString(CultureInfo.InvariantCulture)));
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
