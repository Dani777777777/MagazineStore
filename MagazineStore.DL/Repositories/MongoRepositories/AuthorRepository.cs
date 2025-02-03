using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MagazineStore.DL.Interfaces;
using MagazineStore.Models.Configurations;
using MagazineStore.Models.DTO;

namespace MagazineStore.DL.Repositories.MongoRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Author> _authors;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<AuthorRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _authors = database.GetCollection<Author>(
                $"{nameof(Author)}s");
        }

        public void AddAuthor(Author author)
        {
            author.Id = System.Guid.NewGuid().ToString();
            _authors.InsertOne(author);
        }

        public void AddMagazine(Author magazine)
        {
            if (magazine == null)
            {
                _logger.LogError("Magazine is null");
                return;
            }

            try
            {
                magazine.Id = Guid.NewGuid().ToString();

                _authors.InsertOne(magazine);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding Magazine {e.Message}-{e.StackTrace}");
            }
           
        }


        public IEnumerable<Author> GetAuthorsByIds(IEnumerable<string> authorsIds)
        {
            var result = _authors.Find(Author => authorsIds.Contains(Author.Id)).ToList();
            return result;
        }

        public Author? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return _authors.Find(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
