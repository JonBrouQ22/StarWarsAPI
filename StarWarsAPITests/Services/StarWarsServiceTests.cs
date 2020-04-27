using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StarWarsAPI.Services.Tests
{
    [TestClass]
    public class StarWarsServiceTests
    {
        [TestMethod("GetCharactersByFilm")]
        public async void GetCharactersByFilmTest()
        {
            // Arrange
            // Episode 4 object id
            var filmObjectId = "GteveE4ytb";
            var starWarsService = new StarWarsService();

            // Act
            var result = await starWarsService.GetCharactersByFilm(filmObjectId);
            // Assert
            // we are getting data
            Assert.IsTrue(result.Length > 0, "Retreived data successfully");
            // Ackbar isn't in this film so his name should not be in the list
            Assert.IsFalse(Array.Exists(result, x => x.Name.Equals("Ackbar")), "Not getting data from other movies");
        }

        [TestMethod("GetFilms")]
        public async void GetFilmsTest()
        {
            // Arrange
            var starWarsService = new StarWarsService();
            // Act
            var result = await starWarsService.GetFilms();
            // Assert
            Assert.IsTrue(result.Length > 0, "Retreived data successfully");
            Assert.IsFalse(Array.Exists(result, x => x.EpisodeId == 1 || x.EpisodeId == 3 || x.EpisodeId == 5), "Only even number films retreived");
        }
    }
}