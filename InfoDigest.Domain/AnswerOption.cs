namespace InfoDigest.Domain
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}