using fuelWebAPI.Models;
using MongoDB.Driver;

namespace fuelWebAPI.Services
{
    public class FuelQueueService: IFuelQueueService { 

        private readonly IMongoCollection<FuelQueue> _fuelQueue;

        public FuelQueueService(IFuelStationDBSettings settings, IMongoClient mongoClient){
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelQueue = database.GetCollection<FuelQueue>("fuelQueue");
        }

        public FuelQueue Create(FuelQueue fuelQueue){
            _fuelQueue.InsertOne(fuelQueue);
            return fuelQueue;
        }

        public List<FuelQueue> Get(){
            return _fuelQueue.Find(fuelQueue => true).ToList();
        }

        public FuelQueue Get(string id){
             return _fuelQueue.Find(fuelQueue => fuelQueue.Id == id).FirstOrDefault();
        }

        public void Update(string id, FuelQueue fuelQueue){
            _fuelQueue.ReplaceOne(fuelQueue => fuelQueue.Id == id, fuelQueue);
        }

        public void Remove(string id){
            _fuelQueue.DeleteOne(fuelQueue => fuelQueue.Id == id);
        }
    }
}