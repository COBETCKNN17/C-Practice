using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginRegistration.Migrations
{
    public partial class SettingUpUserMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_login_Email",
                table: "users",
                column: "Email",
                principalTable: "login",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_login_Email",
                table: "users");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
