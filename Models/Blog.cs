using System.ComponentModel.DataAnnotations;

namespace web_satky.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Display(Name = "Titulek")]
        [Required(ErrorMessage = "Vyplňte prosím")]
        [StringLength(50, ErrorMessage = "Titulek je příliš dlouhý")]
        public string Title { get; set; }
        [Display(Name = "Text")]
        [Required(ErrorMessage = "Vyplňte prosím")]
        [StringLength(4000, ErrorMessage = "Text je příliš dlouhý")]
        public string Description { get; set; }

    }
}
