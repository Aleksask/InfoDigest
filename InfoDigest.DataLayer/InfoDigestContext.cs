using System.Data.Entity;
using InfoDigest.DataLayer.Configurations;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer
{
    public class InfoDigestContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }

        public InfoDigestContext()
        {
        }

        public InfoDigestContext(string connectionStringName)
            : base(connectionStringName)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new QuestionCategoryConfiguration());
            modelBuilder.Configurations.Add(new AnswerOptionConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
        }
    }
}