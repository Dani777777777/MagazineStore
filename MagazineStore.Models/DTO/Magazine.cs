namespace MagazineStore.Models.DTO
{
    public class Magazine
    {
        public string Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public List<string> Authors { get; set; }
    }
}
