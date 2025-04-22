using System.ComponentModel.DataAnnotations;

namespace MVC_Demo2.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public double Number { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
