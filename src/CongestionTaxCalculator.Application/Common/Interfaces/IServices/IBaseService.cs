

namespace CongestionTaxCalculator.Application.Common.Interfaces.IServices
{
    public interface IBaseService<T, TKey>
    {
        T Find(TKey id);
        T FirstOrDefault(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
        bool All(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        bool IsExist(TKey id);
        Task<T> FindAsync(TKey id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where);
        Task<bool> AllAsync(Expression<Func<T, bool>> predicate);
    }
}
