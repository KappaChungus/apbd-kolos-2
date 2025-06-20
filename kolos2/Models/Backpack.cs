using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

public class Backpack
{
    [Key]
    public int IdBackpack { get; set; }
    public int CharacterID { get; set; }
    public int ItemID { get; set; }
    
    [ForeignKey(nameof(Item))]
    public Item Item { get; set; }
    
    [ForeignKey(nameof(Character))]
    public Character Character { get; set; }
    
    public int Amount { get; set; }
    
}