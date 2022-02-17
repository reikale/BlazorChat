namespace BlazorChat.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<DataContext> Contacts { get; set; }
    }
}
