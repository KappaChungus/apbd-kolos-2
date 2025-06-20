
using kolos2.Data;
using kolos2.DTOS;
using kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace abdp12.Services;

public class DbService : IDbService
{
    DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    

    public async Task<CharacterDTO> GetCharacterAsync(int characterId)
    {
        var character = await _context.Character.Where(p=>p.CharacterId == characterId).FirstOrDefaultAsync();
        
        if (character == null)
            throw new Exception($"Character with id {characterId} not found");



        var res = new CharacterDTO
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = _context.Backpack.Where(b => b.CharacterID == character.CharacterId).Select(b => new ItemDTO
            {
                ItemName = b.Item.Name,
                Amount = b.Amount,
                ItemWeight = b.Item.Weight
            }).ToList(),
            Titles = _context.CharacterTitle.Where(t => t.CharacterId == character.CharacterId).Select(ct =>
                new TitleDTO
                {
                    Title = ct.Title.Name,
                    AcquiredAt = ct.AcquiredAt
                }).ToList()
        };
        return res;
    }
    
    public async Task<bool> AddItemsToBackpackAsync(int characterId, List<int> itemIds)
    {
        var character = await _context.Character.FirstOrDefaultAsync(c => c.CharacterId == characterId);
        if (character == null)
            throw new Exception($"Character with id {characterId} not found");

        var items = await _context.Item.Where(i => itemIds.Contains(i.ItemId)).ToListAsync();

        if (items.Count != itemIds.Count)
            throw new Exception("Some items do not exist");

        var totalWeightToAdd = items.Sum(i => i.Weight);

        if (character.CurrentWeight + totalWeightToAdd > character.MaxWeight)
            throw new Exception("Not enough carrying capacity");

        foreach (var item in items)
        {
            var backpackEntry = await _context.Backpack
                .FirstOrDefaultAsync(b => b.CharacterID == characterId && b.ItemID == item.ItemId);
            if (backpackEntry != null)
            {
                backpackEntry.Amount += 1;
            }
            else
            {
                _context.Backpack.Add(new Backpack
                {
                    CharacterID = characterId,
                    ItemID = item.ItemId,
                    Amount = 1
                });
            }
        }
        character.CurrentWeight += totalWeightToAdd;

        await _context.SaveChangesAsync();

        return true;
    }

}