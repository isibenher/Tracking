namespace API.Model
{
    public class Order : ModelBase
    {
        public string? PoAirbusTech { get; set; }
        public string? PoAirbus { get; set; }
        public string? PoPhtSubc { get; set; }
        public Project? Project { get; set; }
    }
}
