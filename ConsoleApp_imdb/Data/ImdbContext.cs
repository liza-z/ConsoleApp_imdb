using System;
using System.Collections.Generic;
using ConsoleApp_imdb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Data;

public partial class ImdbContext : DbContext
{
    public ImdbContext()
    {
    }

    public ImdbContext(DbContextOptions<ImdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GenreMovie> GenreMovies { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<SignIn> SignIns { get; set; }

    public virtual DbSet<Writer> Writers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0SDS87B;Database=imdb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__actor__3213E83FAFC1653B");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FC8FD4AD2");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__director__3213E83FEE365017");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__genre__3213E83F6A58FDE1");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<GenreMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__genre_mo__3213E83FE393EC59");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Genre).WithMany(p => p.GenreMovies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__genre_mov__genre__47DBAE45");

            entity.HasOne(d => d.Movie).WithMany(p => p.GenreMovies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__genre_mov__movie__46E78A0C");
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__interest__3213E83FEF4220A1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Interests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__interests__genre__4CA06362");

            entity.HasOne(d => d.Genre).WithMany(p => p.Interests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__interests__genre__4D94879B");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__movie__3213E83F019CF2DD");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movie__director___3B75D760");

            entity.HasOne(d => d.Writer).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movie__writer_id__3C69FB99");
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__movie_ac__3213E83F34E22ABA");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Actor).WithMany(p => p.MovieActors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movie_act__actor__4222D4EF");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieActors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movie_act__movie__412EB0B6");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rating__3213E83FF1B1356F");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rating__customer__5535A963");

            entity.HasOne(d => d.Movie).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rating__rating__5441852A");
        });

        modelBuilder.Entity<SignIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sign_in__3213E83F05865F79");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Time).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.SignIns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sign_in__custome__5165187F");
        });

        modelBuilder.Entity<Writer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__writer__3213E83F10BE4044");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
