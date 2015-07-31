using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasKey(x => x.Id);
            HasRequired(x => x.Category);
            HasRequired(x => x.Answer).WithRequiredPrincipal(z => z.Question);

            Property(x => x.Image)
                .IsOptional()
                .IsVariableLength(); //this is variable by length anyways
            
            Property(x => x.QuestionText)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}