namespace Swagon.DataBase.DataModel
{
    public partial class Stops : IEntity
    {
        public string OfferId { get; set; }
        public string CityIdofStop { get; set; }
        public string Id { get; set; }

        public int Sequence { get; set; }
    }
}
