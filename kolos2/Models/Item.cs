using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Item
{
    public int ItemId{get;set;}
    [MaxLength(100)]
    public string Name{get;set;}

    public int Weight { get; set; }
    public virtual ICollection<Backpack> Backpack { get; set; } = new List<Backpack>();

}