using MagazineStore.Models.DTO;

namespace MagazineStore.Models.Responses
{
    public class GetDetailedMagazineResponse
    {
        public Magazine Magazine { get; set; }

        public List<Author> Authors { get; set; }
    }
}
