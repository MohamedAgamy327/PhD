﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "العلوم الطبيعية",
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 2,
                            Content = "العلوم الزراعية والبيطرية",
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "العلوم الإنسانية",
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "العلوم الاجتماعية",
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 5,
                            Content = "هندسة وتكنولوجيا",
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 6,
                            Content = "العلوم الطبية والصحية",
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 7,
                            Content = "بحث أساسي",
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 8,
                            Content = "بحث تطبيقي",
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 9,
                            Content = "تطوير تجريبي",
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 10,
                            Content = "أكاديمية (جامعة/ مؤسسة بحثية/ معهد علمى)",
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 11,
                            Content = "صناعية (وحدة انتاجية/ قطاع انتاجى/ صناعة)",
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 12,
                            Content = "جهات غير هادفة للربح (مؤسسة مجتمع مدنى)",
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 13,
                            Content = "جهات دولية أو اقليمية",
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 14,
                            Content = " مستوى الشركة (أو المؤسسة الانتاجية ))",
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 15,
                            Content = "مستوى الصناعة  (أو القطاع الانتاجى )",
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 16,
                            Content = "مستوى الاقتصاد الوطنى",
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 17,
                            Content = "مستوى اقليمى أو دولى  (المشروعات المشتركة )",
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 18,
                            Content = "8-1- زيادة في حجم الانتاج",
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 19,
                            Content = "8-2- تحسين مستوى الخدمة أوالمنتج",
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 20,
                            Content = "8-3- تطوير عملية الإنتاج",
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 21,
                            Content = "8-4- زيادة في حجم المبيعات",
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 22,
                            Content = "8-5- تحسين في أساليب الإدارة والتسويق",
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 23,
                            Content = "منتج جديد (أو محسن بشكل كبير)",
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 24,
                            Content = "عملية إنتاجية جديدة (أو محسنة بشكل كبير)",
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 25,
                            Content = "تنظيم وإدارة جديدة ",
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 26,
                            Content = "أساليب تسويق جديدة",
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 27,
                            Content = "10-1- البرمجيات وقواعد البيانات",
                            QuestionId = 10
                        },
                        new
                        {
                            Id = 28,
                            Content = "10-2- عائد حقوق الملكية والنشر",
                            QuestionId = 10
                        },
                        new
                        {
                            Id = 29,
                            Content = "10-3- براءات اختراع/ تصميمات صناعية ",
                            QuestionId = 10
                        },
                        new
                        {
                            Id = 30,
                            Content = "10-4- منتجات إبداعية وثقافية",
                            QuestionId = 10
                        },
                        new
                        {
                            Id = 31,
                            Content = "10-5- علامة تجارية",
                            QuestionId = 10
                        },
                        new
                        {
                            Id = 32,
                            Content = "10-6-اعادة تأهيل أو تدريب عدد من الباحثين او المستفيدين من المشروع",
                            QuestionId = 10
                        },
                        new
                        {
                            Id = 33,
                            Content = "12-1- تحسين معدلات الانتاج أو المبيعات",
                            QuestionId = 12
                        },
                        new
                        {
                            Id = 34,
                            Content = "12-2- تحسين العمليات الانتاجية",
                            QuestionId = 12
                        },
                        new
                        {
                            Id = 35,
                            Content = "12-3- تحسين في أساليب الادارة والانتاج",
                            QuestionId = 12
                        },
                        new
                        {
                            Id = 36,
                            Content = "13-1- مجال البرمجيات ونظم الحاسب وقواعد البيانات",
                            QuestionId = 13
                        },
                        new
                        {
                            Id = 37,
                            Content = "13-2- الاستفادة من براءات الاختراع أو تصميمات صناعية",
                            QuestionId = 13
                        },
                        new
                        {
                            Id = 38,
                            Content = "13-3- تحسين في كفاءة العمالة (بفعل التدريب)",
                            QuestionId = 13
                        },
                        new
                        {
                            Id = 39,
                            Content = "13-4-تحسن في أساليب الإدارة والتنظيم والتسويق",
                            QuestionId = 13
                        },
                        new
                        {
                            Id = 40,
                            Content = "16-1-خدمات تجارة الجملة والتجزئة والفنادق والغذاء",
                            QuestionId = 16
                        },
                        new
                        {
                            Id = 41,
                            Content = "16-2-خدمات النقل والتخزين والاصلاح",
                            QuestionId = 16
                        },
                        new
                        {
                            Id = 42,
                            Content = "16-3-الخدمات المالية والتأمين",
                            QuestionId = 16
                        },
                        new
                        {
                            Id = 43,
                            Content = "16-4-خدمات قطاع الأعمال والعقار",
                            QuestionId = 16
                        },
                        new
                        {
                            Id = 44,
                            Content = "16-5-خدمات البحث والتطوير",
                            QuestionId = 16
                        },
                        new
                        {
                            Id = 45,
                            Content = "16-6-خدمات المعلومات والاتصالات والنشر والاعلام",
                            QuestionId = 16
                        },
                        new
                        {
                            Id = 46,
                            Content = "17-1-التعليم والتدريب وبناء القدرات",
                            QuestionId = 17
                        },
                        new
                        {
                            Id = 47,
                            Content = "17-2-خدمات الصحة والرعاية الصحية",
                            QuestionId = 17
                        },
                        new
                        {
                            Id = 48,
                            Content = "17-3-خدمات ثقافية وفنية وترفيهية",
                            QuestionId = 17
                        },
                        new
                        {
                            Id = 49,
                            Content = "17-4-الادارة العامة والدفاع والأمن",
                            QuestionId = 17
                        },
                        new
                        {
                            Id = 50,
                            Content = "17-5-خدمات شخصية وعائلية",
                            QuestionId = 17
                        },
                        new
                        {
                            Id = 51,
                            Content = "4-1- التمويل المتاح من أكاديمية البحث العلمي (بالجنيه المصري)",
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 52,
                            Content = "4-2- التمويل المتاح من مصادر أخرى (بالجنيه المصري)",
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 53,
                            Content = "14-1-نسبة الانخفاض في تكلفة العمالة %",
                            QuestionId = 14
                        },
                        new
                        {
                            Id = 54,
                            Content = "14-2-نسبة الانخفاض في تكلفة المدخلات الوسيطة %",
                            QuestionId = 14
                        },
                        new
                        {
                            Id = 55,
                            Content = "14-3-نسبة الانخفاض في استهلاك الوقود (غاز/ كهرباء) %",
                            QuestionId = 14
                        },
                        new
                        {
                            Id = 56,
                            Content = "14-4-نسبة الانخفاض في استهلاك المياه %",
                            QuestionId = 14
                        },
                        new
                        {
                            Id = 57,
                            Content = "14-5-مصروفات عامة أخرى %",
                            QuestionId = 14
                        },
                        new
                        {
                            Id = 58,
                            Content = "15-1-الأرض والمباني",
                            QuestionId = 15
                        },
                        new
                        {
                            Id = 59,
                            Content = "15-2-الآلات والمعدات والمعامل وأجهزة الكمبيوتر",
                            QuestionId = 15
                        });
                });

            modelBuilder.Entity("Domain.Entities.AnswerCheckbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<bool>("Checked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("ResearchId");

                    b.ToTable("AnswerCheckboxs");
                });

            modelBuilder.Entity("Domain.Entities.AnswerMultiAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("ResearchId");

                    b.ToTable("AnswerMultiAmounts");
                });

            modelBuilder.Entity("Domain.Entities.AnswerMultiCheckbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<bool>("Checked1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Checked2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("Radio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("ResearchId");

                    b.ToTable("AnswerMultiCheckboxs");
                });

            modelBuilder.Entity("Domain.Entities.AnswerMultiPercentage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Number1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Number2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("Radio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("ResearchId");

                    b.ToTable("AnswerMultiPercentages");
                });

            modelBuilder.Entity("Domain.Entities.AnswerNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResearchId");

                    b.ToTable("AnswerNumbers");
                });

            modelBuilder.Entity("Domain.Entities.AnswerRadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("ResearchId");

                    b.ToTable("AnswerRadios");
                });

            modelBuilder.Entity("Domain.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Content = "2- مجال البحث والتطوير التجريبي لهذا المشروع: (يمكن ان يقوم المشروع البحثي على مجال بحثي واحد أو اكثر)",
                            Order = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "3- نوع النشاط البحثى:",
                            Order = 3,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Content = "4- إجمالي التمويل المتاح لهذا المشروع (بالجنيه المصري)",
                            Order = 4,
                            Type = 3
                        },
                        new
                        {
                            Id = 5,
                            Content = "5- الفترة الزمنية المحددة لتنفيذ هذا المشروع (عدد الشهور)",
                            Order = 5,
                            Type = 2
                        },
                        new
                        {
                            Id = 6,
                            Content = "6- الجهات المنفذه لهذا المشروع",
                            Order = 6,
                            Type = 1
                        },
                        new
                        {
                            Id = 7,
                            Content = "7- مستوى التطبيق البحثى",
                            Order = 7,
                            Type = 0
                        },
                        new
                        {
                            Id = 8,
                            Content = "8- هل قمتم (او من المتوقع) تطوير احد المنتجات (سلعة أو خدمة) من خلال المشروع  ومخرجاته؟، من فضلك حدد نوع التطوير من خلال أحد الخيارات الأتية ",
                            Order = 8,
                            Type = 1
                        },
                        new
                        {
                            Id = 9,
                            Content = "9-هل تم التوصل الى احد الابتكارات الأتية",
                            Order = 9,
                            Type = 1
                        },
                        new
                        {
                            Id = 10,
                            Content = "10 – هل تم من خلال مخرجات المشروع الاستثمار  في أحد الأصول غير الملموسة؟ ما هي هذه الأصول؟ من خلال أحد الخيارات الأتية",
                            Order = 10,
                            Type = 1
                        },
                        new
                        {
                            Id = 12,
                            Content = "12- هل هناك وفورات خارجية (انعكاسات غير مباشرة) متولدة من المشروع (او متوقع تولدها)؟، ما هو نوع هذه العوائد  من خلال احد الخيارات التالية",
                            Order = 12,
                            Type = 1
                        },
                        new
                        {
                            Id = 13,
                            Content = "13-هل تم الاستفادةبوفورات خارجية (تأثير غير مباشر) من خلال مدة المشروع (أو كما متوقع) من الأصول غير الملموسة المتولدة من تطبيق المشروع (او متوقع تولدها)؟، ما هو نوع هذه الأصول من خلال احد الخيارات التالية",
                            Order = 13,
                            Type = 1
                        },
                        new
                        {
                            Id = 14,
                            Content = "14- هل أثر هذا المشروع على تخفيض تكلفة الانفاق الجاري ؟",
                            Order = 14,
                            Type = 4
                        },
                        new
                        {
                            Id = 15,
                            Content = "15-هل أثر هذا المشروع على تخفيض تكلفة الانفاق الرأسمالي (او من المتوقع تخفيضه)؟ ، في أي التكاليف تم الانخفاض من خلال احد الخيارات التالية",
                            Order = 15,
                            Type = 5
                        },
                        new
                        {
                            Id = 16,
                            Content = "16-هل يحسن نتائج ومخرجات المشروع من اي من الخدمات الانتاجية؟ ، في أي خدمات الانتاج تم تحسينها من خلال احد الخيارات التالية:",
                            Order = 16,
                            Type = 1
                        },
                        new
                        {
                            Id = 17,
                            Content = "17-       هل تحسن نتائج اومخرجات المشروع (او من المتوقع ان تحسن) من اي من الخدمات الاجتماعية والثقافية والشخصية ؟ ، في أي الخدمات الاجتماعية والثقافية والشخصية تم تحسينها من خلال احد الخيارات التالية",
                            Order = 17,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Research", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BachelorsResearchersNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FullTimeEmployeesNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsRandomPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MastersResearchersNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartTimeEmployeesNumber")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PhDResearchersNumber")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("TechniciansNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Researchs");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRandomPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Admin@gmail.com",
                            IsRandomPassword = true,
                            Name = "Admin",
                            PasswordHash = new byte[] { 8, 104, 137, 45, 8, 185, 192, 92, 196, 40, 87, 248, 230, 50, 234, 176, 134, 107, 62, 52, 54, 246, 218, 222, 2, 23, 41, 100, 157, 7, 140, 49, 88, 121, 71, 102, 8, 69, 37, 96, 135, 90, 166, 60, 186, 239, 106, 224, 51, 51, 65, 123, 22, 31, 58, 164, 129, 67, 163, 67, 18, 179, 1, 78 },
                            PasswordSalt = new byte[] { 178, 213, 35, 101, 165, 61, 250, 233, 85, 140, 245, 141, 107, 250, 228, 59, 151, 58, 65, 212, 100, 185, 208, 187, 102, 23, 41, 252, 28, 241, 98, 151, 76, 65, 208, 214, 93, 207, 100, 26, 163, 38, 157, 79, 138, 164, 57, 228, 164, 232, 122, 142, 169, 49, 95, 250, 82, 37, 207, 31, 78, 140, 18, 81, 57, 240, 13, 147, 107, 165, 114, 174, 156, 48, 55, 181, 102, 174, 182, 54, 124, 25, 218, 212, 145, 170, 19, 161, 119, 217, 32, 20, 189, 207, 204, 57, 59, 191, 142, 236, 89, 140, 237, 35, 119, 141, 117, 112, 64, 80, 131, 17, 78, 144, 189, 203, 108, 247, 216, 124, 128, 147, 157, 249, 19, 90, 120, 215 },
                            Role = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.HasOne("Domain.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entities.AnswerCheckbox", b =>
                {
                    b.HasOne("Domain.Entities.Answer", "Answer")
                        .WithMany("AnswerCheckboxs")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Domain.Entities.Research", "Research")
                        .WithMany("AnswerCheckboxs")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Domain.Entities.AnswerMultiAmount", b =>
                {
                    b.HasOne("Domain.Entities.Answer", "Answer")
                        .WithMany("AnswerMultiAmounts")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Domain.Entities.Research", "Research")
                        .WithMany("AnswerMultiAmounts")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Domain.Entities.AnswerMultiCheckbox", b =>
                {
                    b.HasOne("Domain.Entities.Answer", "Answer")
                        .WithMany("AnswerMultiCheckboxs")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Domain.Entities.Research", "Research")
                        .WithMany("AnswerMultiCheckboxs")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Domain.Entities.AnswerMultiPercentage", b =>
                {
                    b.HasOne("Domain.Entities.Answer", "Answer")
                        .WithMany("AnswerMultiPercentages")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Domain.Entities.Research", "Research")
                        .WithMany("AnswerMultiPercentages")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Domain.Entities.AnswerNumber", b =>
                {
                    b.HasOne("Domain.Entities.Research", "Research")
                        .WithMany("AnswerNumbers")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Domain.Entities.AnswerRadio", b =>
                {
                    b.HasOne("Domain.Entities.Answer", "Answer")
                        .WithMany("AnswerRadios")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Domain.Entities.Research", "Research")
                        .WithMany("AnswerRadios")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.Navigation("AnswerCheckboxs");

                    b.Navigation("AnswerMultiAmounts");

                    b.Navigation("AnswerMultiCheckboxs");

                    b.Navigation("AnswerMultiPercentages");

                    b.Navigation("AnswerRadios");
                });

            modelBuilder.Entity("Domain.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Domain.Entities.Research", b =>
                {
                    b.Navigation("AnswerCheckboxs");

                    b.Navigation("AnswerMultiAmounts");

                    b.Navigation("AnswerMultiCheckboxs");

                    b.Navigation("AnswerMultiPercentages");

                    b.Navigation("AnswerNumbers");

                    b.Navigation("AnswerRadios");
                });
#pragma warning restore 612, 618
        }
    }
}
