using Castle.DynamicProxy;

namespace Library
{
    public class NoInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

        }
    }
}
