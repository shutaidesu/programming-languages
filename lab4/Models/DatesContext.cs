using lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace lab4.Models;

public class DatesContext : DbContext
{
    public DatesContext(DbContextOptions<DatesContext> options)
        : base(options)
    {
        Database.EnsureCreated();   
    }

    public DbSet<HistoryEntity> HistoryEntities { get; set; } = null!;
}