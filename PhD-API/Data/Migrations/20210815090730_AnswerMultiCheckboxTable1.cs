using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AnswerMultiCheckboxTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Checked2",
                table: "AnswerMultiCheckboxs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Checked1",
                table: "AnswerMultiCheckboxs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 1, 54, 245, 110, 82, 4, 72, 129, 50, 8, 75, 245, 136, 87, 53, 152, 2, 254, 22, 161, 188, 21, 218, 4, 239, 245, 156, 250, 144, 127, 177, 212, 73, 202, 227, 9, 130, 208, 35, 164, 117, 157, 232, 171, 7, 59, 189, 50, 180, 234, 232, 116, 40, 20, 123, 131, 83, 63, 223, 201, 194, 242, 121 }, new byte[] { 184, 151, 78, 115, 227, 44, 109, 227, 18, 178, 83, 107, 196, 103, 26, 121, 52, 175, 85, 253, 217, 123, 104, 12, 47, 162, 245, 122, 36, 250, 170, 229, 29, 47, 192, 181, 47, 220, 103, 108, 219, 12, 189, 21, 173, 129, 131, 83, 192, 240, 254, 120, 232, 203, 225, 218, 173, 14, 101, 133, 85, 197, 69, 187, 140, 73, 119, 160, 149, 4, 222, 209, 119, 113, 37, 235, 189, 45, 158, 12, 153, 199, 42, 200, 27, 123, 89, 122, 64, 25, 71, 204, 59, 185, 76, 5, 40, 186, 64, 246, 91, 213, 65, 52, 152, 188, 176, 51, 66, 161, 32, 200, 75, 118, 50, 143, 147, 85, 241, 140, 24, 48, 4, 170, 193, 208, 110, 227 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Checked2",
                table: "AnswerMultiCheckboxs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Checked1",
                table: "AnswerMultiCheckboxs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 41, 162, 35, 242, 72, 66, 143, 144, 63, 15, 190, 185, 37, 68, 206, 131, 54, 87, 209, 227, 220, 111, 250, 110, 89, 139, 186, 223, 114, 149, 164, 131, 193, 99, 155, 181, 68, 31, 176, 205, 66, 52, 208, 68, 146, 232, 71, 144, 52, 102, 190, 85, 34, 31, 43, 204, 43, 136, 112, 158, 248, 223, 72, 160 }, new byte[] { 187, 158, 69, 168, 66, 116, 3, 16, 166, 192, 27, 90, 6, 30, 149, 22, 224, 56, 174, 18, 195, 94, 66, 143, 80, 219, 187, 217, 188, 161, 144, 168, 88, 176, 146, 183, 151, 165, 144, 37, 232, 77, 209, 26, 252, 48, 21, 8, 50, 59, 60, 195, 200, 84, 229, 135, 108, 191, 204, 193, 189, 159, 139, 214, 182, 139, 200, 251, 129, 153, 52, 215, 218, 238, 4, 22, 142, 68, 144, 44, 169, 84, 54, 249, 180, 185, 28, 59, 97, 164, 205, 195, 202, 129, 31, 31, 99, 69, 81, 197, 79, 33, 211, 160, 82, 78, 71, 165, 158, 223, 138, 81, 81, 48, 239, 233, 250, 150, 228, 119, 244, 113, 102, 116, 62, 231, 150, 52 } });
        }
    }
}
