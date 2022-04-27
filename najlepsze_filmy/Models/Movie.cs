using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable


namespace najlepsze_filmy.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tytuł")]
        [StringLength(100)]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string Title { get; set; }

        [Display(Name = "Reżyseria")]
        [StringLength(100)]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string Director { get; set; }

        [Display(Name = "Rok produkcji")]       
        [StringLength(4)]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Wymagane 4 liczby np. 1234")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string RelaseDate { get; set; }

        [Display(Name = "Krótki opis filmu")]
        [StringLength(400)]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string Opinion { get; set; }

        [Display(Name = "Link do zdjęcia")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string Photo { get; set; }

        [Display(Name = "Link do zwiastunu")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        public string Video { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "{0} jest wymagana.")]
        public int GenreId { get; set; }

        [NotMapped]
        public List<Comment> CommentsMovie { get; set; } = new List<Comment>();






        public Genre Genre { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
