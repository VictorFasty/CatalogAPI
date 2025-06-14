﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogoAPI.Model;



[Table("tb_Products")]
public class Product
{

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public Decimal Price { get; set; }
     
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }



    public float Stock { get; set; }


    public DateTime DateOfRegistry { get; set; }


    public int? CategoryId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Category? CategoryName { get; set; }
}
