using Funq;
using ServiceStack;
using ServiceStack.FluentValidation;
using System.Data;
using ToDoTask.ServiceInterface;
using ToDoTask.ServiceModel.Repository;
using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Types;
using ToDoTask.ServiceModel.Validators;

[assembly: HostingStartup(typeof(ToDoTask.AppHost))]

namespace ToDoTask;

public class AppHost : AppHostBase, IHostingStartup
{

    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        })
        .Configure(app => {
            // Configure ASP.NET Core App
            if (!HasInit)
                app.UseServiceStack(new AppHost());
        });

    public AppHost() : base("ToDoTask", typeof(ToDoServices).Assembly) {}

    public override void Configure(Container container)
    {
        // Configure ServiceStack only IOC, Config & Plugins
        SetConfig(new HostConfig {
            UseSameSiteCookies = true,
            DebugMode = true,
        });
        container.Register<IValidator<ToDoCreateRequest>>(new ToDoValidator());
        container.Register<IValidator<ToDoGetOneRequest>>(new ToDoGetOneValidator());
        container.Register<IValidator<ToDoUpdateRequest>>(new ToDoUpdateValidator());
        container.Register<IValidator<ToDoUpdatePercentRequest>>(new ToDoUpdatePercentValidator());
        container.RegisterAs<ToDoRepository, IToDoRepository>();
        container.Register<IToDoRepository>(c =>
        {
            var repository = new ToDoRepository();
            c.AutoWire(repository);
            return repository;
        });
    }
}
