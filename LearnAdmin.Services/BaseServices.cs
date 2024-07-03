using LearnAdmin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAdmin.Services
{
    class BaseServices<TEntity> : IBaseRepository<TEntity> where TEntity :class, new()
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
          return  _baseRepository.DeleteAsync(entity, autoSave, cancellationToken);
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
          return  _baseRepository.DeleteAsync(entity, autoSave, cancellationToken);
        }

        public Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> FindAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetPageListAsync(int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(IEnumerable<TEntity> entiries, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
