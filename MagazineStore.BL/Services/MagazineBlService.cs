using MagazineStore.BL.Interfaces;
using MagazineStore.DL.Interfaces;
using MagazineStore.Models.DTO;
using MagazineStore.Models.Views;

namespace MagazineStore.BL.Services
{
    internal class MagazineBlService : IMagazineBlService
    {
        private readonly IMagazineService _magazineService;
        private readonly IAuthorRepository _authorRepository;

        public MagazineBlService(
            IMagazineService magazineService,
            IAuthorRepository authorRepository)
        {
            _magazineService = magazineService;
            _authorRepository = authorRepository;
        }

        public List<MagazineView> GetDetailedMagazines()
        {
            var result = new List<MagazineView>();

            var magazines = _magazineService.GetAllMagazines();

            foreach (var magazine in magazines)
            {
                var magazineView = new MagazineView
                {
                    MagazineId = magazine.Id,
                    MagazineTitle = magazine.Title,
                    MagazineYear = magazine.Year,
                    Authors = _authorRepository.GetAuthorsByIds(magazine.Authors)
                };

                result.Add(magazineView);
            }

            return result;
        }
    }
}
