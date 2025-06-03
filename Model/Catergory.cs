using System.Collections.ObjectModel;

namespace CatalogoAPI.Model;

public class Catergory
{
    public Catergory() { 
        products = new Collection<Product>();   
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }



    public ICollection<Product>? products { get; set; }
}
