using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SPMS.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<GetAllPendingPayment> GetAllPendingPayments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-QEFRI3T\\MSSQLSERVER_2022;Database=SPMS;User ID=sa; Password=r00tp@ss;Integrated Security=True;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.AcademicYearId).HasName("PK__Academic__C54C7A21E45852A7");

            entity.HasIndex(e => e.Year, "UQ__Academic__D4BD6054B684D0D1").IsUnique();

            entity.Property(e => e.AcademicYearId).HasColumnName("AcademicYearID");
            entity.Property(e => e.Year).HasMaxLength(9);
        });

        modelBuilder.Entity<GetAllPendingPayment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetAllPendingPayment");

            entity.Property(e => e.AcademicYear).HasMaxLength(9);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GradeName).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.OutstandingAmount).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A37A3C0AFDC");

            entity.HasIndex(e => e.GradeName, "UQ__Grades__4AA309AAF7037BA8").IsUnique();

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.GradeName).HasMaxLength(10);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A580914AD47");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.AcademicYearId).HasColumnName("AcademicYearID");
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Academ__4316F928");

            entity.HasOne(d => d.Student).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Studen__4222D4EF");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__52C42F2FE20B6A3A");

            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.AcademicYearId).HasColumnName("AcademicYearID");
            entity.Property(e => e.FromGradeId).HasColumnName("FromGradeID");
            entity.Property(e => e.PromotionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ToGradeId).HasColumnName("ToGradeID");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Promotion__Acade__4AB81AF0");

            entity.HasOne(d => d.FromGrade).WithMany(p => p.PromotionFromGrades)
                .HasForeignKey(d => d.FromGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Promotion__FromG__48CFD27E");

            entity.HasOne(d => d.Student).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Promotion__Stude__47DBAE45");

            entity.HasOne(d => d.ToGrade).WithMany(p => p.PromotionToGrades)
                .HasForeignKey(d => d.ToGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Promotion__ToGra__49C3F6B7");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79C4EE5046");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.CurrentYearId).HasColumnName("CurrentYearID");
            entity.Property(e => e.EnrollmentDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.CurrentYear).WithMany(p => p.Students)
                .HasForeignKey(d => d.CurrentYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Curren__3E52440B");

            entity.HasOne(d => d.Grade).WithMany(p => p.Students)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__GradeI__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
