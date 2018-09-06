using System;
using System.Diagnostics;

namespace Otc.Proxying.Tests
{
    public class Interceptor : IInterceptor
    {
        public void After(ref object returnValue)
        {
            Debug.WriteLine($"{nameof(Interceptor)}.{nameof(After)}: called with returnValue of {returnValue}");
        }

        public void Before(object[] args)
        {
            Debug.WriteLine($"{nameof(Interceptor)}.{nameof(Before)}: called with args {args}");
        }

        public void OnException(Exception e)
        {
            Debug.WriteLine($"{nameof(Interceptor)}.{nameof(OnException)}: called with Exception {e}");
        }
    }
}
