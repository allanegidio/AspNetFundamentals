using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Category { get; set; }
    }
}