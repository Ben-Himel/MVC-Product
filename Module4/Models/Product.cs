using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Module4.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "ID Number")]
        [Required(ErrorMessage ="Field cannot be empty")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; } //a

        [Display(Name = "Product Name")]
        public string? Name { get; set; } //b

        [Display(Name ="Discription")]
        public string? Description { get; set; } //c
                                                 
        [Display(Name ="Sale Price")]
        [DataType(DataType.Currency)]
        public double ProductPrice { get; set; } //d

        public string? ProductImageName { get; set; } //e        
        
    }
}
