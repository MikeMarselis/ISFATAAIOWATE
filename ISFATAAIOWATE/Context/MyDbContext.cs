using System;
using System.Collections.Generic;
using ISFATAAIOWATE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISFATAAIOWATE.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clothing> Clothings { get; set; }

    public virtual DbSet<ClothingHistory> ClothingHistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeClothing> EmployeeClothings { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;userid=postgres;password=123;database=specodezhda;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clothing>(entity =>
        {
            entity.HasKey(e => e.ClothingId).HasName("clothing_pkey");

            entity.ToTable("Clothing");

            entity.Property(e => e.ClothingId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(2L, null, null, null, null, null);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.Sizes).HasMaxLength(50);
        });

        modelBuilder.Entity<ClothingHistory>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("ClothingHistory");

            entity.Property(e => e.OrderId).UseIdentityAlwaysColumn();
            entity.Property(e => e.ClothingName).HasColumnType("character varying");
            entity.Property(e => e.Lfsemployee)
                .HasColumnType("character varying")
                .HasColumnName("LFSEmployee");
            entity.Property(e => e.OrderDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employees_pkey");

            entity.Property(e => e.EmployeeId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(2L, null, null, null, null, null);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Lfs)
                .HasMaxLength(60)
                .HasColumnName("lfs");
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.SecondName).HasMaxLength(50);

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_position_position_id_fk");
        });

        modelBuilder.Entity<EmployeeClothing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EmployeeClothing_pk");

            entity.ToTable("EmployeeClothing");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClothingId).HasColumnName("Clothing_id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

            entity.HasOne(d => d.Clothing).WithMany(p => p.EmployeeClothings)
                .HasForeignKey(d => d.ClothingId)
                .HasConstraintName("EmployeeClothing_Clothing_clothing_id_fk");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeClothings)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("EmployeeClothing_Employees_employee_id_fk");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("Position_pk");

            entity.ToTable("Position");

            entity.Property(e => e.PositionId).UseIdentityAlwaysColumn();
            entity.Property(e => e.PositionName).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
