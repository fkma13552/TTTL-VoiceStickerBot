using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoiceStickerBot.Data.Abstract;

namespace VoiceStickerBot.Data.Repositories
{
    public class EntityRepository<T>: IEntityRepository<T> where T : class
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(MyContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> Get<TOrderKey>(
            int skip = 0,
            int take = 0,
            string includeProperties = "",
            Expression<Func<T, bool>> @where = null,
            Expression<Func<T, TOrderKey>> orderBy = null,
            bool ascending = true)
        {
            IQueryable<T> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                if (ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }
            
            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }
            
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
    }
}