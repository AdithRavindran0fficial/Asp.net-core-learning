using System.ComponentModel.DataAnnotations;

namespace Task_day_4.Models
{
    public class Items
    {
        [Range(1,100)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }


        [Required]
        [StringLength(10,MinimumLength =3)]
        public string Titile { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Description { get; set; }

    }
}
