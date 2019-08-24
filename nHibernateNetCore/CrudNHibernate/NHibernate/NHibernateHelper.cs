using CrudNHibernate.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNHibernate.NHibernate
{
    public class NHibernateHelper
    {
        private readonly static string path = @"Server=localhost\SQLEXPRESS;Database=Cadastro;Trusted_Connection=True;";
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(path)
                .ShowSql())
               .Mappings(m =>
                         m.FluentMappings
                         .AddFromAssemblyOf<Aluno>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
