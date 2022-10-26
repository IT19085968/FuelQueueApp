using Microsoft.AspNetCore.Mvc;
using fuelWebAPI.Services;
using fuelWebAPI.Models;

namespace fuelWebAPI.Controllers{

[Route("api/[controller]")]
[ApiController]
public class FuelQueueController : ControllerBase
{
    private readonly IFuelQueueService fuelService;
    public FuelQueueController(IFuelQueueService fuelQueueService){
        this.fuelService = fuelQueueService;
    }
    [HttpGet]
    public ActionResult<List<FuelQueue>> Get()
    {
        return fuelService.Get();
    }

    [HttpGet("{id}")]
    public ActionResult<FuelQueue> Get(string id)
    {
        var fuelQueue = fuelService.Get(id);
        
        if(fuelQueue == null){
            return NotFound($"FuelQueue with Id = {id} not found");
        }

        return fuelQueue;
    }

    [HttpPost]
    public ActionResult<FuelQueue> Post([FromBody] FuelQueue fuelQueue)
    {
        fuelService.Create(fuelQueue);

        return CreatedAtAction(nameof(Get), new {id = fuelQueue.Id},fuelQueue);
    }

    [HttpPut("{id}")]
    public ActionResult Put(string id, FuelQueue fuelQueue)
    {
        var fuelQueueExist = fuelService.Get(id);
        
        if(fuelQueueExist == null){
            return NotFound($"FuelQueue with Id = {id} not found");
        }

        fuelService.Update(id, fuelQueue);

        return NoContent();
    }

    [HttpDelete]
    public ActionResult Delete(string id)
    {
        var fuelQueueExist = fuelService.Get(id);
        
        if(fuelQueueExist == null){
            return NotFound($"FuelQueue with Id = {id} not found");
        }

        fuelService.Remove(fuelQueueExist.Id);

        return Ok($"FuelQueue with Id = {id} deleted");
    }
}
}