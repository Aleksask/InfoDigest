using System;

namespace InfoDigest.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public byte[] Image { get; set; }

        public int AnswerId { get; set; }
        public int CategoryId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual QuestionCategory Category { get; set; }
    }
}