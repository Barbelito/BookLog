using Infrastructure.Persistence.EFC.Contexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistrationExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            ArgumentNullException.ThrowIfNull(env);

            if (env.IsDevelopment())
            {
                services.AddSingleton(_ =>
                {
                    var connectionString = "Data Source=file:memdb1?mode=memory&cache=shared";
                    var conn = new SqliteConnection(connectionString);
                    conn.Open();

                    Console.WriteLine($"Using In-Memory Database with connection string: {connectionString}");

                    return conn;
                });

                services.AddDbContext<DataContext>((sp, options) =>
                {
                    var conn = sp.GetRequiredService<SqliteConnection>();
                    options.UseSqlite(conn);

                });
            }
            else
            {
                var connectionString = configuration.GetConnectionString("ProductionDatabase")
                    ?? throw new InvalidOperationException("Missing ConnectionString to Production Database");

                services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            }

            return services;
        }
    }
}
