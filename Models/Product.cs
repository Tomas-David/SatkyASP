using System.ComponentModel.DataAnnotations;

namespace web_satky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public string Image { get; set; }
        
        public string Genders { get; set; }
        
        public bool Washing { get; set; }
        
        public bool Ironing { get; set; }
        
        public bool Dryer { get; set; }


    }
}
