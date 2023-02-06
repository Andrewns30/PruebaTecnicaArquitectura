using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__2F813BE355A3BBE9", x => x.usuID);
                });


            migrationBuilder.InsertData(
               table: "Usuario",
               columns: new[] { "usuID", "nombre", "apellido" },
               values: new object[] { 1, "Andrew", "Noreña Sanchez" });

            migrationBuilder.InsertData(
               table: "Usuario",
               columns: new[] { "usuID", "nombre", "apellido" },
               values: new object[] { 2, "Jairo", "Lopez" });

            migrationBuilder.InsertData(
               table: "Usuario",
               columns: new[] { "usuID", "nombre", "apellido" },
               values: new object[] { 3, "Camilo", "Muñoz" });

            migrationBuilder.InsertData(
               table: "Usuario",
               columns: new[] { "usuID", "nombre", "apellido" },
               values: new object[] { 4, "Alejandra", "Oregon" });

            migrationBuilder.InsertData(
               table: "Usuario",
               columns: new[] { "usuID", "nombre", "apellido" },
               values: new object[] { 5, "Jeicob", "Giraldo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
