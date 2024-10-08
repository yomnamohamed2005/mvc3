using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_access_lyer.Migrations
{
    /// <inheritdoc />
    public partial class Employeedepartmentrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_departmentId",
                table: "employee",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_departmentId",
                table: "employee",
                column: "departmentId",
                principalTable: "department",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_departmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_departmentId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "employee");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
