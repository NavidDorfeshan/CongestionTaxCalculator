
namespace CongestionTaxCalculator.Domain.Entities
{
    public class VehicleType : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsTaxFree { get; set; }
        public ICollection<VehicleTrafficHistory> VehicleTrafficHistories { get; set; }
    }
}
