using System.ComponentModel.DataAnnotations;

namespace Northwind.Web.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
         [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}