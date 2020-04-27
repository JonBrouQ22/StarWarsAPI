using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsAPI.Models
{
    public class Film
    {
        public string ObjectId { get; set; }
        public string ReleaseDate { get; set; }
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string OpeningCrawl { get; set; }
        public string Producer { get; set; }
    }
}
