using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace book_store_console_app.Models;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBook> TblBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=SIDDHANT\\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBook>(entity =>
        {
            entity.HasKey(e => e.VcIsbn).HasName("PK__tbl_book__49230192AC5A9FBA");

            entity.ToTable("tbl_book");

            entity.Property(e => e.VcIsbn)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("vc_isbn");
            entity.Property(e => e.DecPrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("dec_price");
            entity.Property(e => e.IntYear).HasColumnName("int_year");
            entity.Property(e => e.VcAuthor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_author");
            entity.Property(e => e.VcEdition)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("vc_edition");
            entity.Property(e => e.VcPublisher)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_publisher");
            entity.Property(e => e.VcTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
