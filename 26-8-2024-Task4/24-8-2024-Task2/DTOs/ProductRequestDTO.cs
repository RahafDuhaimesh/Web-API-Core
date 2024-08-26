namespace _24_8_2024_Task2.DTOs
{
    public class ProductRequestDTO
    {
        public int? CategoryId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public IFormFile? ProductImage { get; set; }

        public decimal? Price { get; set; }
    }
}
