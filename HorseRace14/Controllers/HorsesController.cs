using System.Collections.Generic;
using System.Linq;
using HorseRace14.Models;
using HorseRace14.Shit;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace14.Controllers
{
    /// <summary>
    /// Horses apis
    /// </summary>
    [Route("games/{gameId}/horses")]
    [ApiController]
    public class HorsesController : ControllerBase
    {
        private static int _horseIdGenerator = 1;

        /// <summary>
        /// Add a horse to the game
        /// </summary>
        /// <param name="gameId">The unique id for a specific game</param>
        /// <param name="horse">The horse to add to the game</param>
        [HttpPost]
        [ProducesResponseType(200)]
        [Produces(typeof(Horse))]
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

        /// <summary>
        /// Get all the horses of the game
        /// </summary>
        /// <param name="gameId">The unique id for a specific game</param>
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces(typeof(List<Horse>))]
        public IActionResult GetHorses(int gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);

            return Ok(game.Horses);
        }


        /// <summary>
        /// Remove a horse from the game
        /// </summary>
        /// <param name="gameId">The unique id for a specific game</param>
        /// <param name="horseId">The unique id for a specific horse</param>
        [HttpDelete("{horseId}")]
        [ProducesResponseType(204)]
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


        /// <summary>
        /// Does a horse step
        /// </summary>
        /// <param name="gameId">The unique id for a specific game</param>
        /// <param name="horseId">The unique id for a specific horse</param>
        [HttpPost("{horseId}/step")]
        [ProducesResponseType(200)]
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


        /// <summary>
        /// Update a horse's position
        /// </summary>
        /// <param name="gameId">The unique id for a specific game</param>
        /// <param name="horseId">The unique id for a specific horse</param>
        /// <param name="position">The new position of the horse</param>
        [HttpPut("{horseId}/position")]
        [ProducesResponseType(200)]
        public IActionResult UpdatePosition(int gameId, int horseId, [FromBody] Position position)
        {

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);
            var horse = game.Horses.First(h => h.HorseId == horseId);

            if (horse.StartTimeInMillis == 0)
            {
                horse.StartTimeInMillis = position.TimeInMillis;
            }

            if (position.Finished)
            {
                horse.EndTimeInMillis = position.TimeInMillis;
                horse.TotalTimeInMillis = (horse.EndTimeInMillis - horse.StartTimeInMillis);
            }


            horse.Position = position;
            StaticDictionnaryStorage.SaveData(gameId, game);

            return Ok();
        }
    }
}