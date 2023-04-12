﻿using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<ICacheManager, MsMemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
