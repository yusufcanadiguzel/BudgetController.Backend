using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors.Autofac.Abstract
{
    public abstract class AfMethodInterception : AfMethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnFailure(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSuccess = false;

                OnFailure(invocation);

                throw;
            }
            finally 
            { 
                if(isSuccess)
                    OnSuccess(invocation);
            }

            OnAfter(invocation);
        }
    }
}
