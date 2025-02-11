using Microsoft.AspNetCore.Mvc;
using WereldbouwerAPI;

namespace WereldbouwerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WereldBouwerController : ControllerBase
    {
        private static List<WereldBouwer> _wereldBouwers = new List<WereldBouwer>();
        private static int _nextId = 1; // Initialize _nextId
        private readonly ILogger<WereldBouwerController> _logger;

        public WereldBouwerController(ILogger<WereldBouwerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWereldBouwer")]
        public IEnumerable<WereldBouwer> Get()
        {
            return _wereldBouwers;
        }

        [HttpPost(Name = "PostWereldBouwer")]
        public ActionResult<WereldBouwer> Post(WereldBouwer wereldBouwer)
        {
            wereldBouwer.id = _nextId++; // Corrected variable name
            _wereldBouwers.Add(wereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { id = wereldBouwer.id }, wereldBouwer);
        }

        [HttpPut(Name = "PutWereldBouwer")]
        public ActionResult<WereldBouwer> Put(WereldBouwer wereldBouwer)
        {
            var existingWereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.id == wereldBouwer.id);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            existingWereldBouwer.name = wereldBouwer.name;
            existingWereldBouwer.maxLength = wereldBouwer.maxLength;
            existingWereldBouwer.maxHeight = wereldBouwer.maxHeight;
            return CreatedAtRoute("GetWereldBouwer", new { id = existingWereldBouwer.id }, existingWereldBouwer);
        }

        //[HttpDelete("{id}", Name = "DeleteWereldBouwer")]
        //public IActionResult Delete(int id)
        //{
        //    var wereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.id == id);

        //    if (wereldBouwer == null)
        //    {
        //        return NotFound();
        //    }

        //    _wereldBouwers.Remove(wereldBouwer); // Hier wordt de wereldBouwer verwijderd

        //    // Bewaar de wijzigingen (afhankelijk van je databaseprovider)
        //    // Bijvoorbeeld met Entity Framework:

        //    return NoContent();
        //}

        [HttpDelete("{id}", Name = "DeleteWereldBouwer")]
        public IActionResult Delete(int id)
        {
            var wereldBouwerToDelete = _wereldBouwers.FirstOrDefault(wb => wb.id == id);
            if (wereldBouwerToDelete == null)
            {
                return NotFound();
            }

            _wereldBouwers.Remove(wereldBouwerToDelete);
            return NoContent();
        }

    }
}
