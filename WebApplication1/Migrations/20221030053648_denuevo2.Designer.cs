// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiHuevos3;

#nullable disable

namespace WebApiHuevos3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221030053648_denuevo2")]
    partial class denuevo2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiHuevos3.Entidades.Encargado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Encargados");
                });

            modelBuilder.Entity("WebApiHuevos3.Entidades.Huevo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<int>("EncargadoId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EncargadoId");

                    b.ToTable("Huevos");
                });

            modelBuilder.Entity("WebApiHuevos3.Entidades.Huevo", b =>
                {
                    b.HasOne("WebApiHuevos3.Entidades.Encargado", "Encargado")
                        .WithMany("huevos")
                        .HasForeignKey("EncargadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encargado");
                });

            modelBuilder.Entity("WebApiHuevos3.Entidades.Encargado", b =>
                {
                    b.Navigation("huevos");
                });
#pragma warning restore 612, 618
        }
    }
}
