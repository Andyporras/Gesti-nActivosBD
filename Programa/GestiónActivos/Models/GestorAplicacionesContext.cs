using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestiónActivos.Models
{
    public partial class GestorAplicacionesContext : DbContext
    {
        public GestorAplicacionesContext()
        {
        }

        public GestorAplicacionesContext(DbContextOptions<GestorAplicacionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Error> Errors { get; set; } = null!;
        public virtual DbSet<GestionEmpleado> GestionEmpleados { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<ProyectoError> ProyectoErrors { get; set; } = null!;
        public virtual DbSet<Servidor> Servidors { get; set; } = null!;
        public virtual DbSet<Software> Softwares { get; set; } = null!;
        public virtual DbSet<SoftwareServidore> SoftwareServidores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=LAPTOP-HDTJMK9P; database = GestorAplicaciones; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__departam__40F9A207CF75E0D3");

                entity.ToTable("departamento");

                entity.HasIndex(e => e.Codigo, "UQ__departam__40F9A206111CD138")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.CedEmpleados)
                    .HasColumnType("text")
                    .HasColumnName("ced_empleados");

                entity.Property(e => e.JefeCed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jefe_ced");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.SoftwaresId)
                    .HasColumnType("text")
                    .HasColumnName("softwares_id");
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__error__C83612B19B87DC88");

                entity.ToTable("error");

                entity.HasIndex(e => e.Identificador, "UQ__error__C83612B0C6DFC3B5")
                    .IsUnique();

                entity.Property(e => e.Identificador)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("identificador");

                entity.Property(e => e.CodAplicacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cod_aplicacion");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora)
                    .HasColumnType("date")
                    .HasColumnName("hora");

                entity.Property(e => e.Impacto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("impacto");

                entity.Property(e => e.NumSerieServidor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numSerie_servidor");

                entity.Property(e => e.ProyectoId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("proyecto_id");

                entity.HasOne(d => d.CodAplicacionNavigation)
                    .WithMany(p => p.ErrorCodAplicacionNavigations)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.CodAplicacion)
                    .HasConstraintName("fk_error_with_cod_aplicacion");

                entity.HasOne(d => d.NumSerieServidorNavigation)
                    .WithMany(p => p.ErrorNumSerieServidorNavigations)
                    .HasPrincipalKey(p => p.NumSerieServidor)
                    .HasForeignKey(d => d.NumSerieServidor)
                    .HasConstraintName("fk_error_with_numSerie_servidor");

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.Errors)
                    .HasPrincipalKey(p => p.ProyectoId)
                    .HasForeignKey(d => d.ProyectoId)
                    .HasConstraintName("fk_error_with_proyecto_id");
            });

            modelBuilder.Entity<GestionEmpleado>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProyectoId })
                    .HasName("PK__gestionE__38607BFAAF767A59");

                entity.ToTable("gestionEmpleados");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.ProyectoId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("proyecto_id");

                entity.Property(e => e.PersonasId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("personas_id");

                entity.HasOne(d => d.Personas)
                    .WithMany(p => p.GestionEmpleados)
                    .HasForeignKey(d => d.PersonasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gestionEmpleados_with_personas_id");

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.GestionEmpleados)
                    .HasForeignKey(d => d.ProyectoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gestionEmpleados_with_proyecto_id");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__persona__415B7BE421CDE84F");

                entity.ToTable("persona");

                entity.HasIndex(e => e.Cedula, "UQ__persona__415B7BE5EE288903")
                    .IsUnique();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.HasMany(d => d.CodDepartamentos)
                    .WithMany(p => p.CedEmpleadosNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmpleadoDepartamento",
                        l => l.HasOne<Departamento>().WithMany().HasForeignKey("CodDepartamento").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_empleado_departamento_with_cod_departamento"),
                        r => r.HasOne<Persona>().WithMany().HasForeignKey("CedEmpleado").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_empleado_departamento_with_ced_empleado"),
                        j =>
                        {
                            j.HasKey("CedEmpleado", "CodDepartamento").HasName("PK__empleado__F1BA707C0698E307");

                            j.ToTable("empleado_departamento");

                            j.IndexerProperty<string>("CedEmpleado").HasMaxLength(20).IsUnicode(false).HasColumnName("ced_empleado");

                            j.IndexerProperty<string>("CodDepartamento").HasMaxLength(20).IsUnicode(false).HasColumnName("cod_departamento");
                        });
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__proyecto__C83612B150A65360");

                entity.ToTable("proyecto");

                entity.HasIndex(e => e.Identificador, "UQ__proyecto__C83612B041CEC225")
                    .IsUnique();

                entity.Property(e => e.Identificador)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("identificador");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsfuerzoEstimado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("esfuerzoEstimado");

                entity.Property(e => e.EsfuerzoReal)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("esfuerzoReal");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ProyectoError>(entity =>
            {
                entity.HasKey(e => new { e.ProyectoId, e.ErrorId })
                    .HasName("PK__proyecto__7A9E224768F871A9");

                entity.ToTable("proyecto_error");

                entity.HasIndex(e => e.ProyectoId, "UQ__proyecto__A7393C5093B5BF94")
                    .IsUnique();

                entity.HasIndex(e => e.ErrorId, "UQ__proyecto__DA71E16DED792B8D")
                    .IsUnique();

                entity.Property(e => e.ProyectoId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("proyecto_id");

                entity.Property(e => e.ErrorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("error_id");

                entity.HasOne(d => d.Error)
                    .WithOne(p => p.ProyectoError)
                    .HasForeignKey<ProyectoError>(d => d.ErrorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_proyecto_error_with_error_id");

                entity.HasOne(d => d.Proyecto)
                    .WithOne(p => p.ProyectoError)
                    .HasForeignKey<ProyectoError>(d => d.ProyectoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_proyecto_error_with_proyecto_id");
            });

            modelBuilder.Entity<Servidor>(entity =>
            {
                entity.HasKey(e => new { e.NumeroSerie, e.Tipo })
                    .HasName("PK__servidor__EF38BE284CCA0821");

                entity.ToTable("servidor");

                entity.HasIndex(e => e.NumeroSerie, "UQ__servidor__71472B4D3BBD026A")
                    .IsUnique();

                entity.HasIndex(e => e.Tipo, "UQ__servidor__E7F95649A2874435")
                    .IsUnique();

                entity.Property(e => e.NumeroSerie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numeroSerie");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.CapacidadAlmacenamiento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("capacidadAlmacenamiento");

                entity.Property(e => e.CapacidadProcesamiento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("capacidadProcesamiento");

                entity.Property(e => e.CodAplicaciones)
                    .HasColumnType("text")
                    .HasColumnName("cod_aplicaciones");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Memoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("memoria");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.HasKey(e => new { e.Codigo, e.NumeroPatente, e.NumSerieServidor, e.Tipo })
                    .HasName("PK__software__5D80DCE3CBC32F33");

                entity.ToTable("software");

                entity.HasIndex(e => e.NumSerieServidor, "UQ__software__3BA1C28D5D91218E")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ__software__40F9A2065E22BB89")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroPatente, "UQ__software__4DCA0B3F73395705")
                    .IsUnique();

                entity.HasIndex(e => e.Tipo, "UQ__software__E7F956494CF2E622")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.NumeroPatente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_patente");

                entity.Property(e => e.NumSerieServidor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numSerie_servidor");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.CodDepartamento)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cod_departamento");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.FechaProduccion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_produccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasMany(d => d.CodDepartamentos)
                    .WithMany(p => p.CodAplicacions)
                    .UsingEntity<Dictionary<string, object>>(
                        "SoftwareDepartamento",
                        l => l.HasOne<Departamento>().WithMany().HasForeignKey("CodDepartamento").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_software_departamento_with_cod_departamento"),
                        r => r.HasOne<Software>().WithMany().HasPrincipalKey("Codigo").HasForeignKey("CodAplicacion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_software_departamento_with_cod_aplicacion"),
                        j =>
                        {
                            j.HasKey("CodAplicacion", "CodDepartamento").HasName("PK__software__0CB8A432185DFF9D");

                            j.ToTable("software_departamento");

                            j.IndexerProperty<string>("CodAplicacion").HasMaxLength(20).IsUnicode(false).HasColumnName("cod_aplicacion");

                            j.IndexerProperty<string>("CodDepartamento").HasMaxLength(20).IsUnicode(false).HasColumnName("cod_departamento");
                        });
            });

            modelBuilder.Entity<SoftwareServidore>(entity =>
            {
                entity.HasKey(e => new { e.CodAplicacion, e.NumSerieServidor, e.TipoServidor })
                    .HasName("PK__software__7694FBCEB7396AC9");

                entity.ToTable("software_servidores");

                entity.Property(e => e.CodAplicacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cod_aplicacion");

                entity.Property(e => e.NumSerieServidor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numSerie_servidor");

                entity.Property(e => e.TipoServidor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo_servidor");

                entity.HasOne(d => d.CodAplicacionNavigation)
                    .WithMany(p => p.SoftwareServidoreCodAplicacionNavigations)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.CodAplicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_software_servidores_with_cod_aplicacion");

                entity.HasOne(d => d.NumSerieServidorNavigation)
                    .WithMany(p => p.SoftwareServidoreNumSerieServidorNavigations)
                    .HasPrincipalKey(p => p.NumSerieServidor)
                    .HasForeignKey(d => d.NumSerieServidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_software_servidores_with_numSerie_servidor");

                entity.HasOne(d => d.TipoServidorNavigation)
                    .WithMany(p => p.SoftwareServidores)
                    .HasPrincipalKey(p => p.Tipo)
                    .HasForeignKey(d => d.TipoServidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_software_servidores_with_tipo_servidor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
