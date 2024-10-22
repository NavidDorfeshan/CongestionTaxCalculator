namespace CongestionTaxCalculator.Domain.Entities
{
    public class Calender: BaseEntity<int>
    {
        public int CityId { get; set; }
        public short Year { get; set; }
        public string MonthName { get; set; }
        public short MonthCode { get; set; }
        public DateOnly Date { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsTaxFree { get; set; }
        public bool IsWeekend { get; set; }
    }
}
