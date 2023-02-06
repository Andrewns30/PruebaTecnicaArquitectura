using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PruebaTecnica.DataAccess.Repository
{
    public interface IDataRepository<TEntity> where TEntity : class, new()
    {
        DbContext _context { get; set; }
        DbSet<TEntity> _entity { get; set; }
        Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? expresion = null);
    }
}