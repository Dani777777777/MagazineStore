using MagazineStore.DL.StaticDB;
using MagazineStore.Models.DTO;

namespace MagazineStore.DL.Repositories
{
    //[Obsolete]
    //internal class MagazineStaticRepository 
    //{
    //    public List<Magazine> GetAllMagazines()
    //    {
    //        return InMemoryDb.Magazines;
    //    }

    //    public void AddMagazine(Magazine Magazine)
    //    {
    //        if (Magazine == null) return;

    //        Magazine.Id = Guid.NewGuid().ToString();
    //        InMemoryDb.Magazines.Add(Magazine);
    //    }

    //    /// <summary>
    //    /// Get Magazine by id
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    public Magazine? GetMagazineById(string id)
    //    {
    //       return InMemoryDb.Magazines
    //           .FirstOrDefault(m => m.Id == id);
    //    }
    //}
}
