using Newtonsoft.Json;
using StarWarsAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public class StarWarsService : IStarWarsService
    {
        public async Task<Character[]> GetCharactersByFilm(string objectId)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://parseapi.back4app.com/classes/Character?count=1&includeAll=true&where=%7B%22%24relatedTo%22%3A%7B%22object%22%3A%7B%22__type%22%3A%22Pointer%22%2C%22className%22%3A%22Film%22%2C%22objectId%22%3A%22{objectId}%22%7D%2C%22key%22%3A%22characters%22%7D%7D");
                client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "kFuqGsemy2j84m8AfykdWikN2WdHEs45uGIFDV7F");
                client.DefaultRequestHeaders.Add("X-Parse-Master-Key", "mbUJqmLAMaVoASAkhmnOWf6am5qhmFXL5hcw0Ecf");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                var results = JsonConvert.DeserializeObject<CharacterResult>(json);
                return results.Results;
            }
        }

        public async Task<Film[]> GetFilms()
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://parseapi.back4app.com/classes/Film?where=%7B%22episodeId%22%3A%7B%22%24in%22%3A%5B2%2C4%2C6%5D%7D%7D&keys=objectId,episodeId,title&order=episodeId");
                client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "kFuqGsemy2j84m8AfykdWikN2WdHEs45uGIFDV7F");
                client.DefaultRequestHeaders.Add("X-Parse-Master-Key", "mbUJqmLAMaVoASAkhmnOWf6am5qhmFXL5hcw0Ecf");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                var results = JsonConvert.DeserializeObject<FilmResult>(json);
                return results.Results;
            }
        }

        private class CharacterResult
        {
            public Character[] Results { get; set; }
        }
        private class FilmResult
        {
            public Film[] Results { get; set; }
        }
    }
}
