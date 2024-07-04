using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student_Grades_Management.Models;

public partial class G6FinalAssignmentContext : DbContext
{
    public G6FinalAssignmentContext()
    {
    }

    public G6FinalAssignmentContext(DbContextOptions<G6FinalAssignmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAssignment> TeacherAssignments { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local); database = G6_FinalAssignment;uid=sa;pwd=123456;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__FDF47986A4C9DF32");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .HasColumnName("class_name");

            entity.HasMany(d => d.Subjects).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ClassSubj__subje__4AB81AF0"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ClassSubj__class__49C3F6B7"),
                    j =>
                    {
                        j.HasKey("ClassId", "SubjectId").HasName("PK__ClassSub__E8F436E035062397");
                        j.ToTable("ClassSubjects");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("subject_id");
                    });
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__3A8F732CFF962379");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("grade_id");
            entity.Property(e => e.Grade1).HasColumnName("grade");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Grades__student___52593CB8");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Grades__teacher___5441852A");

            entity.HasOne(d => d.Test).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK__Grades__test_id__534D60F1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069AD6F12063");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .HasColumnName("student_name");

            entity.HasMany(d => d.Classes).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "Enrollment",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Enrollmen__class__4316F928"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Enrollmen__stude__4222D4EF"),
                    j =>
                    {
                        j.HasKey("StudentId", "ClassId").HasName("PK__Enrollme__55EC41022239F15F");
                        j.ToTable("Enrollment");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                    });

            entity.HasMany(d => d.Subjects).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSu__subje__46E78A0C"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSu__stude__45F365D3"),
                    j =>
                    {
                        j.HasKey("StudentId", "SubjectId").HasName("PK__StudentS__3F3349FC40249DC8");
                        j.ToTable("StudentSubjects");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("subject_id");
                    });
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__5004F6608F5D92DC");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .HasColumnName("subject_name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__03AE777E2C8FC8F6");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("teacher_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(50)
                .HasColumnName("teacher_name");
        });

        modelBuilder.Entity<TeacherAssignment>(entity =>
        {
            entity.HasKey(e => new { e.TeacherId, e.ClassId, e.SubjectId }).HasName("PK__TeacherA__1D213410AEC88DAF");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Class).WithMany(p => p.TeacherAssignments)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherAs__class__4E88ABD4");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherAssignments)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherAs__subje__4F7CD00D");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAssignments)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherAs__teach__4D94879B");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__Tests__F3FF1C02C1C3F6BC");

            entity.Property(e => e.TestId)
                .ValueGeneratedNever()
                .HasColumnName("test_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TestName)
                .HasMaxLength(50)
                .HasColumnName("test_name");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Subject).WithMany(p => p.Tests)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Tests__subject_i__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
