namespace API.Model
{
    public class ProjectAsocContact : ModelBase
    {
        public int? ProjectId { get; set; }
        public AdsContact? Contact { get; set; }
    }
}
