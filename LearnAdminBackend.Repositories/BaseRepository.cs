using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearnAdmin.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly LearnAdminContext _dbContext;

        public BaseRepository(LearnAdminContext dbConterxt)
        {
            this._dbContext = dbConterxt;
        }

        /// <summary>
        /// 功能描述：根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }


        /// <summary>
        /// 功能描述：根据筛选条件删除数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var dbSet = _dbContext.Set<TEntity>();

            var entities = await dbSet.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// 功能描述：根据实体集合删除数据
        /// </summary>
        /// <param name="entities">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _dbContext.RemoveRange(entities);

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        /// <summary>
        /// 功能描述：更具筛选条件获取一条数据（如果不存在返回Null）
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().Where(predicate).SingleOrDefaultAsync(cancellationToken);
        }


        /// <summary>
        /// 功能描述：根据筛选条件获取一条数据（如果不存在抛出异常）
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(predicate, cancellationToken);
            // 数据不存在触发异常
            if (entity == null)
            {
                throw new Exception(nameof(TEntity) + "数据不存在");
            }

            return entity;
        }


        /// <summary>
        /// 功能描述: 根据筛选条件获取筛选数据条数
        /// </summary>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().Where(predicate).LongCountAsync(cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据筛选条件查询数据
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 功能描述：分页查询数据
        /// </summary>
        /// <param name="skipCount">跳过多少条</param>
        /// <param name="maxResultCount">获取多少条</param>
        /// <param name="sorting">排序字段</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<List<TEntity>> GetPageListAsync(int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().OrderBy((_) => sorting).Skip(skipCount).Take(maxResultCount).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 功能描述:添加实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（当CancellationToken是取消状态，Task内部未启动的任务不会启用新线程）</param>
        /// <returns></returns>
        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var saveEntity = (await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;

            if (autoSave)
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
        public async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entityArray = entities.ToArray();
            await _dbContext.Set<TEntity>().AddRangeAsync(entityArray, cancellationToken);

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// 功能描述：更新实体
        /// </summary>
        /// <param name="entity">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            // Attach 是将一个处于Detached的Entity附加到上下文，而附加到上下文后的这一Entity的State为Unchanged。传递到Attach方法的对象必须具有有效的EntityKey值
            _dbContext.Attach(entity);

            var updatedEntity = _dbContext.Update(entity).Entity;

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return updatedEntity;
        }


        /// <summary>
        /// 功能描述：批量更新实体
        /// </summary>
        /// <param name="entity">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);

            if (autoSave)
            {

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

