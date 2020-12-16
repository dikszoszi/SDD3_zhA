using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Validator.Tables
{
    public partial class PersonDbContext : DbContext
    {
        public PersonDbContext()
        {
        }

        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonTable> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                    .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|Resources\\PersonDb.mdf; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PersonTable>(entity =>
            {
                entity.ToTable("people");

                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("personId");

                entity.Property(e => e.PersonFloor).HasColumnName("personFloor");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("personName");

                entity.Property(e => e.PersonPhone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("personPhone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
