using System;
namespace LearnAdmin.Common.MemoryCache
{
	public interface ICachingProvider
	{

		Object Get(string cacheKey);

		void Set(string cacheKey, object cacheValue);
	}
}

