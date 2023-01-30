using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCLWebAPI.Server.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Departments");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("19aef916-f24e-438c-9529-54419867ce85"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2e0af6f-006c-416e-aa5c-a6426243a679", "AQAAAAEAACcQAAAAEMxa/L00gY1tIeq6dhMy579L+Px5PZikXmz4f187a1vjX2w5jTMoUCbrsFXF3vriCA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7f8ab44-dc1e-48c0-9c84-210a2efb1892"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b728894a-3dcd-4ec7-8324-4469cc478325", "AQAAAAEAACcQAAAAEIh9g6buoPWrBF6wOfdQo12afdWHxgSm0mgdAz0n2JMDt7iRtcUBCLZ9oQVB75nkDg==" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                column: "Salary",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 2,
                column: "Salary",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 3,
                column: "Salary",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 4,
                column: "Salary",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("19aef916-f24e-438c-9529-54419867ce85"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "004d7abd-9ca9-494a-9610-2a07df0cfa8f", "AQAAAAEAACcQAAAAEGQe2Lvs29b833as+LEyHaDrYMGfQZwVLwQ0mB9YaYZpivL5jOBarW3rUOCfzFF9BQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7f8ab44-dc1e-48c0-9c84-210a2efb1892"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "955f39e0-c3a9-4960-a784-091d2ece29b3", "AQAAAAEAACcQAAAAEKnDJ6Onjpmw9nYW+u3oxg27Lb1S/3mUb3OYXS0NnGYvGrxXGyHQ2hyu/QIsGqzfcA==" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 1,
                column: "EmployeeID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 2,
                column: "EmployeeID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 3,
                column: "EmployeeID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 4,
                column: "EmployeeID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 5,
                column: "EmployeeID",
                value: 0);
        }
    }
}
