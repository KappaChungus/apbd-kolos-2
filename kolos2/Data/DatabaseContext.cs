using kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Data;

public class DatabaseContext: DbContext
{
    
    public DbSet<Item> Item { get; set; }
    public DbSet<Backpack> Backpack{ get; set; }
    public DbSet<Character> Character { get; set; }
    public DbSet<CharacterTitle> CharacterTitle { get; set; }
    public DbSet<Title> Title { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item { ItemId = 1, Name = "xd", Weight = 1}
        });
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title { TitleId = 1, Name = "tytul" },
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                CharacterId = 1, FirstName = "Jan",LastName = "Kowalski",
                CurrentWeight = 1, MaxWeight = 2
            }
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack{IdBackpack = 1, ItemID = 1, CharacterID = 1, Amount =1 }
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle { CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Now }
        });
        
    }


}