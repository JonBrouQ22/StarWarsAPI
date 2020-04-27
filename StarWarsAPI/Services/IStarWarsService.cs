using StarWarsAPI.Models;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public interface IStarWarsService
    {
        Task<Character[]> GetCharactersByFilm(string objectId);
        Task<Film[]> GetFilms();
    }
}
