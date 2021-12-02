public static class ApiDefinitionExtension
    {
        public static void AddApiDefinition(this IServiceCollection services)
        {
            var apiDefinitions = new List<IApiDefinition>();

        var apis = typeof(IApiDefinition).Assembly
            .ExportedTypes
            .Where(type => typeof(IApiDefinition).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IApiDefinition>();

            apiDefinitions.AddRange(apis);

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
