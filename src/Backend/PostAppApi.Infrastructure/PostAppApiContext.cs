using Microsoft.EntityFrameworkCore;
using PostAppApi.Domain.Enums;
using PostAppApi.Domain.Models;

namespace PostAppApi.Infrastructure
{
    public class PostAppApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public PostAppApiContext() { }
        public PostAppApiContext(DbContextOptions<PostAppApiContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=Db_PostApp;Uid=root;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
    
            modelBuilder.Entity<Post>()
                .HasMany(e => e.Ratings)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .HasOne(e => e.Group)
                .WithMany(e => e.Posts)
                .HasForeignKey(e => e.GroupId);

            modelBuilder.Entity<Rating>()
                .HasKey(e => new { e.Id, e.UserId, e.PostId });

            modelBuilder.Entity<UserGroup>()
            .HasKey(ug => new { ug.UserId, ug.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

        }
    }
}
