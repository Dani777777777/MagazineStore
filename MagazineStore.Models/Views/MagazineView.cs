using MagazineStore.Models.DTO;

namespace MagazineStore.Models.Views
{
    public class MagazineView
    {
        public string MagazineId { get; set; }

        public string MagazineTitle { get; set; } = string.Empty;

        public int MagazineYear { get; set; }

        public IEnumerable<Author> Authors { get; set; } = [];
    }
}
