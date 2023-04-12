using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Transaction.Microsoft
{
    public class MsTransactionAspect : AfMethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();

                    transactionScope.Complete();
                }
                catch (Exception exception)
                {
                    transactionScope.Dispose();

                    throw exception;
                }
            }
        }
    }
}
