using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductRegistrySystem.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "Status", "Stock" },
                values: new object[,]
                {
                    { 1010, "Vestido de escote redondo y tirantes. Bajo combinado a tono.", "VESTIDO COMBINADO RIB", 109900.0, 1, 338 },
                    { 1011, "Vestido confeccionado con tejido en mezcla de lino.", "VESTIDO MINI CON LINO", 179900.0, 1, 399 },
                    { 1012, "Vestido corto de escote redondo y tirantes finos ajustables.", "VESTIDO CORTO FLUIDO", 99900.0, 0, 429 },
                    { 1013, "Vestido de escote pico y tirantes finos. Detalle de aplique delantero combinado a tono.", "VESTIDO MINI APLIQUE CINTURA", 15900.0, 0, 239 },
                    { 1014, "Vestido de escote pico y tirantes finos. Detalle de aberturas en delantero y espalda.", "VESTIDO MINI ESTAMPADO ANIMAL CUT OUT", 179900.0, 1, 354 },
                    { 1015, "Vestido confeccionado con tejido en mezcla de lino y algodón.", "VESTIDO CORTO CON LINO", 129900.0, 1, 248 },
                    { 1016, "Vestido de cuello redondo y manga larga asimétrica.", "VESTIDO ASIMÉTRICO CORTO", 169900.0, 1, 165 },
                    { 1017, "Vestido de cuello bobo con bordados perforados a tono.", "VESTIDO BORDADOS CUELLO", 199900.0, 1, 214 },
                    { 1018, "Vestido mini de cuello solapa con escote pico y manga larga.", "VESTIDO SATINADO CRUZADO", 129900.0, 0, 318 },
                    { 1019, "Vestido de escote pico y tirantes finos.Tejido con frunces.", "VESTIDO FRUNCES ABALORIOS", 199900.0, 0, 284 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
