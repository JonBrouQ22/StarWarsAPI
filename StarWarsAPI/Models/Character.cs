using System;

namespace StarWarsAPI.Models
{
    public class Character : IEquatable<Character>
    {
        public string ObjectId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string SkinColor { get; set;}
        public string HairColor { get; set;}
        public int Height { get; set;}
        public string EyeColor { get; set;}
        public float? Mass { get; set;}
        public Planet Homeworld { get; set;}
        public string BirthYear { get; set;}
        public int EpisodeId { get; set; }
        public bool Equals(Character other)
        {
            if (other is null)
                return false;
            return ObjectId.Equals(other.ObjectId);
        }
        public override bool Equals(object obj) => Equals(obj as Character);
        public override int GetHashCode() => (ObjectId).GetHashCode();
    }
}
