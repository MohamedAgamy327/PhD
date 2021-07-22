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
                values: new object[] { 1, "Admin@gmail.com", true, "Admin", new byte[] { 174, 36, 253, 254, 65, 114, 86, 166, 128, 28, 120, 36, 6, 151, 246, 32, 28, 121, 130, 245, 64, 140, 239, 218, 252, 211, 17, 198, 32, 177, 131, 0, 69, 156, 75, 182, 129, 111, 236, 207, 34, 18, 149, 202, 200, 138, 149, 138, 41, 159, 12, 178, 73, 255, 35, 86, 222, 3, 79, 151, 0, 232, 119, 251 }, new byte[] { 22, 92, 247, 2, 177, 0, 107, 205, 73, 205, 27, 70, 171, 197, 195, 212, 136, 212, 255, 153, 117, 223, 49, 168, 67, 83, 184, 156, 126, 212, 219, 209, 80, 203, 49, 162, 124, 178, 64, 196, 179, 51, 143, 153, 91, 80, 87, 223, 124, 207, 227, 185, 14, 145, 22, 164, 208, 251, 204, 52, 199, 47, 120, 106, 226, 138, 110, 142, 87, 59, 167, 89, 6, 116, 126, 72, 73, 238, 194, 244, 155, 99, 32, 103, 117, 161, 203, 38, 69, 252, 45, 180, 168, 212, 28, 129, 191, 47, 208, 119, 49, 123, 48, 148, 137, 208, 166, 255, 134, 123, 208, 9, 95, 158, 189, 191, 50, 134, 172, 225, 102, 183, 254, 125, 239, 207, 243, 85 } });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[,]
                {
                    { 1, "العلوم الطبيعية", 2 },
                    { 28, "10-2- عائد حقوق الملكية والنشر", 10 },
                    { 29, "10-3- براءات اختراع/ تصميمات صناعية ", 10 },
                    { 30, "10-4- منتجات إبداعية وثقافية", 10 },
                    { 31, "10-5- علامة تجارية", 10 },
                    { 32, "10-6-اعادة تأهيل أو تدريب عدد من الباحثين او المستفيدين من المشروع", 10 },
                    { 33, "12-1- تحسين معدلات الانتاج أو المبيعات", 12 },
                    { 34, "12-2- تحسين العمليات الانتاجية", 12 },
                    { 35, "12-3- تحسين في أساليب الادارة والانتاج", 12 },
                    { 36, "13-1- مجال البرمجيات ونظم الحاسب وقواعد البيانات", 13 },
                    { 37, "13-2- الاستفادة من براءات الاختراع أو تصميمات صناعية", 13 },
                    { 38, "13-3- تحسين في كفاءة العمالة (بفعل التدريب)", 13 },
                    { 39, "13-4-تحسن في أساليب الإدارة والتنظيم والتسويق", 13 },
                    { 40, "16-1-خدمات تجارة الجملة والتجزئة والفنادق والغذاء", 16 },
                    { 41, "16-2-خدمات النقل والتخزين والاصلاح", 16 },
                    { 42, "16-3-الخدمات المالية والتأمين", 16 },
                    { 43, "16-4-خدمات قطاع الأعمال والعقار", 16 },
                    { 44, "16-5-خدمات البحث والتطوير", 16 },
                    { 45, "16-6-خدمات المعلومات والاتصالات والنشر والاعلام", 16 },
                    { 46, "17-1-التعليم والتدريب وبناء القدرات", 17 },
                    { 47, "17-2-خدمات الصحة والرعاية الصحية", 17 },
                    { 48, "17-3-خدمات ثقافية وفنية وترفيهية", 17 },
                    { 27, "10-1- البرمجيات وقواعد البيانات", 10 },
                    { 26, "أساليب تسويق جديدة", 9 },
                    { 25, "تنظيم وإدارة جديدة ", 9 },
                    { 24, "عملية إنتاجية جديدة (أو محسنة بشكل كبير)", 9 },
                    { 2, "العلوم الزراعية والبيطرية", 2 },
                    { 3, "العلوم الإنسانية", 2 },
                    { 4, "العلوم الاجتماعية", 2 },
                    { 5, "هندسة وتكنولوجيا", 2 },
                    { 6, "العلوم الطبية والصحية", 2 },
                    { 7, "بحث أساسي", 3 },
                    { 8, "بحث تطبيقي", 3 },
                    { 9, "تطوير تجريبي", 3 },
                    { 10, "أكاديمية (جامعة/ مؤسسة بحثية/ معهد علمى)", 6 },
                    { 11, "صناعية (وحدة انتاجية/ قطاع انتاجى/ صناعة)", 6 },
                    { 49, "17-4-الادارة العامة والدفاع والأمن", 17 },
                    { 12, "جهات غير هادفة للربح (مؤسسة مجتمع مدنى)", 6 },
                    { 14, " مستوى الشركة (أو المؤسسة الانتاجية ))", 7 },
                    { 15, "مستوى الصناعة  (أو القطاع الانتاجى )", 7 },
                    { 16, "مستوى الاقتصاد الوطنى", 7 },
                    { 17, "مستوى اقليمى أو دولى  (المشروعات المشتركة )", 7 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "QuestionId" },
                values: new object[,]
                {
                    { 18, "8-1- زيادة في حجم الانتاج", 8 },
                    { 19, "8-2- تحسين مستوى الخدمة أوالمنتج", 8 },
                    { 20, "8-3- تطوير عملية الإنتاج", 8 },
                    { 21, "8-4- زيادة في حجم المبيعات", 8 },
                    { 22, "8-5- تحسين في أساليب الإدارة والتسويق", 8 },
                    { 23, "منتج جديد (أو محسن بشكل كبير)", 9 },
                    { 13, "جهات دولية أو اقليمية", 6 },
                    { 50, "17-5-خدمات شخصية وعائلية", 17 }
                });

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
