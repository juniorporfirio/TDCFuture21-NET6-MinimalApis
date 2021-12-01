namespace TDCFutureTalks.IntegrationTests;
internal class TDCFutureTalksApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        
        builder.ConfigureServices(services => {
            services.AddScoped(sp =>
            {
                return new DbContextOptionsBuilder<TalkContext>()
                .UseInMemoryDatabase("Test")
                .UseApplicationServiceProvider(sp).Options;
            });
        });
        return base.CreateHost(builder);
    }
}
