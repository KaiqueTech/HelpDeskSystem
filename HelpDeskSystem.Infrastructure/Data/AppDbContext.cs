using HelpDeskSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<CalledModel> Calleds { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<MessageModel> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<CalledModel>(entity =>
            {
                entity.ToTable("tb_Calleds");

                entity.HasKey(c => c.IdCalled);

                entity
                    .HasOne(c => c.Client)
                    .WithMany(cl => cl.Calleds)
                    .HasForeignKey(c => c.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .Property(c => c.Technical)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.ToTable("tb_Clients");
                entity.HasKey(cl => cl.IdClient);
                entity.Property(cl => cl.Name).IsRequired().HasMaxLength(100);


            });

            modelBuilder.Entity<MessageModel>(entity =>
            {
                entity.ToTable("tb_Messages");

                entity.HasKey(m => m.IdMessage);

                entity
                    .HasOne(m => m.Called)
                    .WithMany(c => c.Messages)
                    .HasForeignKey(m => m.CalledId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .Property(m => m.Content)
                    .HasMaxLength(500);

                entity
                    .Property(m => m.Origin)
                    .IsRequired();
                
            });
            
            base.OnModelCreating(modelBuilder);
    }
}
