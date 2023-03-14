namespace RiddleMe.Models
{
    public class UpdateRiddleVM
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
