using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TheBookHaven.Model;

namespace TheBookHaven.Data;

public partial class TheBookHavenContext : DbContext
{
    public TheBookHavenContext()
    {
    }

    public TheBookHavenContext(DbContextOptions<TheBookHavenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStore> BookStores { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<RevenueTrend> RevenueTrends { get; set; }

    public virtual DbSet<StockBalance> StockBalances { get; set; }

    public virtual DbSet<TitlesPerAuthor> TitlesPerAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Initial Catalog=TheBookHaven;Integrated Security=True;Trust Server Certificate=True; Server SPN=localhost");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC270C2C85F9");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address1).HasColumnName("Address");
            entity.Property(e => e.BookStoreId).HasColumnName("BookStoreID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.HasOne(d => d.BookStore).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.BookStoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Addresses__BookS__44FF419A");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Author__3214EC2742CE62F3");

            entity.ToTable("Author");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Firstname).HasMaxLength(20);
            entity.Property(e => e.Lastname).HasMaxLength(20);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Books__447D36EB3A4D1571");

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.PriceInKr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Price in kr");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Books__GenreID__3A81B327");

            entity.HasMany(d => d.Authors).WithMany(p => p.Isbns)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookAutho__Autho__403A8C7D"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookAuthor__ISBN__3F466844"),
                    j =>
                    {
                        j.HasKey("Isbn", "AuthorId").HasName("PK__BookAuth__1370992ACFB67A5D");
                        j.ToTable("BookAuthors");
                        j.IndexerProperty<string>("Isbn")
                            .HasMaxLength(13)
                            .HasColumnName("ISBN");
                        j.IndexerProperty<int>("AuthorId").HasColumnName("AuthorID");
                    });
        });

        modelBuilder.Entity<BookStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookStor__3214EC27484F1689");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC27CEC04B39");

            entity.ToTable("Genre");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC27FB3E3919");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purchases__ISBN__4F7CD00D");

            entity.HasOne(d => d.PurchaseNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("FK__Purchases__Purch__4E88ABD4");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC27E52F58DF");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.BookStoreId).HasColumnName("BookStoreID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<RevenueTrend>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RevenueTrends");

            entity.Property(e => e.Month).HasMaxLength(30);
            entity.Property(e => e.TotalSalesAmount).HasMaxLength(4000);
        });

        modelBuilder.Entity<StockBalance>(entity =>
        {
            entity.HasKey(e => new { e.BookStoreId, e.Isbn }).HasName("PK__StockBal__C7B77D6EA124D084");

            entity.ToTable("StockBalance");

            entity.Property(e => e.BookStoreId).HasColumnName("BookStoreID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.BookStore).WithMany(p => p.StockBalances)
                .HasForeignKey(d => d.BookStoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockBala__BookS__47DBAE45");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.StockBalances)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockBalan__ISBN__48CFD27E");
        });

        modelBuilder.Entity<TitlesPerAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TitlesPerAuthor");

            entity.Property(e => e.Name).HasMaxLength(41);
            entity.Property(e => e.StockValue).HasMaxLength(4000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
