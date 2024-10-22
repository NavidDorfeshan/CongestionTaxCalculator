
namespace CongestionTaxCalculator.Infrastructure.Service
{
    public class BaseService<T, TKey> : IBaseService<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly DbSet<T> _dbSet;
        public BaseService(IApplicationDbContext dbContext)
        {
           
            _dbSet = dbContext.Set<T>();

        }

        public virtual bool IsExist(TKey Id)
        {
            return _dbSet.Find(Id) != null;
        }

        public virtual T Find(TKey Id)
        {
            return _dbSet.Find(Id);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public virtual bool All(Expression<Func<T, bool>> @where)
        {
            return _dbSet.All(@where);

        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual async Task<T> FindAsync(TKey Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual async Task<bool> AllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AllAsync(predicate);
        }


    }


}
