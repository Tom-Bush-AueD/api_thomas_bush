﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_thomas_bush.Models;

public partial class RoiDatabaseContext : DbContext
{
    public RoiDatabaseContext()
    {
    }

    public RoiDatabaseContext(DbContextOptions<RoiDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0713B34F4E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC072B0C580D");

            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("ZIP");

            entity.HasOne(d => d.Department).WithMany(p => p.People)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__People__Departme__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
