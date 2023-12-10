using Microsoft.EntityFrameworkCore;
using PostAppApi.Domain.Models;

namespace PostAppApi.Infrastructure
{
    public class PostAppApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public PostAppApiContext(DbContextOptions<PostAppApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
    }
}
