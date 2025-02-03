using MagazineStore.Models.Views;

namespace MagazineStore.BL.Interfaces
{
    public interface IMagazineBlService
    {
        List<MagazineView> GetDetailedMagazines();
    }
}
