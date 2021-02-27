using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
     IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
     IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<UserLike> Likes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Connection> Connections { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

            builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

            builder.Entity<UserLike>()
            .HasKey(k => new { k.SourceUserId, k.LinkedUserId });

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

           builder.Entity<Message>()
           .HasOne( u => u.Recipient)
           .WithMany(m => m.MessageReceived)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
           .HasOne( u => u.Sender)
           .WithMany(m => m.MessageSent)
           .OnDelete(DeleteBehavior.Restrict);

        }



    }
}