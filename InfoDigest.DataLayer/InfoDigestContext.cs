using System.Data.Entity;
using InfoDigest.DataLayer.Configurations;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer
{
    public class InfoDigestContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public InfoDigestContext() : base("InfoDigest")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new QuestionCategoryConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new AnswerOptionConfiguration());
        }
    }
}