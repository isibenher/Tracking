namespace API.Model
{
    public class DeliveryAcceptandeNoteLine : ModelBase
    {
        public DeliveryAcceptanceNote? Dan { get; set; }
        public OrderWUDistribution? OrderWUDistribution { get; set; }
        public int? Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? Otd { get; set; }
        public int? Oqd { get; set; }
        public int? Rft { get; set; }
    }
}
