namespace API.Model
{
    public class DeliveryAcceptanceNote : ModelBase
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public Project? Project { get; set; }
        public int? DanSerial { get; set; }
        public DateTime? DanGenerationDate { get; set; }
        public string? BoD { get; set; }
        public string? PhtFocal { get; set; }
        public bool? BodSigned { get; set; }
    }
}
