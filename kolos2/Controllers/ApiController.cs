using abdp12.Services;
using kolos2.DTOS;
using kolos2.Models;
using Microsoft.AspNetCore.Mvc;

namespace kolos2.Controllers;
[Route("[Controller]")]
[ApiController]
public class ApiController :ControllerBase
{
    private readonly IDbService _dbService;
    public ApiController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("characters/{id}")]
    public async Task<ActionResult> GetCharacters([FromRoute] int id)
    {
        return Ok(await _dbService.GetCharacterAsync(id));
    }
    
    [HttpPost("characters/{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack([FromRoute] int characterId, [FromBody] AddItemsDTO data)
    {
        if (data?.ItemIds == null || !data.ItemIds.Any())
            return BadRequest("No items provided");

        try
        {
            await _dbService.AddItemsToBackpackAsync(characterId, data.ItemIds);
            return Ok("Items added successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}