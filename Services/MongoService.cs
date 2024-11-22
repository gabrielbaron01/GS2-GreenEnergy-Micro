using gs2Gb93266Ez92955.Models;
using MongoDB.Driver;

namespace gs2Gb93266Ez92955.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<ConsumptionModel> _consumoCollection;

        public MongoService(IConfiguration configuration)
        {

            var client = new MongoClient(configuration["MongoSettings:ConnectionString"]);


            var database = client.GetDatabase(configuration["MongoSettings:DatabaseName"]);


            _consumoCollection = database.GetCollection<ConsumptionModel>("Consumos");
        }


        public async Task AddConsumoAsync(ConsumptionModel consumo)
        {
            await _consumoCollection.InsertOneAsync(consumo); 
        }

        public async Task<List<ConsumptionModel>> GetConsumosAsync()
        {
            return await _consumoCollection.Find(_ => true).ToListAsync();
        }


        public async Task<ConsumptionModel> GetConsumoByIdAsync(string id)
        {
            return await _consumoCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
