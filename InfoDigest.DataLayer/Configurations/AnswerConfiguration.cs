using System.Data.Entity.ModelConfiguration;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Configurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.AnswerExplanation).HasMaxLength(1000).IsRequired();
            Property(x => x.AnswerUrl).IsOptional();

            HasMany(x => x.Options).WithRequired(x => x.Answer);
            //HasOptional(x => x.Options).WithMany();
        }
    }
}