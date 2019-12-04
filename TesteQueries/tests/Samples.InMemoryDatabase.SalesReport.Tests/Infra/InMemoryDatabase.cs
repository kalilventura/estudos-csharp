using FluentMigrator.Runner;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Samples.InMemoryDatabase.SalesReport.Tests.Infra.Migrations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace Samples.InMemoryDatabase.SalesReport.Tests.Infra
{
    internal static class InMemoryDatabase
    {
        private static readonly OrmLiteConnectionFactory dbFactory =
            new OrmLiteConnectionFactory(BuildConnectionString(), SqliteOrmLiteDialectProvider.Instance);

        public static IDbConnection Connection => dbFactory.OpenDbConnection();

        public static IMigrationRunner Runner;

        public static void CreateTable()
        {
            var provider = CreateServiceProvider();
            Runner = provider.CreateScope().ServiceProvider.GetRequiredService<IMigrationRunner>();
            Runner.MigrateUp();
        }

        private static string BuildConnectionString()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = "file:UnitTestDb",
                Cache = SqliteCacheMode.Shared,
                Mode = SqliteOpenMode.Memory
            };
            return builder.ConnectionString;
        }

        private static ServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                  .AddFluentMigratorCore()
                  .ConfigureRunner(builder => builder
                                             .AddSQLite()
                                             .WithGlobalConnectionString(BuildConnectionString())
                                             .WithMigrationsIn(typeof(CreateTestTablesMigration).Assembly))
                  .BuildServiceProvider();
        }
    }
}
