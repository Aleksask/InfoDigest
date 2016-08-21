using System.ComponentModel.DataAnnotations;

namespace InfoDigest.Domain
{
    public class QuestionCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}