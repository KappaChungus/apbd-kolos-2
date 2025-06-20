using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Title
{
    [Key]
    public int TitleId { get; set; }
    public string Name { get; set; }
    public ICollection<CharacterTitle> CharacterTitle { get; set; }
}