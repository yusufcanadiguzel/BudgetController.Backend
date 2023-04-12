using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.Utilities.IoC.Concrete;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MsMemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;

        public MsMemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _cache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            var result = _cache.Get<T>(key);

            return result;
        }

        public object Get(string key)
        {
            var result = _cache.Get(key);

            return result;
        }

        public bool IsAdded(string key)
        {
            var result = _cache.TryGetValue(key, out _);

            return result;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
