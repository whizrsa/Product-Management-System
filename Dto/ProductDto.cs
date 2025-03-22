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
        [Required(ErrorMessage = "Please upload an image file.")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
        public bool IsActive { get; set; }
    }
}
