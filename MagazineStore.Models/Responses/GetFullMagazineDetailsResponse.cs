using MagazineStore.Models.Views;

namespace MagazineStore.Models.Responses
{
    public class GetFullMagazineDetailsResponse
    {
        IEnumerable<MagazineView> Magazines { get; set; } = [];
    }
}
