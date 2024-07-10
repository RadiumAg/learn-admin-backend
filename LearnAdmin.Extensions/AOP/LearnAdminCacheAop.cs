using System.Linq;
using Castle.DynamicProxy;
using LearnAdmin.Common.MemoryCache;

namespace LearnAdmin.Extensions.AOP
{
    public class LearnAdminCacheAop:IInterceptor
	{
        private ICachingProvider _cache;

		public LearnAdminCacheAop(ICachingProvider cache)
		{
            _cache = cache;
		}

        void IInterceptor.Intercept(IInvocation invocation)
        {
            var cacheKey = CustomCacheKey(invocation);
            var cacheValue = _cache.Get(cacheKey);
            if (cacheKey != null) {
                // 将当前获取到的缓存值，赋值给当前执行方法
                invocation.ReturnValue = cacheValue;
                return;
            }
            // 去执行当前的方法
            invocation.Proceed();
            // 存入缓存
            if(!string.IsNullOrWhiteSpace(cacheKey))
            {
                _cache.Set(cacheKey, invocation.ReturnValue);
            }

        }

        // 自定义缓存键
        private string CustomCacheKey(IInvocation invocation) {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList();
            var key = $"{typeName}：{methodName}";

            foreach (var param in methodArguments) {
                key += $"{param}：";
                    }
            return key.TrimEnd(':');
        }


        private string GetArgumentValue(object arg) {
            if (arg is int || arg is long || arg is string)
                return arg.ToString();

            if (arg is DateTime)
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");

            return "";
        }
    }
}

