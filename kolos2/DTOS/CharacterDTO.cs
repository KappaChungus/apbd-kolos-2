namespace kolos2.DTOS;

public class CharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CurrentWeight{ get; set; }

    public int MaxWeight { get; set; }
    
    public  List<ItemDTO> BackpackItems { get; set; }
    public  List<TitleDTO> Titles { get; set; }
}