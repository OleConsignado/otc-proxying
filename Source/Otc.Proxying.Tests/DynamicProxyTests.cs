using System;
using System.Threading.Tasks;
using Xunit;

namespace Otc.Proxying.Tests
{
    public class DynamicProxyTests
    {
        private IProxied proxy;
        private Proxied realObject;

        public DynamicProxyTests()
        {
            realObject = new Proxied();
            var interceptor = new Interceptor();
            proxy = DynamicProxy.Create<IProxied, Proxied>(realObject, interceptor);
        }

        [Fact]
        public void TestVoidNoAsyncMethod()
        {
            proxy.VoidMethod();
            Assert.Equal("VoidMethod called", realObject.VoidMethodTestBag);
        }

        [Fact]
        public void TestThrowException()
        {
            Assert.Throws<AnException>(() => proxy.ThrowAnException());
        }

        [Fact]
        public void TestReturnStringMethod()
        {
            Assert.Equal("ReturnStringMethod result", proxy.ReturnStringMethod());
        }

        [Fact]
        public async Task VoidMethodAsyncTest()
        {
            await proxy.VoidMethodAsync();
            Assert.Equal("VoidMethodAsync called", realObject.VoidMethodAsyncTestBag);
        }
    }
}
