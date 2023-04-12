using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.Utilities.Interceptors.Autofac.Abstract;
using Core.Utilities.IoC.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Caching.Microsoft
{
    public class MsCachingAspect : AfMethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly int _duration;

        public MsCachingAspect(ICacheManager cacheManager, int duration = 60)
        {
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            _duration = duration;
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = string.Format($"{methodName}({string.Join(",", arguments.Select(a => a?.ToString() ?? "<Null>"))})");

            if ( _cacheManager.IsAdded(key) )
            {
                invocation.ReturnValue = _cacheManager.Get(key);

                return;
            }

            invocation.Proceed();

            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
