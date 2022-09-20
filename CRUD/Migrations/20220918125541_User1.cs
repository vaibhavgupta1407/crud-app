﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Migrations
{
    public partial class User1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemember",
                table: "users");

            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemember",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
