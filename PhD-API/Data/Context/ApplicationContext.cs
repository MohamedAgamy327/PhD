using Data.SeedData;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Seed();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; } 
        public DbSet<Research> Researchs { get; set; }   
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerRadio> AnswerRadios { get; set; }
        public DbSet<AnswerNumber> AnswerNumbers { get; set; }
        public DbSet<AnswerCheckbox> AnswerCheckboxs { get; set; }
        public DbSet<AnswerMultiAmount> AnswerMultiAmounts { get; set; }
    }
}
