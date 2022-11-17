using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba.Migrations
{
    public partial class Segundocambio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_User_UsuarioId",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_User_UsuarioId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_UsuarioId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_UsuarioId",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cargo");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cargoId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "Departamento",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "Cargo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_cargoId",
                table: "User",
                column: "cargoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartamentoId",
                table: "User",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Cargo_cargoId",
                table: "User",
                column: "cargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Departamento_DepartamentoId",
                table: "User",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Cargo_cargoId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Departamento_DepartamentoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_cargoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DepartamentoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "cargoId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Activo",
                table: "Departamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Departamento",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Activo",
                table: "Cargo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cargo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_UsuarioId",
                table: "Departamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_UsuarioId",
                table: "Cargo",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_User_UsuarioId",
                table: "Cargo",
                column: "UsuarioId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_User_UsuarioId",
                table: "Departamento",
                column: "UsuarioId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
