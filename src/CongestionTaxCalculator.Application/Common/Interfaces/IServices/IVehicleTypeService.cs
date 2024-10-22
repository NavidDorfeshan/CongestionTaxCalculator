using CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Application.Common.Interfaces.IServices
{
    public interface IVehicleTypeService : IBaseService<VehicleType, int>
    {
        Task<VehicleType> FindVehicleByName(string name,CancellationToken cancellationToken);
    }
}
