using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21Shop.ApplicationServices.Services;
using TARpe21Shop.Core.ServiceInterface;
using TARpe21Shop.Data;
using TARpe21Shop.SpaceshipTest.Macros;
using Microsoft.Extensions.Hosting;
using TARpe21Shop.SpaceshipTest.Mock;

namespace TARpe21Shop.SpaceshipTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        public void Dispose() { }
        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }
        protected T Macro<T>() where T : IMacros
        {
            return serviceProvider.GetService<T>();
        }
        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
            services.AddScoped<IFilesServices, FilesServices>();
            services.AddScoped<IHostingEnvironment, MockIHostEnvironment>();

            services.AddDbContext<TARpe21ShopContext>
                (x =>
                {
                    x.UseInMemoryDatabase("TEST");
                    x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });
            RegisterMacros(services);
        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);
            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}