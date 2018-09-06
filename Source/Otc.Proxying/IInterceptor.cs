using System;
using System.Collections.Generic;
using System.Text;

namespace Otc.Proxying
{
    public interface IInterceptor
    {
        void Before(object[] args);
        void After(ref object returnValue);
        void OnException(Exception e);
    }
}
