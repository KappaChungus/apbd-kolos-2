using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Character
{
    [Key]
    public int CharacterId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpack { get; set; }
    public ICollection<CharacterTitle> CharacterTitle { get; set; }
    
    

}