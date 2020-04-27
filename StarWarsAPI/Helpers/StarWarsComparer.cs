using StarWarsAPI.Models;
using System.Collections.Generic;

namespace StarWarsAPI.Helpers
{
    public class StarWarsComparer : Comparer<Character>
    {
        public override int Compare(Character x, Character y)
        {
            var xBirthYear = x.BirthYear != null ? float.Parse(x.BirthYear.Replace("BBY", "")) : 0;
            var yBirthYear = y.BirthYear != null ? float.Parse(y.BirthYear.Replace("BBY", "")) : 0;
            var xHomeworld = string.IsNullOrEmpty(x.Homeworld.Name) ? "" : x.Homeworld.Name;
            var yHomeworld = string.IsNullOrEmpty(y.Homeworld.Name) ? "" : y.Homeworld.Name;
            // compare film episode number
            if (x.EpisodeId.CompareTo(y.EpisodeId) != 0)
            {
                return x.EpisodeId.CompareTo(y.EpisodeId);
            }
            // then compare planet name
            else if (xHomeworld.CompareTo(yHomeworld) != 0)
            {
                return xHomeworld.CompareTo(yHomeworld);
            }
            // then compare age (birthYear)
            else if (xBirthYear.CompareTo(yBirthYear) != 0)
            {
                return xBirthYear.CompareTo(yBirthYear);
            }
            // then compare name
            else if (x.Name.CompareTo(y.Name) != 0)
            {
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                return 0;
            }
        }
    }
}
