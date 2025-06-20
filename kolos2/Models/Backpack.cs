using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

public class Backpack
{
    [Key]
    public int IdBackpack { get; set; }

    public int CharacterID { get; set; }
    public int ItemID { get; set; }
    [ForeignKey("ItemID")]
    public Item Item { get; set; }

    [ForeignKey("CharacterID")]
    public Character Character { get; set; }

    public int Amount { get; set; }
}