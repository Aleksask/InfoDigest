using System;
using System.Collections.Generic;

namespace InfoDigest.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public byte[] Image { get; set; }
        //public int QuestionUserId { get; set; }
        public int CategoryId { get; set; }


        public virtual QuestionCategory Category { get; set; }
        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}