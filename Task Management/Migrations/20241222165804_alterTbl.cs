using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Management.Migrations
{
    /// <inheritdoc />
    public partial class alterTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbltaskItem_tblemployee_AssignmentEmployeeId",
                table: "tbltaskItem");

            migrationBuilder.DropIndex(
                name: "IX_tbltaskItem_AssignmentEmployeeId",
                table: "tbltaskItem");

            migrationBuilder.DropColumn(
                name: "AssignmentEmployeeId",
                table: "tbltaskItem");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbltaskItem");

            migrationBuilder.AddColumn<string>(
                name: "AssignmentEmployee",
                table: "tbltaskItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "tbltaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tblemployee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "tblstatus",
                columns: table => new
                {
                    SID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblstatus", x => x.SID);
                });

            migrationBuilder.InsertData(
                table: "tblstatus",
                columns: new[] { "SID", "status" },
                values: new object[,]
                {
                    { 1, "pending" },
                    { 2, "complete" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblstatus");

            migrationBuilder.DropColumn(
                name: "AssignmentEmployee",
                table: "tbltaskItem");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "tbltaskItem");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentEmployeeId",
                table: "tbltaskItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tbltaskItem",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "tblemployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tbltaskItem_AssignmentEmployeeId",
                table: "tbltaskItem",
                column: "AssignmentEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbltaskItem_tblemployee_AssignmentEmployeeId",
                table: "tbltaskItem",
                column: "AssignmentEmployeeId",
                principalTable: "tblemployee",
                principalColumn: "EmpId");
        }
    }
}
