﻿using System.Collections.Generic;
using HorseRace14.Models;
using HorseRace14.Shit;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace14.Controllers
{
    [Route("games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostGame()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameId = StaticDictionnaryStorage.CreateDataStorage();
            var game = new Game
            {
                GameId = gameId,
                Horses = new List<Horse>()
            };
            StaticDictionnaryStorage.SaveData(gameId, game);

            return Ok(game);
        }

        [HttpGet("{gameId}")]
        public IActionResult GetGame(int gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = StaticDictionnaryStorage.GetData<Game>(gameId);

            return Ok(game);
        }
    }
}