using System.Linq;
using HorseRace14.Models;
using HorseRace14.Shit;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace14.Controllers
{
    [Route("games/{gameId}/horses")]
    [ApiController]
    public class HorsesController : ControllerBase
    {
        private static int _horseIdGenerator = 1;

        [HttpPost]
        public IActionResult PostHorse(int gameId, [FromBody] Horse horse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);
            horse.HorseId = _horseIdGenerator++;
            game.Horses.Add(horse);
            StaticDictionnaryStorage.SaveData(gameId, game);

            return Ok(horse);
        }

        [HttpGet]
        public IActionResult GetHorses(int gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);

            return Ok(game.Horses);
        }


        [HttpDelete("{horseId}")]
        public IActionResult DeleteHorse(int gameId, int horseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);
            game.Horses.RemoveAll(h => h.HorseId == horseId);

            return NoContent();
        }

        [HttpPost("{horseId}/step")]
        public IActionResult DoHorseStep(int gameId, int horseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);
            var horse = game.Horses.First(h => h.HorseId == horseId);

            switch (horse.Name)
            {
                case "providerSearch":
                    RageService.CallProviderSearch();
                    break;
                case "fiveLastClaims":
                    RageService.CallFiveLastClaims();
                    break;
                case "leGrosRPG":
                    RageService.CallLeGrosRPG();
                    break;
                case "benefitSummary":
                    RageService.CallBenefitSummary();
                    break;

                default:
                    RageService.CallRandomMethod();
                    break;
            }

            return Ok();
        }

        [HttpPut("{horseId}/position")]
        public IActionResult UpdatePosition(int gameId, int horseId, [FromBody] Position position)
        {

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);
            var horse = game.Horses.First(h => h.HorseId == horseId);
            horse.Position = position;
            StaticDictionnaryStorage.SaveData(gameId, game);

            return Ok();
        }
    }
}