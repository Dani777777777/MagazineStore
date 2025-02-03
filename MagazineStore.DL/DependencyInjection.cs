using Microsoft.Extensions.DependencyInjection;
using MagazineStore.DL.Interfaces;
using MagazineStore.DL.Repositories;
using MagazineStore.DL.Repositories.MongoRepositories;

namespace MagazineStore.DL
{
    public static class DependencyInjection
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddSingleton<IMagazineRepository, MagazineRepository>()
                .AddSingleton<IAuthorRepository, AuthorRepository>();
        }
    }
}
