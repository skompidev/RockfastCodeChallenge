namespace Rockfast.ApiDatabase
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; } = default!;

        public ApiDbContext(DbContextOptions options)
            :base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
