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
                case "benefitSummary":
                    CallBenefitSummary();
                    break;

                default:
                    CallRandomMethod();
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
            var apiClient = new ApiClient("http://hc.fnct.webservice.ia.iafg.net:50080/HCMWPN30");
            var urlSegments = ApiClient.CreateParameterCollection("contractId", "0000023551-0000000065-00102");

            var queryParameters = new ApiClientParameterCollection();
            queryParameters.Add("fromDate", "2018-12-16");
            queryParameters.Add("start_index", "2");
            queryParameters.Add("number_to_fetch", "5");
            queryParameters.Add("include_details", "true");

            var response = apiClient.Get<dynamic>("v2/membercontracts/{contractId}/claims/search", urlSegments, queryParameters);
            return;
        }

        private void CallProviderSearch()
        {
            var apiClient = new ApiClient("http://hc.fnct.webservice.ia.iafg.net:50080/HCMWPN37");

            var queryParameters = new ApiClientParameterCollection();
            queryParameters.Add("name", "tremblay");
            queryParameters.Add("specialty_id", "12");
            queryParameters.Add("province_code", "QC");

            var response = apiClient.Get<dynamic>("v1/providers", null, queryParameters);
            return;
        }


        private void CallBenefitSummary()
        {
            var headers = ApiClient.CreateParameterCollection("CSP-Session-Pref", "WESessionHttpRedirection=silo4");

            var apiClient = new ApiClient("http://wa.fnct.webui.ia.iafg.net/webadmin", headers);

            var response = apiClient.Get<dynamic>("v2/api/benefitSummary?contractId=0000028905-0000001933-00001&userId=LIDCOR");
            return;
        }
    }
}