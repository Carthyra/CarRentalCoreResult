﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
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
                    // invocation proceed i yapabilirse transaction'ı tamamla.
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    // try içindeki kod başarısız olursa transaction'ı sil.(geri al)
                    throw;
                }
            }
        }
    }
}
