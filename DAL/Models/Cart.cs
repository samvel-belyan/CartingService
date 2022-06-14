using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

internal class Cart
{
    [Required]
    public string Id { get; set; }
    public IList<Item> Items { get; set; } = new List<Item>();
}
