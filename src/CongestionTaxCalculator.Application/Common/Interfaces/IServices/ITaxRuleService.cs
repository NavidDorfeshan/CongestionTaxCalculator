using CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Application.Common.Interfaces.IServices
{
    public interface ITaxRuleService : IBaseService<TaxRule, int>
    {
       int CalculateTax(int cityId, DateTime[] dates, VehicleType vehicleType);
    }
}
