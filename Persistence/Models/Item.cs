using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models;
public class Item
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public Image Image { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
