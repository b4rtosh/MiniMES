using Microsoft.EntityFrameworkCore;

public class MiniProductionDbContext : DbContext
{
    public MiniProductionDbContext(DbContextOptions options) : base(options) { }
    public virtual DbSet<Machine> Machines { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Process> Processes { get; set; }
    public virtual DbSet<ProcessParameter> ProcessParamters { get; set; }
    public virtual DbSet<Parameter> Parameters { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Machine>(entity =>
        {
            entity.ToTable("Machines", "MiniMes");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
        });
    }
}