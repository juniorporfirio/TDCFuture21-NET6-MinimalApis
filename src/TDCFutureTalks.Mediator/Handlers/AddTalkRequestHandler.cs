public record AddTalkRequest : IRequest<IResult>
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Speaker { get; init; }
    public string Trail { get; init; }
    public AddTalkRequest(Guid id, string title, string speaker, string trail)
    {
        Id = id;
        Title = title;
        Speaker = speaker;
        Trail = trail;
    }
}
public class GetTalksRequestHandler : IRequestHandler<AddTalkRequest, IResult>
{
    private readonly ITalkRepository talkRepository;

    public GetTalksRequestHandler(ITalkRepository talkRepository)
    {
        this.talkRepository = talkRepository;
    }

    public Task<IResult> Handle(AddTalkRequest request, CancellationToken cancellationToken)
    {
        var talk = new Talk(request.Id, request.Title, request.Speaker, request.Trail);
        talkRepository.Insert(talk);

        return Task.FromResult(Results.Created($"talk/{talk.Id}", talk));
    }
}
