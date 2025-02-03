using Microsoft.Extensions.DependencyInjection;
using MagazineStore.BL.Interfaces;
using MagazineStore.BL.Services;
using MagazineStore.DL;

namespace MagazineStore.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddSingleton<IMagazineService, MagazineService>();
            services.AddSingleton<IMagazineBlService, MagazineBlService>();
            services.AddSingleton<IAuthorService, AuthorService>();

            return services;
        }

        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
            services.RegisterRepositories();

            return services;
        }
    }
}
