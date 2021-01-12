using Microsoft.EntityFrameworkCore.Migrations;

namespace curso.Api.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
               name: "TB_CURSO",
               columns: table => new
               {
                   Codigo= table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<int>(nullable: true),
                   Descricao = table.Column<string>(nullable: true),
                   CodigoUser = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TB_CURSO", x => x.Codigo);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER");
            migrationBuilder.DropTable(
                name: "TB_CURSO");
            migrationBuilder.DropTable(
                name: "Estudante");
        }
    }
}
