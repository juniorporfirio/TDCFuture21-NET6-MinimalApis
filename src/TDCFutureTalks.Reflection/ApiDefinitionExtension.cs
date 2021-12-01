using System.Collections.ObjectModel;
using TDCFutureTalks.Strutured.Endpoints;

public static class ApiDefinitionExtension
    {
        public static void AddApiDefinition(this IServiceCollection services)
        {
            var apiDefinitions = new List<IApiDefinition>();

            var apis = System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(IApiDefinition).IsAssignableFrom(type) && !type.IsInterface);

            foreach(var api in apis)
            {
                var instance = (IApiDefinition)Activator.CreateInstance(api);
                ArgumentNullException.ThrowIfNull(instance,nameof(api));
                apiDefinitions.Add(instance);
            }

            foreach(var apiDefinition in apiDefinitions)
            {
                apiDefinition.ServiceEndpoint(services);
            }
            services.AddSingleton(apiDefinitions.AsReadOnly());
        }

        public static void UseApiEndpoint(this WebApplication app)
        {
            var apis = app.Services.GetRequiredService<ReadOnlyCollection<IApiDefinition>>();
            foreach(var api in apis)
            {
                api.RegisterEndpoint(app);
            }
        }
    }
