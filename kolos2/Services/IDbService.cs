

using kolos2.DTOS;

namespace abdp12.Services;

public interface IDbService
{
    Task<CharacterDTO> GetCharacterAsync(int characterId);
    public Task<bool> AddItemsToBackpackAsync(int characterId, List<int> itemIds);

}