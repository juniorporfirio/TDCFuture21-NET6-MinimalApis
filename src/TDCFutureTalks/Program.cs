
using FluentValidation;
var builder = WebApplication.CreateBuilder(args);

//ConfigureServices
var connection = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<TalkContext>(options => options.UseSqlite(connection));

using var app = builder.Build();

//Configure
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    GenerateData(app);
}

//Endpoints
app.MapGet("/talk", (TalkContext context)=>
{
    return Results.Ok(context.Talk.ToList());
})
.Produces<List<Talk>>(200)
.WithTags("Get");

app.MapGet("/talk/{id}", async (TalkContext context, Guid id) =>
{
    var talk = await context.Talk.FindAsync(id);

    if (talk is null)
        return Results.NotFound();

    return Results.Ok(talk);
});


app.MapPost("/talk/new", (TalkContext context, Talk talk) =>
{
    context.Talk.Add(talk);
    context.SaveChanges();
    return Results.Created($"talk/{talk.Id}", talk);
});


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
            new(Guid.NewGuid(), "O advento do Metaverso e seu impacto na prestação de serviços tecnológicos", "Mario Gazziro", trail),
            new(Guid.NewGuid(),".NET 6: O que há de novo e o que está por vir?", "Letticia Nicoli / Mahmoud Ali", trail),
            new(Guid.NewGuid(),"O Futuro em construir API com.NET 6","Júnior Porfirio", trail),
            new(Guid.NewGuid(), "Diagram as a code: utilizando C# para diagramação C4 model","Yan Justino", trail),
            new(Guid.NewGuid(),"O impacto do modelo de versionamento de eventos ao trabalhar com Event Sourcing", "Douglas José Araujo / Adriano Ribeiro", trail),
            new(Guid.NewGuid(), "Como medir o sucesso da arquitetura do seu software?", "Vanessa Valle / Rafael Almeida Santos / Angelo Luis Rodrigues da Silva", trail),
            new(Guid.NewGuid(), "A arquitetura,desafios e aprendizados do desenvolvimento do PIX da XP", "Felipe Nader / Ítalo Bruno Duarte Luz", trail),
            new(Guid.NewGuid(), "Criando Pipelines de IaC com C# e Pulumi","Diego Gabriel Cardoso", trail),
            new(Guid.NewGuid(), "Monitorando aplicações com Elastic APM no .NET 6.0", "Jorge Nogueira", trail)
            );
        context.SaveChanges();
    }
}

//Domain
record Talk(Guid Id, 
[property: Required( ErrorMessage ="Please, input the title")]string Title,  
[property: Required(ErrorMessage ="Please, input the name of speaker")]string Speaker, 
string Trail);


//DbContext
internal class TalkContext : DbContext
{
    public TalkContext(DbContextOptions<TalkContext> options) : base(options){ }
    public DbSet<Talk> Talk => Set<Talk>();
}