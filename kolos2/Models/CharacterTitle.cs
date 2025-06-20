using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

public class CharacterTitle
{
    [Key]
    public int CharacterTitleId { get; set; }
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    [ForeignKey(nameof(Character))]
    public Character Character { get; set; }
    [ForeignKey(nameof(Title))]
    public Title Title { get; set; }
    public DateTime AcquiredAt { get; set; }
    
}