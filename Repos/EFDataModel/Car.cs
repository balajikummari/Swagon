namespace Swagon.DataBase.DataModel
{
    public partial class Car : IEntity
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Occupency { get; set; }
    }
}
