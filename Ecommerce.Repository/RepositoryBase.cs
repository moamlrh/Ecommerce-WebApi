using System.Linq.Expressions;
using Ecommerce.Contracts;

namespace Ecommerce.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context) => _context = context;

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public IQueryable<T> FindAll() => _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition) => _context.Set<T>().Where(condition);
}
