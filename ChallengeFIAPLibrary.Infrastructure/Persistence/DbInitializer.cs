using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WriteDbContext(serviceProvider.GetRequiredService<DbContextOptions<WriteDbContext>>()))
            {
                context.Database.Migrate();

                EnableDatabaseCdcIfNotEnabled(context);

                EnableCdcForTablesIfNotEnabled(context);
            }
        }

        private static void EnableDatabaseCdcIfNotEnabled(DbContext context)
        {
            const string checkCdcEnabledQuery = "SELECT is_cdc_enabled FROM sys.databases WHERE name = DB_NAME();";
            bool isCdcEnabled = context.Database.ExecuteSqlRaw(checkCdcEnabledQuery) == 1;

            if (!isCdcEnabled)
            {
                const string enableCdcQuery = "EXEC sys.sp_cdc_enable_db;";
                context.Database.ExecuteSqlRaw(enableCdcQuery);
            }
        }

        private static void EnableCdcForTablesIfNotEnabled(DbContext context)
        {
            var tableNames = context.Model.GetEntityTypes()
                .Select(t => t.GetTableName())
                .Distinct()
                .ToList();

            foreach (var tableName in tableNames)
            {
                var checkTableCdcQuery = $@"
                SELECT COUNT(*)  as cdc_enabled
                FROM cdc.change_tables 
                WHERE source_object_id = OBJECT_ID('{tableName}')
                ";

                int isCdcEnabled = 0;
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = checkTableCdcQuery;
                    context.Database.OpenConnection();
                    isCdcEnabled = (int)(command.ExecuteScalar() ?? 0);
                    context.Database.CloseConnection();
                }

                if (isCdcEnabled == 0)
                {
                    // Habilita o CDC para a tabela
                    var enableTableCdcQuery = $@"
                    EXEC sys.sp_cdc_enable_table 
                        @source_schema = N'dbo', 
                        @source_name = N'{tableName}', 
                        @role_name = NULL;
                    ";
                    context.Database.ExecuteSqlRaw(enableTableCdcQuery);
                }
            }
        }
    }
}
