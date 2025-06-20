
using kolos2.Data;
using kolos2.DTOS;
using Microsoft.EntityFrameworkCore;

namespace abdp12.Services;

public class DbService : IDbService
{
    DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    // public async Task<PagedResultDTO<TripDTO>> GetTrips(int page, int pageSize)
    // {
    //     var totalTrips = await _context.Trips.CountAsync();
    //     var allPages = (int)Math.Ceiling(totalTrips / (double)pageSize);
    //
    //     var trips = await _context.Trips
    //         .OrderByDescending(t => t.DateFrom)
    //         .Skip((page - 1) * pageSize)
    //         .Take(pageSize)
    //         .Select(t => new TripDTO
    //         {
    //             Name = t.Name,
    //             Description = t.Description,
    //             DateFrom = t.DateFrom,
    //             DateTo = t.DateTo,
    //             MaxPeople = t.MaxPeople,
    //             Countries = t.IdCountries.Select(c => new CountryDTO 
    //             { 
    //                 Name = c.Name 
    //             }).ToList(),
    //             Clients = t.ClientTrips.Select(ct => new ClientDTO 
    //             { 
    //                 FirstName = ct.IdClientNavigation.FirstName, 
    //                 LastName = ct.IdClientNavigation.LastName
    //             }).ToList()
    //         })
    //         .ToListAsync();
    //
    //     return new PagedResultDTO<TripDTO>
    //     {
    //         PageNum = page,
    //         PageSize = pageSize,
    //         AllPages = allPages,
    //         Trips = trips
    //     };
    //
    // }
    //
    // public async Task<(int Code, string Message)> DeleteClient(int clientId)
    // {
    //     bool clientHasTrip = await _context.ClientTrips
    //         .AnyAsync(ct => ct.IdClient == clientId);
    //
    //     if (clientHasTrip)
    //         return (400, "Client has trip reservation");
    //
    //     int res = await _context.Clients
    //         .Where(c => c.IdClient == clientId)
    //         .ExecuteDeleteAsync();
    //
    //     if (res == 0)
    //         return (404, "No such user");
    //
    //     return (200, "Client deleted successfully");
    // }
    //
    // public async Task<(int Code, string Message)> AttachClientToTrip(int tripId, AttachClientToTripDTO attachClientToTripDTO)
    // {
    //     await using var transaction = await _context.Database.BeginTransactionAsync();
    //
    //     try
    //     {
    //         var clientAlreadyExists = await _context.Clients
    //             .AnyAsync(c => c.Pesel == attachClientToTripDTO.Pesel);
    //
    //         if (clientAlreadyExists)
    //             return (400, "Client already exists");
    //
    //         var clientAlreadyExistsInTrip = await _context.ClientTrips
    //             .AnyAsync(ct => ct.IdClientNavigation.Pesel == attachClientToTripDTO.Pesel);
    //
    //         if (clientAlreadyExistsInTrip)
    //             return (400, "Client already exists in a trip");
    //
    //         var trip = await _context.Trips
    //             .FirstOrDefaultAsync(t => t.IdTrip == tripId);
    //
    //         if (trip == null)
    //             return (404, "Trip not found");
    //
    //         if (trip.DateFrom < DateTime.Now)
    //             return (400, "Trip already started");
    //
    //         var newClient = new Client
    //         {
    //             FirstName = attachClientToTripDTO.FirstName,
    //             LastName = attachClientToTripDTO.LastName,
    //             Email = attachClientToTripDTO.Email,
    //             Pesel = attachClientToTripDTO.Pesel,
    //             Telephone = attachClientToTripDTO.Telephone
    //         };
    //
    //         await _context.Clients.AddAsync(newClient);
    //         await _context.SaveChangesAsync();
    //
    //         var newClientTrip = new ClientTrip
    //         {
    //             IdClient = newClient.IdClient,
    //             IdTrip = tripId,
    //             RegisteredAt = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
    //             PaymentDate = int.Parse(attachClientToTripDTO.PaymentDate.ToString("yyyyMMdd"))
    //         };
    //
    //         await _context.ClientTrips.AddAsync(newClientTrip);
    //         await _context.SaveChangesAsync();
    //         await transaction.CommitAsync();
    //         return (200, "Client successfully attached to trip");
    //     }catch (Exception ex)
    //     {
    //         await transaction.RollbackAsync();
    //         return (500, $"Internal error: {ex.Message}");
    //     }
    // }

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
}