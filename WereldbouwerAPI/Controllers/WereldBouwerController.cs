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
            return Enumerable.Range(1, 5).Select(index => new WereldBouwer("jeff")
            {
                maxLength = Random.Shared.Next(-20, 55),
                maxHeight = Random.Shared.Next(1, 100)
            })
            .ToArray();
        }

        [HttpPost(Name = "PostWereldBouwer")]
        public ActionResult<WereldBouwer> Post(WereldBouwer wereldBouwer)
        {
            _wereldBouwers.Add(wereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { }, wereldBouwer);
        }

        [HttpPut(Name = "PutWereldBouwer")]
        public ActionResult<WereldBouwer> Put(WereldBouwer wereldBouwer)
        {
            var existingWereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.name == wereldBouwer.name);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            existingWereldBouwer.maxLength = wereldBouwer.maxLength;
            existingWereldBouwer.maxHeight = wereldBouwer.maxHeight;
            return CreatedAtRoute("GetWereldBouwer", new { }, existingWereldBouwer);
        }

        [HttpDelete(Name = "DeleteWereldBouwer")]
        public ActionResult Delete(string name)
        {
            var existingWereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.name == name);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            _wereldBouwers.Remove(existingWereldBouwer);
            return NoContent();
        }
    }
}
