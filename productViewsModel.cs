using System.ComponentModel.DataAnnotations;

namespace web_satky
{
    public class productViewsModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Název")]
        [StringLength(50, ErrorMessage = "Název je příliš dlouhý")]
        public string Name { get; set; }
        [Display(Name = "Popis")]
        [StringLength(4000, ErrorMessage = "Popis je příliš dlouhý")]
        public string Description { get; set; }
        [Display(Name = "Varianty")]
        public string Genders { get; set; }
        [Display(Name = "Cena")]
        public double Price { get; set; }
        [Display(Name = "Obrázek")]
        public IFormFile? ProductPhoto { get; set; }
        [Display(Name = "Praní")]
        public bool Washing { get; set; }
        [Display(Name = "Žehlení")]
        public bool Ironing { get; set; }
        [Display(Name = "Sušička")]
        public bool Dryer { get; set; }
        
    }
}
