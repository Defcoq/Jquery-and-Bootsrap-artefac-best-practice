using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Web.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext"), DataType(DataType.MultilineText)]
        public string Description { get; set; } 
    }
}