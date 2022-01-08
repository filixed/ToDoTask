using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ToDoTask.ServiceModel.Types;

[assembly: HostingStartup(typeof(ToDoTask.ConfigureDb))]

namespace ToDoTask
{


    public class ConfigureDb : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices((context, services) => {
                services.AddSingleton<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(
                    context.Configuration.GetConnectionString("DefaultConnection")
                    ?? "Server=localhost;User Id=postgres;Password=123qwe;Database=ToDo;Pooling=true;MinPoolSize=0;MaxPoolSize=200",
                    PostgreSqlDialect.Provider));
            })
            .ConfigureAppHost(afterConfigure:appHost => {
                appHost.ScriptContext.ScriptMethods.Add(new DbScriptsAsync());

                // Create non-existing Table and add Seed Data Example
                using var db = appHost.Resolve<IDbConnectionFactory>().Open();
                if (db.CreateTableIfNotExists<ToDo>())
                {
                  //  db.Insert(new ToDo {Id = 1, Title = "Title", Description = "Description" });
                }
            });
    }
}
