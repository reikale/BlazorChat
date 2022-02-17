using BlazorChat.Shared;

namespace BlazorChat.Server.Data
{
    public class DataContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Contact> Contacts { get; set; }
        
    }
}
