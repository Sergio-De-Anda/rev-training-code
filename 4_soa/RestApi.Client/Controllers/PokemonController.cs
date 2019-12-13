using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Data.Models;

namespace RestApi.Client.Controllers
{
  [Produces("application/json")]
  // [Consumes("application/xml")]
  [Route("/api/[controller]")]
  [ApiController]
  public class PokemonController : ControllerBase
  {
    private readonly PokemonDbContext _db;
    public PokemonController(PokemonDbContext dbContext)
    {
      _db = dbContext;
    }
    // private static readonly PokemonDbContext _db = new PokemonDbContext();
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return await Task.Run(() => { return Ok(_db.Pokemon.ToList());});
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return await Task.FromResult(Ok(_db.Pokemon.FirstOrDefault(p => p.Id == id)));
    }
    [HttpPost]
    public async Task<IActionResult> Post(Pokemon poke)
    {
      if(ModelState.IsValid)
      {
        _db.Pokemon.Add(poke);
        await _db.SaveChangesAsync();
        return await Task.FromResult(Ok(poke));
      }
      return await Task.FromResult(NotFound(poke));
    }
  }
}