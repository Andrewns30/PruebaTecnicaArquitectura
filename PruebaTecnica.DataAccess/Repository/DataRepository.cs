using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DataAccess.Repository
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class, new()
    {
        #region Fields
        public DbContext _context { get; set; }
        public DbSet<TEntity> _entity { get; set; }
        #endregion

        #region Builder

        public DataRepository(DbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }
        #endregion

        #region Methods

        public async Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? expresion = null)
        {
            List<TEntity> result;
            if (expresion == null)
            {
                result = await _entity.ToListAsync();
            }
            else
            {
                result = await _entity.Where(expresion).ToListAsync();
            }

            return result;
        }

        #endregion
    }
}
