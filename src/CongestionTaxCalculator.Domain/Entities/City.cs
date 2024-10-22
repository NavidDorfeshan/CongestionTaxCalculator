
namespace CongestionTaxCalculator.Domain.Entities
{
    public class City: BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Calender>Calenders { get; set; }
        public virtual ICollection<VehicleTrafficHistory> VehicleTrafficHistories { get; set; }
        public virtual ICollection<TaxRule> TaxRules { get; set; }
    }
}
