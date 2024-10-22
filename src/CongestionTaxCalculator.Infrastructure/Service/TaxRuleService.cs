
namespace CongestionTaxCalculator.Infrastructure.Service
{
    public class TaxRuleService : BaseService<TaxRule, int>, ITaxRuleService
    {
        private readonly IApplicationDbContext _context;
        public TaxRuleService(IApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public int CalculateTax(int cityId, DateTime[] dates, VehicleType vehicleType)
        {
            return GetTax(cityId, dates, vehicleType);
        }
        private int GetTax(int cityId, DateTime[] dates, VehicleType vehicleType)
        {
            var datee=dates.OrderBy(p=>p.Date).ThenBy(p=>p.Hour).ThenBy(p=>p.Minute);
            DateTime intervalStart = dates.First();
            int totalFee = 0;
            foreach (DateTime date in datee)
            {
                int nextFee = GetTollFee(cityId,date, vehicleType);
                int tempFee = GetTollFee(cityId, intervalStart, vehicleType);

                var minutes = (date-intervalStart).TotalMinutes;
               

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }

                intervalStart = date;
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
        private int GetTollFee(int cityId, DateTime date, VehicleType vehicle)
        {
            if (IsTollFreeDate(cityId,date) || vehicle.IsTaxFree) return 0;

    
            TimeOnly time = new TimeOnly(date.Hour, date.Minute);

            var taxRule=FirstOrDefault(t =>t.CityId==cityId && time >= t.FromTime && time <= t.ToTime);
            return taxRule?.Amount ?? 0;
        }

        private Boolean IsTollFreeDate(int cityId, DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            var selectedDate = _context.Set<Calender>()
                .FirstOrDefault(p => p.CityId == cityId && p.Date == new DateOnly(year, month, day));
            return selectedDate?.IsTaxFree ?? false;

        }
    }
}
