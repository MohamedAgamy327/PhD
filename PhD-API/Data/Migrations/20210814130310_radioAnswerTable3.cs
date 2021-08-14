using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class radioAnswerTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerRadios_Answers_AnswerId",
                table: "AnswerRadios");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "AnswerRadios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.AddForeignKey(
                name: "FK_AnswerRadios_Answers_AnswerId",
                table: "AnswerRadios",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerRadios_Answers_AnswerId",
                table: "AnswerRadios");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "AnswerRadios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_AnswerRadios_Answers_AnswerId",
                table: "AnswerRadios",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
