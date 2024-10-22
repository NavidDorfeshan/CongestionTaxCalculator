namespace CongestionTaxCalculator.Domain.Entities
{
    public class TaxRule : BaseEntity<int>
    {
        public int CityId { get; set; }
        public TimeOnly FromTime { get; set; }
        public TimeOnly ToTime { get; set; }
        public int Amount { get; set; }
        public City City { get; set; }

        public bool IsMach(TimeOnly passingTime)
        {
            return passingTime.IsBetween(FromTime, ToTime);
        }
    }
}
