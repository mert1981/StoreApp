using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto 
    {
        //set gördüğümüz yerlere init yazarak nesne oluşturulduktan sonra değişmeyecek
        public int Id { get; init; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string? ProductName { get; init; } = string.Empty;
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; init; }
        public String? Summary { get; init; } = String.Empty;

        public String? ImageUrl { get; set; } //dosya yüklendikten sonra yolu belli olacağı için set olarak kalıyor 

        public int? CategoryId { get; init; } 

    }
}
