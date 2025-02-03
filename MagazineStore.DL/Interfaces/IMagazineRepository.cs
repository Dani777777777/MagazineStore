using MagazineStore.Models.DTO;

namespace MagazineStore.DL.Interfaces
{
    public interface IMagazineRepository
    {
        List<Magazine> GetAllMagazines();
        void AddMagazine(Magazine magazine);
        Magazine? GetMagazineById(string id);
    }
}
