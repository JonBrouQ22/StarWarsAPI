namespace StarWarsAPI.Models
{
    public class Planet
    {
        public string ObjectId { get; set; }
        public string Name { get; set; }
        public string[] Climate { get; set; }
        public int Diameter { get; set; }
        //public Film[] Films { get; set; }
        public string Gravity { get; set; }
        public int OrbitalPeriod { get; set; }
        public long Population { get; set; }
        //public Character[] Residents { get; set; }
        public int RotationPeriod { get; set; }
        //public Specie[] Species { get; set; }
        public float SurfaceWater { get; set; }
        public string[] Terrain { get; set; }
    }
}
