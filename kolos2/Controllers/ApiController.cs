using abdp12.Services;
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
    
}