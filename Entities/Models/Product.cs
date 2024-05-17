using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is required.")]
        public string? ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        public String? Summary { get; set; } = String.Empty;

        public String? ImageUrl {  get; set; }

        public int? CategoryId { get; set; } //Foreign Key
        public Category? Category { get; set; }  //Navigation property

        public bool ShowCase { get; set; }
    }
}
