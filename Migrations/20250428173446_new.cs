using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModel_User_Cpf",
                table: "PhoneModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneModel",
                table: "PhoneModel");

            migrationBuilder.RenameTable(
                name: "PhoneModel",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneModel_Cpf",
                table: "Phone",
                newName: "IX_Phone_Cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phone",
                table: "Phone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_User_Cpf",
                table: "Phone",
                column: "Cpf",
                principalTable: "User",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_User_Cpf",
                table: "Phone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phone",
                table: "Phone");

            migrationBuilder.RenameTable(
                name: "Phone",
                newName: "PhoneModel");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_Cpf",
                table: "PhoneModel",
                newName: "IX_PhoneModel_Cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneModel",
                table: "PhoneModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModel_User_Cpf",
                table: "PhoneModel",
                column: "Cpf",
                principalTable: "User",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
