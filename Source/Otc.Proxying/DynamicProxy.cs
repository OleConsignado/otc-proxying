using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Otc.Proxying
{
    public class DynamicProxy<TExposedType, TDecorator> : DispatchProxy
        where TDecorator : class
    {
        private TDecorator decorator;
        private IInterceptor interceptor;
        
        internal void SetDecorator(TDecorator decorator)
        {
            this.decorator = decorator ?? throw new ArgumentNullException(nameof(decorator));
        }

        internal void SetInterceptor(IInterceptor interceptor)
        {
            this.interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            object result = null;

            interceptor.Before(args);

            if (targetMethod == null)
            {
                throw new ArgumentNullException(nameof(targetMethod));
            }

            if(typeof(Task).IsAssignableFrom(targetMethod.ReturnParameter.ParameterType))
            {
                // probably async method
            }
            else
            {
                try
                {
                    // not an async method, so just invoke it.
                    result = targetMethod.Invoke(decorator, args);
                }
                catch (TargetInvocationException tie)
                {
                    interceptor.OnException(tie.InnerException);
                    ExceptionDispatchInfo.Capture(tie.InnerException).Throw();
                }
            }

            interceptor.After(ref result);

            return result;
        }
    }

    public class DynamicProxy
    {
        public static TExposedType Create<TExposedType, TDecorator>(TDecorator decorator, IInterceptor interceptor)
            where TDecorator : class
        {
            if (decorator == null)
            {
                throw new ArgumentNullException(nameof(decorator));
            }

            if (interceptor == null)
            {
                throw new ArgumentNullException(nameof(interceptor));
            }

            var proxy = DispatchProxy.Create<TExposedType, DynamicProxy<TExposedType, TDecorator>>();
            var dynamicProxy = (proxy as DynamicProxy<TExposedType, TDecorator>);
            dynamicProxy.SetDecorator(decorator);
            dynamicProxy.SetInterceptor(interceptor);

            return proxy;
        }
    }
}
