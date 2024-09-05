using FlowFinance.Models;
using Microsoft.EntityFrameworkCore;
namespace FlowFinance.Data;

public class AppDbContext : DbContext
{
    public DbSet<Renda> Rendas { get; set; }
    public DbSet<Despesa> Despesas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Database/app.db");
    }
}