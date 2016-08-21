using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoDigest.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public byte[] Image { get; set; }
        //public int QuestionUserId { get; set; }
        public int CategoryId { get; set; }

        public bool Deprecated { get; set; }

        public virtual QuestionCategory Category { get; set; }
        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}