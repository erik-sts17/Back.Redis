using Back.Redis.Business.Models.V1.Pokemon;
using Back.Redis.Business.Services.V1.Pokemon;
using Microsoft.AspNetCore.Mvc;

namespace Back.Redis.Api.Controllers.V1.Pokemon
{
    [Route("api/[controller]")]
    public class PokemonController(IPokemonService pokemonService) : ControllerBase
    {
        private readonly IPokemonService _pokemonService = pokemonService;

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(PokemonResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _pokemonService.GetByName(name);
            return Ok(result);
        }
    }
}
