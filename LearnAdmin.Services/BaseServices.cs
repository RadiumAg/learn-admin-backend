using LearnAdmin.IServices;
using LearnAdmin.Repositories;

namespace LearnAdmin.Services
{
    internal class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> _baseRepository = new BaseRepository<TEntity>();

        /// <summary>
        /// 功能描述：根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return _baseRepository.DeleteAsync(entity, autoSave, cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据筛选条件删除数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task DeleteAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return _baseRepository.DeleteAsync(entity, autoSave, cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据筛选条件删除数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return _baseRepository.DeleteManyAsync(entities, autoSave, cancellationToken);
        }

        /// <summary>
        /// 功能描述：更具筛选条件获取一条数据（如果不存在返回Null）
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<TEntity?> FindAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _baseRepository.FindAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据筛选条件获取一条数据（如果不存在抛出异常）
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<TEntity> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _baseRepository.GetAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 功能描述: 根据筛选条件获取筛选数据条数
        /// </summary>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<long> GetCountAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _baseRepository.GetCountAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据筛选条件查询数据
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<List<TEntity>> GetListAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _baseRepository.GetListAsync(predicate, cancellationToken);
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
            return _baseRepository.GetPageListAsync(skipCount, maxResultCount, sorting, cancellationToken);
        }

        /// <summary>
        /// 功能描述:添加实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（当CancellationToken是取消状态，Task内部未启动的任务不会启用新线程）</param>
        /// <returns></returns>
        public Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return _baseRepository.InsertAsync(entity, autoSave, cancellationToken);
        }

        /// <summary>
        /// 功能描述：批量插入实体
        /// </summary>
        /// <param name="entiry"></param>
        /// <param name="autoSave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
           return _baseRepository.InsertManyAsync(entities, autoSave, cancellationToken);
        }

        /// <summary>
        /// 功能描述：更新实体
        /// </summary>
        /// <param name="entity">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
           return _baseRepository.UpdateAsync(entity, autoSave, cancellationToken);
        }

        /// <summary>
        /// 功能描述：批量更新实体
        /// </summary>
        /// <param name="entity">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>

        public Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return _baseRepository.UpdateManyAsync(entities, autoSave, cancellationToken);
        }
    }
}
