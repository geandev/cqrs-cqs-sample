using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Ef
{
    public class Repository<TEntity>
        where TEntity : class
    {
        protected IQueryable<TEntity> Entity { get; }

        public Repository(Context context)
        {
            Entity = context.Set<TEntity>().AsNoTracking();
        }
    }
}
