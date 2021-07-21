using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Utilities.StaticHelpers;

namespace Data.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SecurePassword.CreatePasswordHash("123123", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        Name = "Admin",
                        Email = "Admin@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        IsRandomPassword = true,
                        Role = RoleEnum.Admin
                    }
                );

            modelBuilder.Entity<Question>().HasData(

                  new Question
                  {
                      Id = 1,
                      Content = "3- نوع النشاط البحثى:",
                      Type=QuestionTypeNum.RadioButton
                  },
                  new Question
                  {
                      Id = 2,
                      Content = "7- مستوى التطبيق البحثى",
                      Type = QuestionTypeNum.RadioButton
                  }
        );

            modelBuilder.Entity<Answer>().HasData(

           new Answer
           {
               Id = 1,
               QuestionId = 1,
               Content = "بحث أساسي"
           },
            new Answer
            {
           Id = 2,
           QuestionId = 1,
           Content = "بحث تطبيقي"
            },
              new Answer
              {
                  Id = 3,
                  QuestionId = 1,
                  Content = "تطوير تجريبي "
              }
              ,
                    new Answer
                    {
                        Id = 4,
                        QuestionId = 2,
                        Content = " مستوى الشركة (أو المؤسسة الانتاجية ))"
                    },
            new Answer
            {
                Id = 5,
                QuestionId = 2,
                Content = "مستوى الصناعة  (أو القطاع الانتاجى )"
            },
              new Answer
              {
                  Id = 6,
                  QuestionId = 2,
                  Content = "مستوى الاقتصاد الوطنى "
              }
              ,
              new Answer
              {
                  Id = 7,
                  QuestionId = 2,
                  Content = "مستوى اقليمى أو دولى  (المشروعات المشتركة ) "
              }
 );



        }
    }
}
