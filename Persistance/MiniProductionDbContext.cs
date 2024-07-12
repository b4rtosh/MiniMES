using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;

public class MiniProductionDbContext : DbContext
{
    public MiniProductionDbContext(DbContextOptions options) : base(options)
    {
    }

    public MiniProductionDbContext()
    {
    }

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

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "MiniMes");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);
           
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Orders", "MiniMes");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Quantity);

            entity.HasOne(d => d.Machine)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.MachineId);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId);
        });
        modelBuilder.Entity<Process>(entity =>
        {
            entity.ToTable("Processes", "MiniMes");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.HasOne(d => d.Order)
                .WithMany(p => p.Processes)
                .HasForeignKey(d => d.OrderId);
            entity.HasOne(d => d.ProcessStatus)
                .WithMany(p => p.Processes)
                .HasForeignKey(d => d.StatusId);
            entity.Property(e => e.CreatedTime);
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.ToTable("Parameters", "MiniMes");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<ProcessParameter>(entity =>
        {
            entity.ToTable("ProcessParameters", "MiniMes");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.HasOne(d => d.Process)
                .WithMany(p => p.ProcessParameters)
                .HasForeignKey(d => d.ProcessId);
            entity.HasOne(d => d.Parameter)
                .WithMany(p => p.ProcessParameters)
                .HasForeignKey(d => d.ParameterId);
        });

        modelBuilder.Entity<ProcessStatus>(entity =>
        {
            entity.ToTable("ProcessStatuses", "MiniMes");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

    }
}