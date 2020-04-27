using StarWarsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Helpers
{
    public class CsvFormatter
    {
		public string Format(IEnumerable<Character> characters)
		{
			var sb = new StringBuilder();
			sb.AppendLine("ObjectId,Name,Gender,SkinColor,HairColor,Height,EyeColor,Mass,Homeworld,BirthYear,EpisodeId");

			foreach (var character in characters)
			{
				sb.Append(character.ObjectId + ",");
				sb.Append(character.Name + ",");
				sb.Append(character.Gender + ",");
				var skinColors = character.SkinColor?.Replace(",", "-");
				sb.Append(skinColors + ",");
				var hairColors = character.HairColor?.Replace(",", "-");
				sb.Append(hairColors + ",");
				sb.Append(character.Height + ",");
				var eyeColors = character.EyeColor?.Replace(",", "-");
				sb.Append(eyeColors + ",");
				sb.Append(character.Mass + ",");
				sb.Append(character.Homeworld.Name + ",");
				sb.Append(character.BirthYear + ",");
				sb.Append(character.EpisodeId);

				sb.AppendLine();
			}

			return sb.ToString().Trim();
		}
	}
}
