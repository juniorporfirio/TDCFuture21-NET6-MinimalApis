public interface ITalkRepository
{
    IEnumerable<Talk> GetAll();
    Talk? Get(Guid Id);
    void Insert(Talk talk);
}
public class TalkRepository : ITalkRepository
{
    private readonly TalkContext _dbContext;

    public TalkRepository(TalkContext dbContext) => _dbContext = dbContext;
    public Talk? Get(Guid Id)
    {
        return _dbContext.Talk.Find(Id);
    }

    public IEnumerable<Talk> GetAll() => _dbContext.Talk.ToList();

    public void Insert(Talk talk)
    {
        _dbContext.Talk.Add(talk);
        _dbContext.SaveChanges();
    }
}


