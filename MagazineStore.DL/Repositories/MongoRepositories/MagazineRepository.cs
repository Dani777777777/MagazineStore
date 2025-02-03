using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MagazineStore.DL.Interfaces;
using MagazineStore.Models.Configurations;
using MagazineStore.Models.DTO;

namespace MagazineStore.DL.Repositories.MongoRepositories
{
    public class MagazineRepository : IMagazineRepository
    {
        private readonly IMongoCollection<Magazine> _magazines;
        private readonly ILogger<MagazineRepository> _logger;

        public MagazineRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<MagazineRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _magazines = database.GetCollection<Magazine>(
                $"{nameof(Magazine)}s");
        }

        public List<Magazine> GetAllMagazines()
        {
           return _magazines.Find(magazine => true).ToList();
        }

        public void AddMagazine(Magazine magazine)
        {
            if (magazine == null)
            {
                _logger.LogError("Magazine is null");
                return;
            }

            try
            {
                magazine.Id = Guid.NewGuid().ToString();

                _magazines.InsertOne(magazine);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding Magazine {e.Message}-{e.StackTrace}");
            }
           
        }

        public Magazine? GetMagazineById(string id)
        {
            if(string.IsNullOrEmpty(id)) return null;

            return _magazines.Find(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
