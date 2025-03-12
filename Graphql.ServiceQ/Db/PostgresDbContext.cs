using Graphql.ServiceQ.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graphql.ServiceQ.Db;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options) 
    {
    }
    
    private PostgresDbContext(){}

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}