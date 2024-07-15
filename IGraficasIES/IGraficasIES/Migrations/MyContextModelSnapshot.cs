﻿// <auto-generated />
using IGraficasIES.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IGraficasIES.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IGraficasIES.ProfesorExtendido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IEstatura")
                        .HasColumnType("int");

                    b.Property<int>("IPeso")
                        .HasColumnType("int");

                    b.Property<string>("ProfesorFuncionarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TipoEstado")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProfesorFuncionarioId")
                        .IsUnique();

                    b.ToTable("OtrosDatosProfesores");
                });

            modelBuilder.Entity("IGraficasIES.modelos.ProfesorFuncionario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("BDestinoDefinitivo")
                        .HasColumnType("bit");

                    b.Property<int>("IAnyoIngresoCuerpo")
                        .HasColumnType("int");

                    b.Property<int>("IEdad")
                        .HasColumnType("int");

                    b.Property<string>("SApellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SMateria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SRutaFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TipoProfesor")
                        .HasColumnType("bigint");

                    b.Property<long>("TipoSeguro")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("IGraficasIES.ProfesorExtendido", b =>
                {
                    b.HasOne("IGraficasIES.modelos.ProfesorFuncionario", null)
                        .WithOne("profesorExtendido")
                        .HasForeignKey("IGraficasIES.ProfesorExtendido", "ProfesorFuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IGraficasIES.modelos.ProfesorFuncionario", b =>
                {
                    b.Navigation("profesorExtendido")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
