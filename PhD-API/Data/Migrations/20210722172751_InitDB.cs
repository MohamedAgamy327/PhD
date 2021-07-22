using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Researchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTimeEmployeesNumber = table.Column<int>(type: "int", nullable: false),
                    PartTimeEmployeesNumber = table.Column<int>(type: "int", nullable: false),
                    PhDResearchersNumber = table.Column<int>(type: "int", nullable: false),
                    MastersResearchersNumber = table.Column<int>(type: "int", nullable: false),
                    BachelorsResearchersNumber = table.Column<int>(type: "int", nullable: false),
                    TechniciansNumber = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsRandomPassword = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsRandomPassword = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Header", "Order", "Type" },
                values: new object[,]
                {
                    { 2, "2- مجال البحث والتطوير التجريبي لهذا المشروع: (يمكن ان يقوم المشروع البحثي على مجال بحثي واحد أو اكثر)", null, 2, 1 },
                    { 3, "3- نوع النشاط البحثى:", null, 3, 0 },
                    { 6, "6- الجهات المنفذه لهذا المشروع", null, 6, 1 },
                    { 7, "7- مستوى التطبيق البحثى", null, 7, 0 },
                    { 8, "8- هل قمتم (او من المتوقع) تطوير احد المنتجات (سلعة أو خدمة) من خلال المشروع  ومخرجاته؟، من فضلك حدد نوع التطوير من خلال أحد الخيارات الأتية ", null, 8, 1 },
                    { 9, "9-هل تم التوصل الى احد الابتكارات الأتية", null, 9, 1 },
                    { 10, "10 – هل تم من خلال مخرجات المشروع الاستثمار  في أحد الأصول غير الملموسة؟ ما هي هذه الأصول؟ من خلال أحد الخيارات الأتية", null, 10, 1 },
                    { 12, "12- هل هناك وفورات خارجية (انعكاسات غير مباشرة) متولدة من المشروع (او متوقع تولدها)؟، ما هو نوع هذه العوائد  من خلال احد الخيارات التالية", null, 12, 1 },
                    { 13, "13-هل تم الاستفادةبوفورات خارجية (تأثير غير مباشر) من خلال مدة المشروع (أو كما متوقع) من الأصول غير الملموسة المتولدة من تطبيق المشروع (او متوقع تولدها)؟، ما هو نوع هذه الأصول من خلال احد الخيارات التالية", null, 13, 1 },
                    { 16, "16-هل يحسن نتائج ومخرجات المشروع من اي من الخدمات الانتاجية؟ ، في أي خدمات الانتاج تم تحسينها من خلال احد الخيارات التالية:", null, 16, 1 },
                    { 17, "17-       هل تحسن نتائج اومخرجات المشروع (او من المتوقع ان تحسن) من اي من الخدمات الاجتماعية والثقافية والشخصية ؟ ، في أي الخدمات الاجتماعية والثقافية والشخصية تم تحسينها من خلال احد الخيارات التالية", null, 17, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsRandomPassword", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "Admin@gmail.com", true, "Admin", new byte[] { 130, 220, 86, 163, 163, 105, 166, 51, 174, 204, 61, 110, 77, 137, 195, 170, 197, 167, 36, 111, 45, 98, 141, 23, 68, 34, 36, 209, 116, 170, 223, 70, 8, 232, 134, 90, 26, 3, 130, 76, 190, 34, 176, 175, 34, 132, 165, 136, 221, 161, 227, 171, 255, 90, 153, 226, 68, 241, 185, 54, 76, 93, 84, 226 }, new byte[] { 70, 171, 53, 25, 125, 75, 101, 96, 248, 132, 219, 251, 152, 21, 197, 179, 247, 167, 34, 230, 136, 18, 238, 125, 79, 220, 14, 73, 207, 213, 162, 87, 176, 0, 121, 28, 136, 19, 194, 88, 171, 74, 137, 84, 137, 127, 169, 233, 177, 86, 87, 249, 206, 74, 253, 109, 245, 30, 227, 247, 153, 187, 124, 108, 246, 226, 133, 140, 7, 131, 32, 57, 33, 113, 147, 150, 167, 149, 163, 193, 13, 8, 83, 213, 135, 12, 94, 27, 43, 250, 201, 241, 238, 221, 56, 214, 210, 179, 25, 129, 84, 137, 226, 167, 196, 91, 34, 226, 242, 13, 211, 200, 135, 69, 180, 132, 23, 18, 227, 215, 162, 151, 221, 65, 244, 42, 192, 177 } });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Researchs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
