
public class TalkContext : DbContext
{
    public TalkContext(DbContextOptions<TalkContext> options) : base(options) { }
    public DbSet<Talk> Talk => Set<Talk>();
}
