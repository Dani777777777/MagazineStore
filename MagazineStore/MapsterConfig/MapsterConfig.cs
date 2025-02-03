using Mapster;
using MagazineStore.Models.DTO;
using MagazineStore.Models.Requests;

namespace MagazineStore.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<Magazine, AddMagazineRequest>
                .NewConfig()
                .TwoWays();
        }
    }
}
