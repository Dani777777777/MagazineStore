using MagazineStore.BL.Interfaces;
using MagazineStore.DL.Interfaces;
using MagazineStore.Models.DTO;

namespace MagazineStore.BL.Services
{
    internal class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void Add(Author author)
        {
            _authorRepository.AddAuthor(author);
        }
    }
}
