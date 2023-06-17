using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProyectoBG.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaldoCuentas = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.IdCuenta);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    IdTransaccion = table.Column<int>(type: "int", nullable: false),
                    entradas = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_Entradas_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    IdTransaccion = table.Column<int>(type: "int", nullable: false),
                    salidas = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_Salidas_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "IdCuenta", "NombreCuenta", "SaldoCuentas", "tipoCuenta" },
                values: new object[] { 1, "Banco", 1500m, "Activo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Salidas");

            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
