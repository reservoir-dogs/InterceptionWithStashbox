using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stashbox;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the services.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ILevel1Service, Level1Service>();
            services.AddScoped<ILevel2Service, Level2Service>();
            services.AddScoped<ILevel2bService, Level2bService>();
            services.AddScoped<ILevel3Service, Level3Service>();
            services.AddScoped<ILevel4Service, Level4Service>();
        }

        public void ConfigureContainer(IStashboxContainer container)
        {
            var proxyBuilder = new DefaultProxyBuilder();

            container.Register<IInterceptor, NoInterceptor>();
            container.RegisterDecorator<ILevel2Service>(proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ILevel2Service), Array.Empty<Type>(), ProxyGenerationOptions.Default));
            container.RegisterDecorator<ILevel2bService>(proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ILevel2bService), Array.Empty<Type>(), ProxyGenerationOptions.Default));
            container.RegisterDecorator<ILevel3Service>(proxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(typeof(ILevel3Service), Array.Empty<Type>(), ProxyGenerationOptions.Default));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
