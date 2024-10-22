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

    public virtual DbSet<TuringMachine> TuringMachines { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TuringMachine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("turing_machines_pkey");

            entity.ToTable("turing_machines");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlfabetoCinta)
                .HasMaxLength(255)
                .HasColumnName("alfabeto_cinta");
            entity.Property(e => e.AlfabetoEntrada)
                .HasMaxLength(255)
                .HasColumnName("alfabeto_entrada");
            entity.Property(e => e.Estados)
                .HasMaxLength(255)
                .HasColumnName("estados");
            entity.Property(e => e.EstadosFinales)
                .HasMaxLength(255)
                .HasColumnName("estados_finales");
            entity.Property(e => e.Transiciones)
                .HasMaxLength(255)
                .HasColumnName("transiciones");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
