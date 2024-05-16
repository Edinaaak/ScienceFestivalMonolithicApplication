
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScienceFestivalMonolithicApplication.Models;

namespace ScienceFestivalMonolithicApplication.Persistance
{
    public class  DatabaseContext : IdentityDbContext<User, AppRole, int>

    {

        public DatabaseContext(DbContextOptions options) : base(options) { }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Jury)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);
               


            modelBuilder.Entity<Show>()
                .HasOne(s => s.Performer)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Message> Messagees { get; set; } = default!;
        public DbSet<Show> Shows { get; set; } = default!;


    }
}
