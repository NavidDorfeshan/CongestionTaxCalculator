

namespace CongestionTaxCalculator.Application.CalculateTax.Query
{
    public record GetTaxVehicleQuery(string vehicle,string cityName, DateTime[] dates) : IRequest<int>;

    public class GetTaxVehicleHandler : IRequestHandler<GetTaxVehicleQuery, int>
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly ICityService _cityService;
        private readonly ITaxRuleService _taxRuleService;

        public GetTaxVehicleHandler(ICityService cityService,IVehicleTypeService vehicleTypeService, ITaxRuleService taxRuleService)
        {
            _vehicleTypeService = vehicleTypeService;
            _taxRuleService = taxRuleService;
            _cityService = cityService;
        }

        public async Task<int> Handle(GetTaxVehicleQuery request, CancellationToken cancellationToken)
        {
          
            var vehicle = await _vehicleTypeService.FindVehicleByName(request.vehicle,cancellationToken);
            var city = await _cityService.FindCityByName(request.cityName,cancellationToken);
            if (vehicle == null) return -1;
            if (city == null) return -1;
            if (request.dates.Length==0) return -1;

            return _taxRuleService.CalculateTax(city.Id, request.dates, vehicle);
        }
       

        
    }

}
