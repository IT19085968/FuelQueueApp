using fuelWebAPI.Models;

namespace fuelWebAPI.Services{
    public interface IFuelQueueService{
        List<FuelQueue> Get();
        FuelQueue Get(string id);
        FuelQueue Create(FuelQueue fuelQueue);
        void Update(string id, FuelQueue fuelQueue);
        void Remove(string id);
    }
}