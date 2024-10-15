using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendMachineTuring.Models;

public partial class TuringMachineContext : DbContext
{
    public TuringMachineContext()
    {
    }

    public TuringMachineContext(DbContextOptions<TuringMachineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tapealphabet> Tapealphabets { get; set; }

    public virtual DbSet<Turingstate> Turingstates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TuringMachine;Username=VictorAdmin;Password=Alfredo+123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tapealphabet>(entity =>
        {
            entity.HasKey(e => e.Title).HasName("tapealphabet_pkey");

            entity.ToTable("tapealphabet");

            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Turingstate>(entity =>
        {
            entity.HasKey(e => e.Statename).HasName("turingstate_pkey");

            entity.ToTable("turingstate");

            entity.Property(e => e.Statename)
                .HasColumnType("character varying")
                .HasColumnName("statename");
            entity.Property(e => e.Statetype)
                .HasColumnType("character varying")
                .HasColumnName("statetype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
