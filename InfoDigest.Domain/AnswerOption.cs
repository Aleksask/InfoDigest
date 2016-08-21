using System.ComponentModel.DataAnnotations;

namespace InfoDigest.Domain
{
    public class AnswerOption
    {
        [Key]
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public string AnswerUrl { get; set; }
        public string AnswerExplanation { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}