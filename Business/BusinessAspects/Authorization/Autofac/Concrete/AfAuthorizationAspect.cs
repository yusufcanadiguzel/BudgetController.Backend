using Business.Constants.Concrete;
using Castle.DynamicProxy;
using Core.Extensions.Concrete;
using Core.Utilities.Interceptors.Autofac.Abstract;
using Core.Utilities.IoC.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Authorization.Autofac.Concrete
{
    public class AfAuthorizationAspect : AfMethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _contextAccessor;

        public AfAuthorizationAspect(string roles)
        {
            _roles = roles.Split(',');
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _contextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;
            }

            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
