namespace TDCFutureTalks.Strutured.Endpoints;
public static class TalkEndpointExtensions
{

    public static void RegisterTalks(this WebApplication app)
    {
        app.MapGet("/talk", All).Produces<List<Talk>>(200).WithTags("Get");
        app.MapGet("/talk/{id}", Get).Produces<Talk>(200).WithTags("Get");
        app.MapPost("/talk/new", Add).Produces<Talk>(201).ProducesValidationProblem().WithTags("Alter").WithValidator<Talk>();
    }
   internal static IResult All(ITalkRepository talkRepository)
    {
        return Results.Extensions.Ok(talkRepository.GetAll());
    }

    internal static IResult Get(ITalkRepository talkRepository, Guid id)
    {
        var talk = talkRepository.Get(id);

        if (talk is null)
            return Results.Extensions.NotFound();

        return Results.Extensions.Ok(talk);
    }

    internal static IResult Add(ITalkRepository talkRepository, Talk talk)
    {
        talkRepository.Insert(talk);
        return Results.Extensions.Created<Talk>($"/talk/{talk.Id}", talk);
    }
}
