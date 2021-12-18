using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VoiceStickerBot.Data.Abstract
{
    public interface IEntityRepository<T> where T : class
    {
        public Task<T> GetById(Guid guid);
        public Task<IEnumerable<T>> GetAll();
        public IQueryable<T> Get<TOrderKey>(int skip = 0, int take = 0, string includeProperties = "", Expression<Func<T, bool>> where = null, Expression<Func<T, TOrderKey>> orderBy = null, bool ascending = true);
        public Task Create(T entity);
    }
}