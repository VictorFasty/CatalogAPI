using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoAPI.Model;


[Table("tb_category")]
public class Category
{
    public Category() { 
        products = new Collection<Product>();   
    }
    [Key]
    public int Id { get; set; }


    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }



    public ICollection<Product>? products { get; set; }
}
