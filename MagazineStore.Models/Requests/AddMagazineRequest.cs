namespace MagazineStore.Models.Requests
{
    public class AddMagazineRequest
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }
    }
}
