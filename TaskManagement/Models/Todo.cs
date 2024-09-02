using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Titile { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
