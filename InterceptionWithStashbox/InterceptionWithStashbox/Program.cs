using Castle.DynamicProxy;

using Library;

using Microsoft.Extensions.DependencyInjection;

using Stashbox;

using System;

namespace InterceptionWithStashbox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new StashboxContainer();

            container.RegisterScoped<ILevel1Service, Level1Service>();
            container.RegisterScoped<ILevel2Service, Level2Service>();
            container.RegisterScoped<ILevel2bService, Level2bService>();
            container.RegisterScoped<ILevel3Service, Level3Service>();
            container.RegisterScoped<ILevel4Service, Level4Service>();

            var proxyBuilder = new DefaultProxyBuilder();

            container.Register<IInterceptor, NoInterceptor>();
            container.RegisterDecorator<ILevel1Service>(proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ILevel1Service), Array.Empty<Type>(), ProxyGenerationOptions.Default));
            container.RegisterDecorator<ILevel2Service>(proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ILevel2Service), Array.Empty<Type>(), ProxyGenerationOptions.Default));
            container.RegisterDecorator<ILevel2bService>(proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ILevel2bService), Array.Empty<Type>(), ProxyGenerationOptions.Default));

            var tmp = container.GetRequiredService<ILevel1Service>();
        }
    }
}
