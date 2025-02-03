using MagazineStore.Models.DTO;

namespace MagazineStore.BL.Interfaces
{
    public interface IMagazineService
    {
        List<Magazine> GetAllMagazines();

        void AddMagazine(Magazine magazine);

        Magazine? GetById(string id);
    }
}
