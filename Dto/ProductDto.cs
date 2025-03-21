using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.Dto
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [MaxLength(150)]
        public string ImageFile { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
