namespace CongestionTaxCalculator.Domain.Entities
{
    public class VehicleTrafficHistory : BaseEntity<int>
    {
        public DateTime DateTime { get; set; }
        public int VehicleTypeId { get; set; }
        public int CityId { get; set; }
        public VehicleType VehicleType { get; set; }
        public City City { get; set; }
    }
}
