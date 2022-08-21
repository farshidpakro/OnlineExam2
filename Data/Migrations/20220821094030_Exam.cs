using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    public partial class Exam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examlist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stdgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stdnum = table.Column<int>(type: "int", nullable: false),
                    Stdgrade = table.Column<int>(type: "int", nullable: false),
                    Questioncount = table.Column<int>(type: "int", nullable: false),
                    Examname = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Stdname = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stdgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qs = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Anone = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Antwo = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Anthree = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Anfour = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Qskey = table.Column<int>(type: "int", nullable: false),
                    Examlistid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Examlist_Examlistid",
                        column: x => x.Examlistid,
                        principalTable: "Examlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studentnum = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Examlistid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Examlist_Examlistid",
                        column: x => x.Examlistid,
                        principalTable: "Examlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qsans = table.Column<int>(type: "int", nullable: false),
                    Qskey = table.Column<int>(type: "int", nullable: false),
                    Examname = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Stdforeinkey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Students_Stdforeinkey",
                        column: x => x.Stdforeinkey,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Stdforeinkey",
                table: "Grade",
                column: "Stdforeinkey");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Examlistid",
                table: "Questions",
                column: "Examlistid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Examlistid",
                table: "Students",
                column: "Examlistid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Stdgrades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Examlist");
        }
    }
}
