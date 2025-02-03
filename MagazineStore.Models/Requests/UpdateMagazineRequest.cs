namespace MagazineStore.Models.Requests
{
    public class UpdateMagazineRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}
