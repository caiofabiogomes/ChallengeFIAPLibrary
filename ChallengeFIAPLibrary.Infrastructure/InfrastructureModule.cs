using ChallengeFIAPLibrary.Domain.Repositories;
using ChallengeFIAPLibrary.Infrastructure.Persistence;
using ChallengeFIAPLibrary.Infrastructure.Persistence.DataSync;
using ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ChallengeFIAPLibrary.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddRepositories();

            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        { 
            var connectionStringWrite = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(connectionStringWrite));

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            services.AddSingleton<ReadDbContext>(sp =>
            {
                var mongoDbConnection = configuration.GetConnectionString("MongoDbConnection");
                var databaseName = configuration["DatabaseName"];
                return new ReadDbContext(mongoDbConnection, databaseName);
            });
             

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            return services;
        }  
    }
}
