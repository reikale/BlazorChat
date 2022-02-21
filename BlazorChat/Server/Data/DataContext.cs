using BlazorChat.Shared.Models;

namespace BlazorChat.Server.Data
{
    public class DataContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatHistory> ChatHistory { get; set; }

    }
}
