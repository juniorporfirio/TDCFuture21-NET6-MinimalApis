var builder = WebApplication.CreateBuilder(args);

//ConfigureServices
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<TalkContext>(options => options.UseSqlite(connection));

//Scan IApiDefinition
builder.Services.AddApiDefinition();

using var app = builder.Build();

//Configure
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();

    GenerateData(app);
}

//Endpoints
app.UseApiEndpoint();

await app.RunAsync();

//EF Core Database 
static void GenerateData(WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<TalkContext>();
    var trail = "Arquitetura .NET";

    if (context!.Database.EnsureCreated())
    {
        context.Talk.AddRange(
            new(Guid.NewGuid(), "O advento do Metaverso e seu impacto na presta��o de servi�os tecnol�gicos", "Mario Gazziro", trail),
            new(Guid.NewGuid(), ".NET 6: O que h� de novo e o que est� por vir?", "Letticia Nicoli / Mahmoud Ali", trail),
            new(Guid.NewGuid(), "O Futuro em construir API com.NET 6", "J�nior Porfirio", trail),
            new(Guid.NewGuid(), "Diagram as a code: utilizando C# para diagrama��o C4 model", "Yan Justino", trail),
            new(Guid.NewGuid(), "O impacto do modelo de versionamento de eventos ao trabalhar com Event Sourcing", "Douglas Jos� Araujo / Adriano Ribeiro", trail),
            new(Guid.NewGuid(), "Como medir o sucesso da arquitetura do seu software?", "Vanessa Valle / Rafael Almeida Santos / Angelo Luis Rodrigues da Silva", trail),
            new(Guid.NewGuid(), "A arquitetura,desafios e aprendizados do desenvolvimento do PIX da XP", "Felipe Nader / �talo Bruno Duarte Luz", trail),
            new(Guid.NewGuid(), "Criando Pipelines de IaC com C# e Pulumi", "Diego Gabriel Cardoso", trail),
            new(Guid.NewGuid(), "Monitorando aplica��es com Elastic APM no .NET 6.0", "Jorge Nogueira", trail)
            );
        context.SaveChanges();
    }
}
