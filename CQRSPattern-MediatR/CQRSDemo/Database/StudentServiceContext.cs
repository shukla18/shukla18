﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Database;

public partial class StudentServiceContext : DbContext
{
    public StudentServiceContext(DbContextOptions<StudentServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC27D3F9331C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StudentAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}