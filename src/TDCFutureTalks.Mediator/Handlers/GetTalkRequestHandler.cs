public record GetTalkRequest : IRequest<IResult>
{
    public Guid Id { get; init; }
    public GetTalkRequest(Guid Id)
    {
        this.Id = Id;
    }
}
public class GetTalkRequestHandler : IRequestHandler<GetTalkRequest, IResult>
{
    private readonly ITalkRepository talkRepository;

    public GetTalkRequestHandler(ITalkRepository talkRepository)
    {
        this.talkRepository = talkRepository;
    }

    public Task<IResult> Handle(GetTalkRequest request, CancellationToken cancellationToken)
    {
        var talk = talkRepository.Get(request.Id);
        var response = talk is null ? Results.NotFound() : Results.Ok(talk);
        return Task.FromResult(response);
    }
}
