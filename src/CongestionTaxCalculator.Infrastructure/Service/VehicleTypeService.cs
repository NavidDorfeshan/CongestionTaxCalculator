namespace CongestionTaxCalculator.Infrastructure.Service
{
    public class VehicleTypeService : BaseService<VehicleType, int>, IVehicleTypeService
    {
        private readonly IApplicationDbContext _context;
        public VehicleTypeService(IApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<VehicleType> FindVehicleByName(string name,CancellationToken cancellationToken)
        {
           return await FirstOrDefaultAsync(v => name.Equals(v.Name), cancellationToken);
        }
    }
}
