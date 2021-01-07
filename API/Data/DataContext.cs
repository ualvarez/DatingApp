using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }

        public DbSet<UserLike> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserLike>()
            .HasKey(k => new {k.SourceUserId, k.LinkedUserId});

            builder.Entity<UserLike>()
            .HasOne(s => s.SourceUser)
            .WithMany(l => l.LikedUsers)
            .HasForeignKey(s => s.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade); //In SQL Server you have to use DeleteBehavior.NoAction or you will get an error during migration

             builder.Entity<UserLike>()
            .HasOne(s => s.LinkedUser)
            .WithMany(l => l.LikedByUsers)
            .HasForeignKey(s => s.LinkedUserId)
            .OnDelete(DeleteBehavior.Cascade); //In SQL Server you have to use DeleteBehavior.NoAction or you will get an error during migration

        }


        
    }
}