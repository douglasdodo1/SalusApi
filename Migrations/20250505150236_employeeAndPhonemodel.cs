using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class employeeAndPhonemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_User_Cpf",
                table: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Phone",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_User_Cpf",
                table: "Phone",
                column: "Cpf",
                principalTable: "User",
                principalColumn: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_User_Cpf",
                table: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Phone",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_User_Cpf",
                table: "Phone",
                column: "Cpf",
                principalTable: "User",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
