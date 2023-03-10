using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Order_WU_KPI")]
    public class OrderWU_KPI : ModelBase
    {
        public OrderWUDistribution? OrderWUDistribution { get; set; }
        public int? Year { get; set; }
        public int? January { get; set; }
        public int? February { get; set; }
        public int? March { get; set; }
        public int? April { get; set; }
        public int? May { get; set; }
        public int? June { get; set; }
        public int? July { get; set; }
        public int? August { get; set; }
        public int? September { get; set; }
        public int? October { get; set; }
        public int? November { get; set; }
        public int? December { get; set; }

        public KPIType? KPIType { get; set; }
    }
}
