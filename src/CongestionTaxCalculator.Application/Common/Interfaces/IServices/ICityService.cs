using CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Application.Common.Interfaces.IServices
{
    public interface ICityService : IBaseService<City, int>
    {
        Task<City> FindCityByName(string name,CancellationToken cancellationToken);
    }
}
