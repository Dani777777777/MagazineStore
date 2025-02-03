using MagazineStore.BL.Interfaces;
using MagazineStore.DL.Interfaces;
using MagazineStore.Models.DTO;

namespace MagazineStore.BL.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly IMagazineRepository _magazineRepository;
        private readonly IAuthorRepository _authorRepository;

        public MagazineService(IMagazineRepository magazineRepository, IAuthorRepository authorRepository)
        {
            _magazineRepository = magazineRepository;
            _authorRepository = authorRepository;
        }
        
        public List<Magazine> GetAllMagazines()
        {
            return _magazineRepository.GetAllMagazines();
        }

        public void AddMagazine(Magazine? magazine)
        {
            if (magazine is null ) return;

            foreach (var magazineAuthor in magazine.Authors)
            {
                var author = _authorRepository.GetById(magazineAuthor);

                if (author is null)
                {
                    throw new Exception(
                        $"Author with id {magazineAuthor} does not exist");
                }
            }

            _magazineRepository.AddMagazine(magazine);
        }

        public Magazine? GetById(string id)
        {
            return _magazineRepository.GetMagazineById(id);
        }
    }
}
