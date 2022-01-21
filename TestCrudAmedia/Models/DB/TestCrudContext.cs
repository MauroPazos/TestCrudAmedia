using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestCrudAmedia.Models.DB
{
    public partial class TestCrudContext : DbContext
    {
        public TestCrudContext()
        {
        }

        public TestCrudContext(DbContextOptions<TestCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<TGenero> TGenero { get; set; }
        public virtual DbSet<TGeneroPelicula> TGeneroPelicula { get; set; }
        public virtual DbSet<TPelicula> TPelicula { get; set; }
        public virtual DbSet<TRol> TRol { get; set; }
        public virtual DbSet<TUsers> TUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=TestCrud; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<TGenero>(entity =>
            {
                entity.HasKey(e => e.CodGenero)
                    .HasName("PK__tGenero__0DACB9D58F16F601");

                entity.ToTable("tGenero");

                entity.Property(e => e.CodGenero).HasColumnName("cod_genero");

                entity.Property(e => e.TxtDesc)
                    .HasColumnName("txt_desc")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TGeneroPelicula>(entity =>
            {
                entity.HasKey(e => new { e.CodPelicula, e.CodGenero })
                    .HasName("PK__tGeneroP__6285A5956E9AE48A");

                entity.ToTable("tGeneroPelicula");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodGenero).HasColumnName("cod_genero");

                entity.HasOne(d => d.CodGeneroNavigation)
                    .WithMany(p => p.TGeneroPelicula)
                    .HasForeignKey(d => d.CodGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pelicula_genero");

                entity.HasOne(d => d.CodPeliculaNavigation)
                    .WithMany(p => p.TGeneroPelicula)
                    .HasForeignKey(d => d.CodPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_genero_pelicula");
            });

            modelBuilder.Entity<TPelicula>(entity =>
            {
                entity.HasKey(e => e.CodPelicula)
                    .HasName("PK__tPelicul__225F6E08B4A5BD47");

                entity.ToTable("tPelicula");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CantDisponiblesAlquiler).HasColumnName("cant_disponibles_alquiler");

                entity.Property(e => e.CantDisponiblesVenta).HasColumnName("cant_disponibles_venta");

                entity.Property(e => e.PrecioAlquiler)
                    .HasColumnName("precio_alquiler")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnName("precio_venta")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TxtDesc)
                    .HasColumnName("txt_desc")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRol>(entity =>
            {
                entity.HasKey(e => e.CodRol)
                    .HasName("PK__tRol__F13B1211CF8058BF");

                entity.ToTable("tRol");

                entity.Property(e => e.CodRol).HasColumnName("cod_rol");

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtDesc)
                    .HasColumnName("txt_desc")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUsers>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__tUsers__EA3C9B1ABBCAE78C");

                entity.ToTable("tUsers");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.CodRol).HasColumnName("cod_rol");

                entity.Property(e => e.NroDoc)
                    .HasColumnName("nro_doc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtApellido)
                    .HasColumnName("txt_apellido")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TxtNombre)
                    .HasColumnName("txt_nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TxtPassword)
                    .HasColumnName("txt_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TxtUser)
                    .HasColumnName("txt_user")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodRolNavigation)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.CodRol)
                    .HasConstraintName("fk_user_rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
