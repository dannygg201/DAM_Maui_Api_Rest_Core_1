using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class DbAba2d0BdveterinariaContext : DbContext
{
    public DbAba2d0BdveterinariaContext()
    {
    }

    public DbAba2d0BdveterinariaContext(DbContextOptions<DbAba2d0BdveterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitaMedicamento> CitaMedicamentos { get; set; }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<EstadoCitum> EstadoCita { get; set; }

    public virtual DbSet<HistorialCitum> HistorialCita { get; set; }

    public virtual DbSet<Mascotum> Mascota { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Pagina> Paginas { get; set; }

    public virtual DbSet<PaginaTipoUsuario> PaginaTipoUsuarios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TipoMascotum> TipoMascota { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioMascotum> UsuarioMascota { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = SQL1003.site4now.net; database = db_aba2d0_bdveterinaria; uid = db_aba2d0_bdveterinaria_admin; pwd = vaquero1521");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<CitaMedicamento>(entity =>
        {
            entity.HasKey(e => e.Iidcitamedicamento);

            entity.ToTable("CitaMedicamento");

            entity.Property(e => e.Iidcitamedicamento).HasColumnName("IIDCITAMEDICAMENTO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Iidcita).HasColumnName("IIDCITA");
            entity.Property(e => e.Iidmedicamento).HasColumnName("IIDMEDICAMENTO");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IidcitaNavigation).WithMany(p => p.CitaMedicamentos)
                .HasForeignKey(d => d.Iidcita)
                .HasConstraintName("FK__CitaMedic__IIDCI__4316F928");

            entity.HasOne(d => d.IidmedicamentoNavigation).WithMany(p => p.CitaMedicamentos)
                .HasForeignKey(d => d.Iidmedicamento)
                .HasConstraintName("FK__CitaMedic__IIDME__48CFD27E");
        });

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.Iidcita);

            entity.Property(e => e.Iidcita).HasColumnName("IIDCITA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Dfechacita)
                .HasColumnType("datetime")
                .HasColumnName("DFECHACITA");
            entity.Property(e => e.Dfechaenfermo)
                .HasColumnType("datetime")
                .HasColumnName("DFECHAENFERMO");
            entity.Property(e => e.Dfechainicio)
                .HasColumnType("datetime")
                .HasColumnName("DFECHAINICIO");
            entity.Property(e => e.Iiddoctorasignacitausuario).HasColumnName("IIDDOCTORASIGNACITAUSUARIO");
            entity.Property(e => e.Iidestadocita).HasColumnName("IIDESTADOCITA");
            entity.Property(e => e.Iidmascota).HasColumnName("IIDMASCOTA");
            entity.Property(e => e.Iidsede).HasColumnName("IIDSEDE");
            entity.Property(e => e.Iidtipomascota).HasColumnName("IIDTIPOMASCOTA");
            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");
            entity.Property(e => e.Precioatencion)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIOATENCION");
            entity.Property(e => e.Totalpagar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTALPAGAR");
            entity.Property(e => e.Vdescripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VDESCRIPCION");
            entity.Property(e => e.Vmedidastomadas)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("VMEDIDASTOMADAS");

            entity.HasOne(d => d.IiddoctorasignacitausuarioNavigation).WithMany(p => p.CitumIiddoctorasignacitausuarioNavigations)
                .HasForeignKey(d => d.Iiddoctorasignacitausuario)
                .HasConstraintName("FK__Cita__IIDDOCTORA__45F365D3");

            entity.HasOne(d => d.IidestadocitaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Iidestadocita)
                .HasConstraintName("FK__Cita__IIDESTADOC__6E01572D");

            entity.HasOne(d => d.IidmascotaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Iidmascota)
                .HasConstraintName("FK__Cita__IIDMASCOTA__3E52440B");

            entity.HasOne(d => d.IidsedeNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Iidsede)
                .HasConstraintName("FK__Cita__IIDSEDE__44FF419A");

            entity.HasOne(d => d.IidtipomascotaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Iidtipomascota)
                .HasConstraintName("FK__Cita__IIDTIPOMAS__3D5E1FD2");

            entity.HasOne(d => d.IidusuarioNavigation).WithMany(p => p.CitumIidusuarioNavigations)
                .HasForeignKey(d => d.Iidusuario)
                .HasConstraintName("FK__Cita__IIDUSUARIO__3C69FB99");
        });

        modelBuilder.Entity<EstadoCitum>(entity =>
        {
            entity.HasKey(e => e.Iidestado);

            entity.Property(e => e.Iidestado).HasColumnName("IIDESTADO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Vdescripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("VDESCRIPCION");
            entity.Property(e => e.Vnombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("VNOMBRE");
        });

        modelBuilder.Entity<HistorialCitum>(entity =>
        {
            entity.HasKey(e => e.Iidhistorialcita);

            entity.Property(e => e.Iidhistorialcita).HasColumnName("IIDHISTORIALCITA");
            entity.Property(e => e.Dfecha)
                .HasColumnType("datetime")
                .HasColumnName("DFECHA");
            entity.Property(e => e.Iidcita).HasColumnName("IIDCITA");
            entity.Property(e => e.Iidestado).HasColumnName("IIDESTADO");
            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");
            entity.Property(e => e.Vobservacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VOBSERVACION");
        });

        modelBuilder.Entity<Mascotum>(entity =>
        {
            entity.HasKey(e => e.Iidmascota);

            entity.Property(e => e.Iidmascota).HasColumnName("IIDMASCOTA");
            entity.Property(e => e.Altura)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ALTURA");
            entity.Property(e => e.Ancho)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ANCHO");
            entity.Property(e => e.Archivo).HasColumnName("ARCHIVO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Fechanacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");
            entity.Property(e => e.Iidtipomascota).HasColumnName("IIDTIPOMASCOTA");
            entity.Property(e => e.Iidusuariopropietario).HasColumnName("IIDUSUARIOPROPIETARIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Vnombrearchivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VNOMBREARCHIVO");
            entity.Property(e => e.Vobservacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("VOBSERVACION");

            entity.HasOne(d => d.IidsexoNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Iidsexo)
                .HasConstraintName("FK_Mascota_Sexo");

            entity.HasOne(d => d.IidtipomascotaNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Iidtipomascota)
                .HasConstraintName("FK__Mascota__IIDTIPO__2B3F6F97");

            entity.HasOne(d => d.IidusuariopropietarioNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Iidusuariopropietario)
                .HasConstraintName("FK__Mascota__IIDUSUA__35BCFE0A");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Iidmedicamento).HasName("PK__Medicame__992AF5C5D177AD9B");

            entity.ToTable("Medicamento");

            entity.Property(e => e.Iidmedicamento).HasColumnName("IIDMEDICAMENTO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Concentracion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONCENTRACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");
        });

        modelBuilder.Entity<Pagina>(entity =>
        {
            entity.HasKey(e => e.Iidpagina).HasName("PK_Paginas");

            entity.ToTable("Pagina");

            entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ACCION");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Controlador)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTROLADOR");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MENSAJE");
        });

        modelBuilder.Entity<PaginaTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Iidpaginatipousuario);

            entity.ToTable("PaginaTipoUsuario");

            entity.Property(e => e.Iidpaginatipousuario).HasColumnName("IIDPAGINATIPOUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");
            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Iidvista).HasColumnName("IIDVISTA");

            entity.HasOne(d => d.IidpaginaNavigation).WithMany(p => p.PaginaTipoUsuarios)
                .HasForeignKey(d => d.Iidpagina)
                .HasConstraintName("FK__PaginaTip__IIDPA__1BFD2C07");

            entity.HasOne(d => d.IidtipousuarioNavigation).WithMany(p => p.PaginaTipoUsuarios)
                .HasForeignKey(d => d.Iidtipousuario)
                .HasConstraintName("FK__PaginaTip__IIDTI__1CF15040");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Iidpersona);

            entity.ToTable("Persona");

            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Apmaterno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("APMATERNO");
            entity.Property(e => e.Appaterno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("APPATERNO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Btieneusuario).HasColumnName("BTIENEUSUARIO");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Fechanacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Varchivo).HasColumnName("VARCHIVO");
            entity.Property(e => e.Vnombrearchivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VNOMBREARCHIVO");

            entity.HasOne(d => d.IidsexoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Iidsexo)
                .HasConstraintName("FK__Persona__IIDSEXO__5AEE82B9");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.Iidsede);

            entity.ToTable("Sede");

            entity.Property(e => e.Iidsede).HasColumnName("IIDSEDE");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Vdireccion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("VDIRECCION");
            entity.Property(e => e.Vnombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VNOMBRE");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Iidsexo);

            entity.ToTable("Sexo");

            entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<TipoMascotum>(entity =>
        {
            entity.HasKey(e => e.Iidtipomascota).HasName("PK_TipoMascotas");

            entity.Property(e => e.Iidtipomascota).HasColumnName("IIDTIPOMASCOTA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Iidtipousuario);

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iidusuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Contra)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRA");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREUSUARIO");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_Usuario_Persona");

            entity.HasOne(d => d.IidtipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Iidtipousuario)
                .HasConstraintName("FK__Usuario__IIDTIPO__1FCDBCEB");
        });

        modelBuilder.Entity<UsuarioMascotum>(entity =>
        {
            entity.HasKey(e => e.Iidpersonamascota).HasName("PK_PERSONAMASCOTA");

            entity.Property(e => e.Iidpersonamascota).HasColumnName("IIDPERSONAMASCOTA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Iidmascota).HasColumnName("IIDMASCOTA");
            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");

            entity.HasOne(d => d.IidmascotaNavigation).WithMany(p => p.UsuarioMascota)
                .HasForeignKey(d => d.Iidmascota)
                .HasConstraintName("FK__PersonaMa__IIDMA__2F10007B");

            entity.HasOne(d => d.IidusuarioNavigation).WithMany(p => p.UsuarioMascota)
                .HasForeignKey(d => d.Iidusuario)
                .HasConstraintName("FK__UsuarioMa__IIDUS__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
