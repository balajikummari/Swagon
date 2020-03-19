namespace Swagon.DataBase.DataModel
{
    public partial class City : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public double Latitute { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
    }
}
