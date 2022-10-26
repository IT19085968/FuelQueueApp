namespace fuelWebAPI.Models{
    public interface IFuelStationDBSettings{
        string CollectionName {get;set;}
        string DatabaseName {get;set;}
        string ConnectionString {get;set;}
    }
}