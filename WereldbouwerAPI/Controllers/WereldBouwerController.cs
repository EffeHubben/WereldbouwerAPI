using Microsoft.AspNetCore.Mvc;
using WereldbouwerAPI;

namespace WereldbouwerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WereldBouwerController : ControllerBase
    {
        private static List<WereldBouwer> _wereldBouwers = new List<WereldBouwer>();
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
            _wereldBouwer.Id = _nextId++;
            _wereldBouwers.Add(wereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { id = wereldBouwer.Id }, wereldBouwer);
        }

        [HttpPut(Name = "PutWereldBouwer")]
        public ActionResult<WereldBouwer> Put(WereldBouwer wereldBouwer)
        {
            var existingWereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.Id == wereldBouwer.Id);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            existingWereldBouwer.name = wereldBouwer.name;
            existingWereldBouwer.maxLength = wereldBouwer.maxLength;
            existingWereldBouwer.maxHeight = wereldBouwer.maxHeight;
            return CreatedAtRoute("GetWereldBouwer", new { id = existingWereldBouwer.Id }, existingWereldBouwer);
        }

        [HttpDelete(Name = "DeleteWereldBouwer")]
        public ActionResult Delete(string name)
        {
            var existingWereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.Id == id);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            _wereldBouwers.Remove(existingWereldBouwer);
            return NoContent();
        }
    }
}
