using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace najlepsze_filmy.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        [StringLength(30)]
        [Required(ErrorMessage = "Pole {0} jest wymagana.")]
        public string Name { get; set; }

        [Display(Name = "Komentarz")]
        [StringLength(200)]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string Description { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
