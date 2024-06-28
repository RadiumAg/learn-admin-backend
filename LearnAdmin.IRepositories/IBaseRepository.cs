using System.Linq.Expressions;

namespace LearnAdmin.Repositories
{
	/// <summary>
	/// 仓促基类接口
	/// </summary>
	public interface IBaseRepository<TEntity> where TEntity:class
	{
		/// <summary>
		/// 功能描述:添加实体数据
		/// </summary>
		/// <param name="entity">实体类</param>
		/// <param name="autoSave">是否马上更新到数据库</param>
		/// <param name="cancellationToken">取消令牌（当CancellationToken是取消状态，Task内部未启动的任务不会启用新线程）</param>
		/// <returns></returns>
		Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

		/// <summary>
		/// 功能描述：批量插入实体
		/// </summary>
		/// <param name="entiry"></param>
		/// <param name="autoSave"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task InsertManyAsync(IEnumerable<TEntity> entiries, bool autoSave = false, CancellationToken cancellationToken = default);

		/// <summary>
		/// 功能描述：更新实体
		/// </summary>
		/// <param name="entity">实体类集合</param>
		/// <param name="autoSave">是否马上更新到数据库</param>
		/// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
		/// <returns></returns>
		Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：批量更新实体
        /// </summary>
        /// <param name="entity">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<TEntity> UpdateManyAsync(IEnumerable<TEntity> entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<TEntity> DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据筛选条件删除数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据实体集合删除数据
        /// </summary>
        /// <param name="entities">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<TEntity> DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：更具筛选条件获取一条数据（如果不存在返回Null）
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据筛选条件获取一条数据（如果不存在抛出异常）
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据筛选条件查询数据
        /// </summary>
        /// <param name="predicate">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity,bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：分页查询数据
        /// </summary>
        /// <param name="skipCount">跳过多少条</param>
        /// <param name="maxResultCount">获取多少条</param>
        /// <param name="sorting">排序字段</param>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task GetPageListAsync(int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述: 根据筛选条件获取筛选数据条数
        /// </summary>
        /// <param name="cancellationToken">取消令牌（CancellationToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}

