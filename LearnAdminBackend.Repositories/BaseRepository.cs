using System;
using System.Linq.Expressions;

namespace LearnAdmin.Repositories
{
	public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity : class, new()
	{
		private readonly LearnAdminContext _dbContext;

		public BaseRepository(LearnAdminContext dbConterxt)
		{
            this._dbContext = dbConterxt;
		}

        public Task<TEntity> DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetPageListAsync(int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 功能描述：添加实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var saveEntity = (await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;

            if(autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return saveEntity;
        }

        /// <summary>
        /// 功能描述：批量插入实体
        /// </summary>
        /// <param name="entiry"></param>
        /// <param name="autoSave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entityArray = entities.ToArray();
            await _dbContext.Set<TEntity>().AddRangeAsync(entityArray, cancellationToken);

            if(autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// 功能描述
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            // Attach 是将一个处于Detached的Entity附加到上下文，而附加到上下文后的这一Entity的State为Unchanged。传递到Attach方法的对象必须具有有效的EntityKey值
            _dbContext.Attach(entity);
        }  

        public Task<TEntity> UpdateManyAsync(IEnumerable<TEntity> entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

