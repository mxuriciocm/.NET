using Microsoft.EntityFrameworkCore;
using pc2.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using pc2.Subscriptions.Domain.Model.Aggregates;

namespace pc2.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(f => f.Id);
        builder.Entity<Plan>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(f => f.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Plan>().Property(f => f.IsDefault).IsRequired();
        builder.Entity<Plan>().Property(f => f.MaxUsers).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}