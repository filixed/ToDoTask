using ServiceStack;
using ServiceStack.Validation;

[assembly: HostingStartup(typeof(ToDoTask.ConfigureValidation))]

namespace ToDoTask
{
    public class ConfigureValidation : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureAppHost(appHost => {
                // ValidationFeature is pre-registered by default from v5.13 
                // appHost.Plugins.Add(new ValidationFeature());
            });
    }
}