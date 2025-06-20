using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

public class CharacterTitle
{
    [Key]
    public int CharacterTitleId { get; set; }

    public int CharacterId { get; set; }
    public int TitleId { get; set; }

    [ForeignKey("CharacterId")]
    public Character Character { get; set; }

    [ForeignKey("TitleId")]
    public Title Title { get; set; }

    public DateTime AcquiredAt { get; set; }
}