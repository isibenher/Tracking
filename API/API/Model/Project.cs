namespace API.Model
{
    public class Project : ModelBase
    {
        public string? ProjectNumber { get; set; }
        public bool? ACME { get; set; }
        public string? Service { get; set; }
        public string? RiskPlan { get; set; }
        public string? Description { get; set; }
    }
}
