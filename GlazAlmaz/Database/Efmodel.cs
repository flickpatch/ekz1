using System;
using System.Collections.Generic;
using GlazAlmaz.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace GlazAlmaz.DataBase;

public partial class Efmodel : DbContext
{
    private static Efmodel Instance { get; set; }
    public static Efmodel Init()
    {
        if(Instance == null)
        {
            Instance = new Efmodel();
        }
        return Instance;
    }
    public Efmodel()
    {
        
        
    }

    public Efmodel(DbContextOptions<Efmodel> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Cliet> Cliets { get; set; }

    public virtual DbSet<Postavshiki> Postavshikis { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=agafonov;password=G3ua3u;database=agafonov_GlazAlmaz;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Cliet>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Fio)
                .HasMaxLength(128)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(64);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<Postavshiki>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Postavshiki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(64);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Tovar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kategory).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Opisanie).HasMaxLength(256);
            entity.Property(e => e.Photo).HasColumnType("blob");
            entity.Property(e => e.PostavshikNumber).HasColumnName("postavshikNumber");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");

            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Pass).HasMaxLength(45);
            entity.Property(e => e.Role).HasMaxLength(45);
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Zakaz");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(45)
                .HasColumnName("ClientID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Discription).HasMaxLength(128);
            entity.Property(e => e.Number).HasMaxLength(45);
            entity.Property(e => e.TovarId)
                .HasMaxLength(45)
                .HasColumnName("TovarID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
