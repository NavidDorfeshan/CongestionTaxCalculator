
namespace CongestionTaxCalculator.Infrastructure.Service
{
    public class CityService : BaseService<City, int>, ICityService
    {
        private readonly IApplicationDbContext _context;
        public CityService(IApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<City> FindCityByName(string name,CancellationToken cancellationToken)
        {
           return await FirstOrDefaultAsync(v => name.Equals(v.Name), cancellationToken);
        }
    }
}
