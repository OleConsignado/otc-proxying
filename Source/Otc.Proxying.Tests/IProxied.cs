using System.Threading.Tasks;

namespace Otc.Proxying.Tests
{
    public interface IProxied
    {
        void VoidMethod();
        void ThrowAnException();
        string ReturnStringMethod();
        Task VoidMethodAsync();
    }
}