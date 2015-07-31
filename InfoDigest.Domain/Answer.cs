using System.Collections;
using System.Collections.Generic;

namespace InfoDigest.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerUrl { get; set; }
        public ICollection<AnswerOption> Options { get; set; }
        public string AnswerExplanation { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}