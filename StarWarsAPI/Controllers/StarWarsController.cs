using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsAPI.Helpers;
using StarWarsAPI.Models;
using StarWarsAPI.Services;

namespace StarWarsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        private readonly ILogger<StarWarsController> _logger;
        private readonly IStarWarsService _starWarsService;
        public StarWarsController(ILogger<StarWarsController> logger, IStarWarsService starWarsService)
        {
            _logger = logger;
            _starWarsService = starWarsService;
        }

        [HttpGet]
        public async Task<FileContentResult> Get()
        {
            // get the film list
            var filmList = await _starWarsService.GetFilms();
            // get the characters for these films
            Character[] characterArray = new Character[0];
            foreach (Film film in filmList)
            {
                var result = await _starWarsService.GetCharactersByFilm(film.ObjectId);
                // combine and sort characters, no duplicates
                foreach (var character in result)
                {
                    character.EpisodeId = film.EpisodeId;
                }
                characterArray = characterArray.Union(result).ToArray();
            }
            Array.Sort(characterArray, new StarWarsComparer());
            // convert names into last name, first name format
            foreach (var character in characterArray)
            {
                var names = character.Name.Split(" ");
                if (names.Length > 1)
                {
                    character.Name = $"{names[1]}-{names[0]}";
                }
            }
            // convert into csv file and return it.
            var characterList = new List<Character>(characterArray);
            var formatter = new CsvFormatter();
            var csv = formatter.Format(characterList);
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(csv);
            // return csv file
            return File(fileBytes, "text/csv", "StarWarsCharacters.csv");
        }
    }
}