using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FABRADE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fabradeTransactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contact_name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    dress_type = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    age = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fabradeTransactions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fabradeTransactions");
        }
    }
}
