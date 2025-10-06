using ConexionBD.Models;
using Microsoft.EntityFrameworkCore;

namespace ConexionBD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Guest> Guests => Set<Guest>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(g =>
            {
                g.HasKey(x => x.Id);
                g.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(200);
                g.Property(x => x.Confirmed);
            });

            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                e.Property(x => x.Date)
                    .IsRequired();
                e.Property(x => x.Capacity)
                    .IsRequired().HasAnnotation("Range", new { Min = 1, Max = 100000 });
            });

            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasKey(x => x.Id);

                t.Property(x => x.Notes)
                    .HasConversion(
                        v => v == null ? null : string.Join(";", v),
                        v => v == null ? null : v.Split(';', StringSplitOptions.RemoveEmptyEntries)
                    )
                    .HasColumnType("text");
            });
        }
    }
}