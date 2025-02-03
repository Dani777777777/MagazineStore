using MagazineStore.Models.DTO;

namespace MagazineStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
    	void AddAuthor(Author author);
        IEnumerable<Author> GetAuthorsByIds(IEnumerable<string> authorIds);
        Author? GetById(string id);
    }
}
