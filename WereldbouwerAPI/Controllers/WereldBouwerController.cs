using Microsoft.AspNetCore.Mvc;
using WereldbouwerAPI;

namespace WereldbouwerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WereldBouwerController : ControllerBase
    {
        private List<WereldBouwer> _wereldBouwers = new List<WereldBouwer>();
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
    }
}
