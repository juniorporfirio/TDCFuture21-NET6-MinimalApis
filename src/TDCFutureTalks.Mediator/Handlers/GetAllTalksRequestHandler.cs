
    public record GetAllTalkRequest: IRequest<IResult>;
    public class GetAllTalksRequestHandler : IRequestHandler<GetAllTalkRequest, IResult>
    {
        private readonly ITalkRepository talkRepository;

        public GetAllTalksRequestHandler(ITalkRepository talkRepository)
        {
            this.talkRepository = talkRepository;
        }
        public Task<IResult> Handle(GetAllTalkRequest request, CancellationToken cancellationToken)
        {
            var talks = talkRepository.GetAll();
            return Task.FromResult(Results.Ok(talks));
        }
    }
