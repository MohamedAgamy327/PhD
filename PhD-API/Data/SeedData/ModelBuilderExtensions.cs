using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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

            modelBuilder.Entity<Question>().HasData(SeedQuestionData());
          //  modelBuilder.Entity<Answer>().HasData(SeedAnswerData());
        }

        public static List<Question> SeedQuestionData()
        {
            var questions = new List<Question>();
            using (StreamReader r = new StreamReader(@"Content/questions.json"))
            {
                string json = r.ReadToEnd();
                questions = JsonConvert.DeserializeObject<List<Question>>(json);
            }
            return questions;
        }
        public static List<Answer> SeedAnswerData()
        {
            var answers = new List<Answer>();
            using (StreamReader r = new StreamReader(@"Content/answers.json"))
            {
                string json = r.ReadToEnd();
                answers = JsonConvert.DeserializeObject<List<Answer>>(json);
            }
            return answers;
        }
    }
}
