using System.ComponentModel.DataAnnotations;

namespace RiddleMe.Models
{
    public class AddRiddleVM
    {
        [Required(ErrorMessage = "Field is required"), StringLength(200, ErrorMessage = "Input limit exceeded")]
        public string Question { get; set; } = null!;

        [Required(ErrorMessage = "Field is required"), StringLength(600, ErrorMessage = "Input limit exceeded")]
        public string Answer { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
