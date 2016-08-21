using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Configurations
{
    public class AnswerOptionConfiguration : EntityTypeConfiguration<AnswerOption>
    {
        public AnswerOptionConfiguration()
        {
            HasKey(x => x.Id);
            HasRequired(t => t.Question);

            Property(t => t.QuestionId)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_AnswerOption") { IsUnique = false, Order = 1 }));
        }
    }
}