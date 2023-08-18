using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagementAPI.Models.EF;

public partial class AirlinesManagementContext : DbContext
{
    public AirlinesManagementContext()
    {
    }

    public AirlinesManagementContext(DbContextOptions<AirlinesManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FlightInfo> FlightInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=airlinesManagement;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlightInfo>(entity =>
        {
            entity.HasKey(e => e.FlightNo).HasName("PK__FlightIn__8A9E3D459A38DB23");

            entity.ToTable("FlightInfo");

            entity.Property(e => e.FlightNo).ValueGeneratedNever();
            entity.Property(e => e.Fare).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FromCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ToCity)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
