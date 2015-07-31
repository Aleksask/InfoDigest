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
            HasRequired(t => t.Answer);

            Property(t => t.AnswerId)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_AnswerOption") {IsUnique = true, Order = 1}));

            Property(t => t.IsCorrect)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_AnswerOption") {IsUnique = true, Order = 2}));
        }
    }
}