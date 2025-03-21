using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Product_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        [Precision(16,2)]
        public decimal Price { get; set; }
        [MaxLength(150)]
        public string ImageFileName { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }

    }
}
