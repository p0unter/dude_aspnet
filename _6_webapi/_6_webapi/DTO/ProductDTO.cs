namespace _6_webapi.DTO;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}