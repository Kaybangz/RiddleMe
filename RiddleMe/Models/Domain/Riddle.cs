namespace RiddleMe.Models.Domain
{
    public class Riddle
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
