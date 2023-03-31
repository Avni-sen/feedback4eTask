using Castle.DynamicProxy;
using feedback4eTask.Core.Utilities.Interceptors;
using System.Transactions;

namespace feedback4eTask.Core.Aspect.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
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
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }

        }
    }
}
