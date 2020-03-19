namespace Swagon.DomainModel
{
    public class City : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public float Latitute { get; set; }
        public float Longitude { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
    }
}
