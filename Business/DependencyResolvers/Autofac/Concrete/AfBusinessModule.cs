using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Interceptors.Autofac.Concrete;
using Core.Utilities.Security.Concrete.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac.Concrete
{
    public class AfBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Category Configure
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDao>().As<ICategoryDao>();

            //Company Configure
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDao>().As<ICompanyDao>();

            //PaymentType Configuration
            builder.RegisterType<PaymentTypeManager>().As<IPaymentTypeService>();
            builder.RegisterType<EfPaymentTypeDao>().As<IPaymentTypeDao>();

            //Receipt Configuration
            builder.RegisterType<ReceiptManager>().As<IReceiptService>();
            builder.RegisterType<EfReceiptDao>().As<IReceiptDao>();

            //User Configuration
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDao>().As<IUserDao>();

            //Authentication Configuration
            builder.RegisterType<AuthenticationManager>().As<IAuthenticationService>();

            //Token Configuration
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            //Aspect Configuration
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AfAspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
