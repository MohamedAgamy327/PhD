using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ResearchQuestionsTable17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Answered",
                table: "ResearchsQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AnswersCount",
                table: "Researchs",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 249, 99, 132, 117, 11, 24, 78, 90, 207, 83, 101, 248, 193, 104, 126, 216, 105, 190, 109, 94, 82, 133, 84, 10, 11, 17, 162, 106, 248, 81, 233, 132, 195, 89, 127, 208, 250, 203, 122, 81, 66, 6, 191, 111, 139, 85, 214, 42, 80, 136, 1, 185, 28, 223, 232, 126, 222, 67, 152, 57, 46, 87, 242 }, new byte[] { 187, 156, 236, 173, 211, 57, 19, 237, 49, 208, 100, 187, 3, 5, 243, 49, 154, 30, 221, 52, 96, 37, 32, 61, 209, 40, 64, 45, 254, 232, 134, 35, 232, 79, 127, 1, 113, 166, 82, 2, 162, 182, 155, 217, 142, 171, 193, 106, 121, 3, 173, 131, 136, 199, 210, 77, 207, 206, 206, 103, 105, 157, 112, 241, 248, 205, 169, 72, 36, 94, 152, 208, 34, 182, 59, 53, 1, 49, 100, 142, 1, 172, 12, 196, 109, 42, 88, 195, 170, 71, 90, 44, 78, 104, 169, 185, 152, 181, 72, 175, 67, 163, 108, 212, 130, 32, 84, 202, 32, 84, 207, 233, 192, 2, 243, 162, 77, 46, 223, 7, 234, 247, 88, 139, 97, 186, 145, 197 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answered",
                table: "ResearchsQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "AnswersCount",
                table: "Researchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 243, 214, 11, 176, 102, 198, 23, 34, 174, 165, 110, 76, 152, 234, 164, 95, 244, 59, 37, 197, 29, 43, 182, 65, 243, 113, 148, 55, 59, 0, 24, 248, 191, 112, 211, 80, 255, 221, 166, 12, 108, 78, 15, 176, 197, 24, 130, 206, 192, 81, 29, 6, 119, 238, 238, 205, 98, 111, 209, 182, 105, 26, 185 }, new byte[] { 2, 74, 183, 244, 119, 164, 239, 84, 13, 119, 32, 245, 31, 251, 61, 206, 146, 161, 21, 141, 248, 176, 97, 20, 171, 153, 187, 24, 37, 225, 91, 120, 147, 166, 148, 80, 7, 45, 31, 109, 65, 162, 18, 231, 156, 51, 15, 248, 95, 48, 35, 9, 133, 87, 169, 54, 58, 129, 190, 151, 158, 237, 46, 59, 82, 247, 192, 222, 78, 105, 50, 127, 106, 209, 122, 148, 12, 15, 3, 239, 140, 182, 64, 165, 86, 146, 192, 195, 29, 45, 118, 233, 230, 116, 248, 53, 225, 60, 228, 62, 154, 225, 232, 118, 119, 150, 236, 119, 119, 23, 69, 146, 47, 69, 151, 118, 86, 219, 243, 13, 146, 111, 231, 248, 33, 86, 224, 82 } });
        }
    }
}
