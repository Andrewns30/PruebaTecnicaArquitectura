using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PruebaTecnica.DataAccess
{
    public partial class ProyectoContext : DbContext
    {
        private readonly string _connectionStrings;

        public ProyectoContext(IConfiguration appConfiguration)
        {
            _connectionStrings = appConfiguration.GetConnectionString("Bd")!;
        }

        #region DbSet
        public virtual DbSet<Usuario> Usuarios { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.UseSqlServer(_connectionStrings, p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuId).HasName("PK__Usuario__2F813BE355A3BBE9");

                entity.ToTable("Usuario");

                entity.Property(e => e.UsuId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("usuID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
