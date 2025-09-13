using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId1",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioId1",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<double>(
                name: "Id",
                table: "Usuarios",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<double>(
                name: "UsuarioId1",
                table: "Tarefas",
                type: "double",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId1",
                table: "Tarefas",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId1",
                table: "Tarefas",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
