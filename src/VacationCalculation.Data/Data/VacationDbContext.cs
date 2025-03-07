﻿using Microsoft.EntityFrameworkCore;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Data.Data;

public partial class VacationDbContext : DbContext
{
    public VacationDbContext()
    {
    }

    public VacationDbContext(DbContextOptions<VacationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<HolidayDate> HolidayDates { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VacationRequest> VacationRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departam__3213E83F54D52E5D");

            entity.ToTable("departament");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__empleado__3213E83F77F04533");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Birthday)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("birthday");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DateEntry)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_entry");
            entity.Property(e => e.DepartamentId).HasColumnName("departament_id");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeTypeId).HasColumnName("employee_type_id");
            entity.Property(e => e.MaternalSurname)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("maternal_surname");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PaternalSurname)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("paternal_surname");

            entity.HasOne(d => d.Departament).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee__id_de__5535A963");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee__id_ti__5629CD9C");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipos_em__3213E83FDABCD24D");

            entity.ToTable("employee_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DaysPerYear).HasColumnName("days_per_year");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<HolidayDate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__fechas_v__3213E83FAF2C8F42");

            entity.ToTable("holiday_date");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationDate).HasColumnName("application_date");
            entity.Property(e => e.Type)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValue("Completo")
                .HasColumnName("type");
            entity.Property(e => e.VacationRequestId).HasColumnName("vacation_request_id");

            entity.HasOne(d => d.VacationRequest).WithMany(p => p.HolidayDates)
                .HasForeignKey(d => d.VacationRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fechas_va__id_so__5EBF139D");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83FD40AD94A");

            entity.ToTable("permission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F33F2B71A");

            entity.ToTable("role");

            entity.HasIndex(e => e.Name, "UQ__role__72AFBCC69BB5C7BA").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role_per__3213E83FA2A7C558");

            entity.ToTable("role_permission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissionPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_permission_permission_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissionRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_permission_role_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F36757CD1");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_user_employee_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__role_id__693CA210");
        });

        modelBuilder.Entity<VacationRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__solicitu__3213E83F67B111C0");

            entity.ToTable("vacation_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationDate).HasColumnName("application_date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.RequestedDays).HasColumnName("requested_days");
            entity.Property(e => e.Status)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("status");

            entity.HasOne(d => d.Employee).WithMany(p => p.VacationRequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__solicitud__id_em__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
