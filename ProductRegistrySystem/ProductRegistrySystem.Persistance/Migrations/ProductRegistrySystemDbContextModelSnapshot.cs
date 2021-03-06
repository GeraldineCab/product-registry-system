// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductRegistrySystem.Persistence;

namespace ProductRegistrySystem.Persistence.Migrations
{
    [DbContext(typeof(ProductRegistrySystemDbContext))]
    partial class ProductRegistrySystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ProductRegistrySystem.Persistence.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1010,
                            Description = "Vestido de escote redondo y tirantes. Bajo combinado a tono.",
                            Name = "VESTIDO COMBINADO RIB",
                            Price = 109900.0,
                            Status = 1,
                            Stock = 338
                        },
                        new
                        {
                            Id = 1011,
                            Description = "Vestido confeccionado con tejido en mezcla de lino.",
                            Name = "VESTIDO MINI CON LINO",
                            Price = 179900.0,
                            Status = 1,
                            Stock = 399
                        },
                        new
                        {
                            Id = 1012,
                            Description = "Vestido corto de escote redondo y tirantes finos ajustables.",
                            Name = "VESTIDO CORTO FLUIDO",
                            Price = 99900.0,
                            Status = 0,
                            Stock = 429
                        },
                        new
                        {
                            Id = 1013,
                            Description = "Vestido de escote pico y tirantes finos. Detalle de aplique delantero combinado a tono.",
                            Name = "VESTIDO MINI APLIQUE CINTURA",
                            Price = 15900.0,
                            Status = 0,
                            Stock = 239
                        },
                        new
                        {
                            Id = 1014,
                            Description = "Vestido de escote pico y tirantes finos. Detalle de aberturas en delantero y espalda.",
                            Name = "VESTIDO MINI ESTAMPADO ANIMAL CUT OUT",
                            Price = 179900.0,
                            Status = 1,
                            Stock = 354
                        },
                        new
                        {
                            Id = 1015,
                            Description = "Vestido confeccionado con tejido en mezcla de lino y algodón.",
                            Name = "VESTIDO CORTO CON LINO",
                            Price = 129900.0,
                            Status = 1,
                            Stock = 248
                        },
                        new
                        {
                            Id = 1016,
                            Description = "Vestido de cuello redondo y manga larga asimétrica.",
                            Name = "VESTIDO ASIMÉTRICO CORTO",
                            Price = 169900.0,
                            Status = 1,
                            Stock = 165
                        },
                        new
                        {
                            Id = 1017,
                            Description = "Vestido de cuello bobo con bordados perforados a tono.",
                            Name = "VESTIDO BORDADOS CUELLO",
                            Price = 199900.0,
                            Status = 1,
                            Stock = 214
                        },
                        new
                        {
                            Id = 1018,
                            Description = "Vestido mini de cuello solapa con escote pico y manga larga.",
                            Name = "VESTIDO SATINADO CRUZADO",
                            Price = 129900.0,
                            Status = 0,
                            Stock = 318
                        },
                        new
                        {
                            Id = 1019,
                            Description = "Vestido de escote pico y tirantes finos.Tejido con frunces.",
                            Name = "VESTIDO FRUNCES ABALORIOS",
                            Price = 199900.0,
                            Status = 0,
                            Stock = 284
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
