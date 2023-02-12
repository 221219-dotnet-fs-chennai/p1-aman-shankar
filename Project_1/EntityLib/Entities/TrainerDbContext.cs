using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityLib.Entities;

public partial class TrainerDbContext : DbContext
{
    public TrainerDbContext()
    {
    }

    public TrainerDbContext(DbContextOptions<TrainerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<EducationDetail> EducationDetails { get; set; }

    public virtual DbSet<Skills> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QONHH5T;Database=Project1;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("pk_company");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.CompanyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("company_id");
            entity.Property(e => e.Duration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.Industry)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("industry");

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("fk_company");
        });

        modelBuilder.Entity<EducationDetail>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("pk_education");

            entity.ToTable("Education_Details");

            entity.Property(e => e.EducationName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("education_name");
            entity.Property(e => e.EId).HasColumnName("e_id");
            entity.Property(e => e.Duration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.EducationId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("education_id");
            entity.Property(e => e.Grade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.InstituteName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("institute_name");

            entity.HasOne(d => d.Education).WithMany(p => p.EducationDetails)
                .HasForeignKey(d => d.EducationId)
                .HasConstraintName("fk_education");
        });

        modelBuilder.Entity<Skills>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("pk_skill");

            entity.Property(e => e.SkillName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("skill_name");
            entity.Property(e => e.SId).HasColumnName("s_id");
            entity.Property(e => e.SkillId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("skill_id");

            entity.HasOne(d => d.SkillNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("fk_skill");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_user");

            entity.ToTable("User");

            entity.HasIndex(e => e.Website, "UQ__User__2B1892FFDBB9D6BE").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D105340C66BDC4").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.AboutMe)
                .IsUnicode(false)
                .HasColumnName("about_me");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pincode");
            entity.Property(e => e.Website)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("website");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
