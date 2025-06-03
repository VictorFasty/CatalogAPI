namespace CatalogoAPI.Model;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public float Stock { get; set; }

    public DateTime DateOfRegistry { get; set; }


    public int? CategoryId { get; set; }
    
    public Catergory? CategoryName { get; set; }
}
