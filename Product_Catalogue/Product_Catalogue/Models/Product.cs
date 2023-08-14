using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Product_Catalogue.Models
{
    public enum Category
    {
        BISCUITS,TOAST,KHARI
    }
      
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="name is empty")]
        public string Name { get; set; }

        [Required(ErrorMessage ="field is empty ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "field is empty ")]
        [EnumDataType(typeof(Category))]
        public Category category { get; set; }

        [DataType(DataType.Date)]
        public DateTime mfgDate { get; set; }

    }
}
