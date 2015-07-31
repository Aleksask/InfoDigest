using System.Data.Entity.ModelConfiguration;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Configurations
{
    public class QuestionCategoryConfiguration : EntityTypeConfiguration<QuestionCategory>
    {
        public QuestionCategoryConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.CategoryName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(300);
        }
    }
}