using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioMedico.Models;

public partial class ProExpFinalContext : DbContext
{
    public ProExpFinalContext()
    {
    }

    public ProExpFinalContext(DbContextOptions<ProExpFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Secretarium> Secretaria { get; set; }

    public virtual DbSet<ServicioMedico> ServicioMedicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=ProExpFinal; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Cita__6AEC3C0916276BE4");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ci_pac");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ci_ser");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__6F53588B65075188");

            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdPac).HasColumnName("id_pac");
            entity.Property(e => e.IdRecetas).HasColumnName("id_Recetas");
            entity.Property(e => e.NombreDoctor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_doctor");
            entity.Property(e => e.Tratamiento)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("tratamiento");

            entity.HasOne(d => d.IdPacNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPac)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_con_pac");

            entity.HasOne(d => d.IdRecetasNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdRecetas)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_con_recetas");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__C1D13763AEE54ACE");

            entity.ToTable("Especialidad");

            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.CodEspecialidad)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_especialidad");
            entity.Property(e => e.Especialidad1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.IdExpediente).HasName("PK__Expedien__E75F5BDEDA061373");

            entity.ToTable("Expediente");

            entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");
            entity.Property(e => e.CodExpediente)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_expediente");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("responsable");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__E038EB4387A96CB5");

            entity.ToTable("Medico");

            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.ApeMedico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ape_medico");
            entity.Property(e => e.CodMedico)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_medico");
            entity.Property(e => e.DirMedico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dir_medico");
            entity.Property(e => e.DuiMedico)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dui_medico");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NomMedico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_medico");
            entity.Property(e => e.TelMedico)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("tel_medico");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("fk_med_esp");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_med_user");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__2C2C72BB453322CF");

            entity.ToTable("Paciente");

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.ApePaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ape_paciente");
            entity.Property(e => e.CodPaciente)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_paciente");
            entity.Property(e => e.DirPaciente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dir_paciente");
            entity.Property(e => e.DirRespon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dir_respon");
            entity.Property(e => e.Dui)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.DuiRespon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dui_respon");
            entity.Property(e => e.EdadAnio).HasColumnName("edad_anio");
            entity.Property(e => e.EdadDia).HasColumnName("edad_dia");
            entity.Property(e => e.EdadMes).HasColumnName("edad_mes");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.Genero)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");
            entity.Property(e => e.NomMadre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_madre");
            entity.Property(e => e.NomPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_paciente");
            entity.Property(e => e.NomPadre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_padre");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ocupacion");
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("responsable");
            entity.Property(e => e.TelRespon)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("tel_respon");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdExpedienteNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdExpediente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_pac_exp");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.IdPreguntas).HasName("PK__Pregunta__0F70E358183DC312");

            entity.Property(e => e.IdPreguntas).HasColumnName("id_preguntas");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Pregunta1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pregunta");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.IdRecetas).HasName("PK__Recetas__A2A77312AF63F4FB");

            entity.Property(e => e.IdRecetas).HasColumnName("idRecetas");
            entity.Property(e => e.CodRecetas)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cod_recetas");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Medicamento)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Prescripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__6ABCB5E04DAEBB79");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Secretarium>(entity =>
        {
            entity.HasKey(e => e.IdSecretaria).HasName("PK__Secretar__9029585542DE21A1");

            entity.Property(e => e.IdSecretaria).HasColumnName("id_secretaria");
            entity.Property(e => e.ApeSecre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ape_secre");
            entity.Property(e => e.CodSecre)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_secre");
            entity.Property(e => e.DirSecre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dir_secre");
            entity.Property(e => e.DuiSecre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dui_secre");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NomSecre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_secre");
            entity.Property(e => e.TelSecre)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("tel_secre");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Secretaria)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_secre_user");
        });

        modelBuilder.Entity<ServicioMedico>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6FD07FDC8D30E4B1");

            entity.ToTable("ServicioMedico");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.CodServicio)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_servicio");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdMedico).HasColumnName("id_medico");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.ServicioMedicos)
                .HasForeignKey(d => d.IdMedico)
                .HasConstraintName("fk_ser_mec");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04ADDD889B84");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NomUser)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom_user");
            entity.Property(e => e.PassUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pass_user");
            entity.Property(e => e.RespUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("resp_user");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_preg");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
