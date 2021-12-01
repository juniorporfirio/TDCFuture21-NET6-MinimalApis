namespace TDCFutureTalks.Strutured.Endpoints
{
    public interface IApiDefinition
    {
        void RegisterEndpoint(WebApplication app);
        void ServiceEndpoint(IServiceCollection services);

    }
    public class TalkApi : IApiDefinition
    {
        private readonly ITalkRepository _talkRepository;

        public TalkApi(ITalkRepository talkRepository)
        {
            _talkRepository = talkRepository;
        }
        public void RegisterEndpoint(WebApplication app)
        {
            app.MapGet("/talk", All).Produces<List<Talk>>(200).WithTags("Get");
            app.MapGet("/talk/{id}", Get).Produces<Talk>(200).WithTags("Get");
            app.MapPost("/talk/new", Add).Produces<Talk>(201).ProducesValidationProblem().WithTags("Alter").WithValidator<Talk>();
        }

         IResult All()
        {
            return Results.Extensions.Ok(_talkRepository.GetAll());
        }

         IResult Get(Guid id)
        {
            var talk = _talkRepository.Get(id);

            if (talk is null)
                return Results.Extensions.NotFound();

            return Results.Extensions.Ok(talk);
        }

         IResult Add(Talk talk)
        {
            _talkRepository.Insert(talk);
            return Results.Extensions.Created<Talk>($"/talk/{talk.Id}", talk);
        }

        public void ServiceEndpoint(IServiceCollection services)
        {
            services.AddScoped<ITalkRepository, TalkRepository>();

        }
    }
}
