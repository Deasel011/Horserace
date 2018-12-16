using System;
using System.Linq;
using System.Threading;
using HorseRace14.Models;
using HorseRace14.Shit;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace14.Controllers
{
    [Route("games/{gameId}/horses")]
    [ApiController]
    public class HorsesController : ControllerBase
    {
        [HttpGet("tsuaWA")]
        public IActionResult GetWA(int gameId)
        {
            CallLeGrosRPG();
            return Ok();
        }


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
                    CallProviderSearch();
                    break;
                case "fiveLastClaims":
                    CallFiveLastClaims();
                    break;
                case "leGrosRPG":
                    CallLeGrosRPG();
                    break;

                default:
                    CallRandomMethod();
                    break;
            }

            return Ok();
        }

        private void CallRandomMethod()
        {
            var random = new Random();
            var waitTime = random.Next(1, 100);

            Thread.Sleep(waitTime);
        }

        private void CallLeGrosRPG()
        {
            var headers = ApiClient.CreateParameterCollection("CSP-Session-Pref", "WESessionHttpRedirection=silo4");

            var apiClient = new ApiClient("http://wa.fnct.webui.ia.iafg.net/webadmin", headers);
            var queryParameters = ApiClient.CreateParameterCollection("contractId", "0000023551-0000000065-00102");

            var response = apiClient.Get<dynamic>("v2/api/member", null, queryParameters);
            return;
        }

        private void CallFiveLastClaims()
        {
            throw new System.NotImplementedException();
        }

        private void CallProviderSearch()
        {
            
        }
    }
}