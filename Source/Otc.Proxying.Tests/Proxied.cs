using System;
using System.Threading.Tasks;

namespace Otc.Proxying.Tests
{
    public class Proxied : IProxied
    {
        public string VoidMethodTestBag { get; private set; }
        public string VoidMethodAsyncTestBag { get; private set; }

        public virtual void VoidMethod()
        {
            VoidMethodTestBag = "VoidMethod called";
        }

        public virtual void ThrowAnException()
        {
            throw new AnException();
        }

        public virtual string ReturnStringMethod()
        {
            return "ReturnStringMethod result";
        }

        public async Task VoidMethodAsync()
        {
            await Task.Delay(100);
            VoidMethodAsyncTestBag = "VoidMethodAsync called";
        }
    }
}
