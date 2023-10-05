using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

public partial class UsertaskContext : DbContext
{
    public UsertaskContext()
    {
    }

    public UsertaskContext(DbContextOptions<UsertaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PriorityLevel> PriorityLevels { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=removedForSecurityPurposes;Database=removedForSecurityPurposes;persist security info=True;TrustServerCertificate=True;user id=UserTaskUser;password=removedForSecurityPurposes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriorityLevel>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__priority__E579775F7F60ED59");

            entity.ToTable("Priority_level");

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("t_status");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__task__E579775F0AD2A005");

            entity.ToTable("Task");

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("t_description");
            entity.Property(e => e.TDueDate)
                .HasColumnType("date")
                .HasColumnName("t_due_date");
            entity.Property(e => e.TPriorityLevel).HasColumnName("t_priority_level");
            entity.Property(e => e.TStatus).HasColumnName("t_status");
            entity.Property(e => e.TTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("t_title");
            entity.Property(e => e.TUserId).HasColumnName("t_user_id");

            entity.HasOne(d => d.TPriorityLevelNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TPriorityLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__task__t_priority__0DAF0CB0");

            entity.HasOne(d => d.TStatusNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__task__t_status__0EA330E9");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__task_sta__E579775F03317E3D");

            entity.ToTable("Task_status");

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("t_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__users__E579775F07020F21");

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("t_password");
            entity.Property(e => e.TUsername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("t_username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
