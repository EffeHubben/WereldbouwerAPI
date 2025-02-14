using Microsoft.AspNetCore.Mvc;
using WereldbouwerAPI;
using System.Threading.Tasks;

namespace WereldbouwerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WereldBouwerController : ControllerBase
    {
        private readonly IWereldBouwerRepository _wereldBouwerRepository;
        private readonly ILogger<WereldBouwerController> _logger;
        private static List<WereldBouwer> _wereldBouwers = new List<WereldBouwer>();

        public WereldBouwerController(IWereldBouwerRepository repository, ILogger<WereldBouwerController> logger)
        {
            _wereldBouwerRepository = repository;
            _logger = logger;
        }

        [HttpGet(Name = "GetWereldBouwer")]
        public async Task<ActionResult<IEnumerable<WereldBouwer>>> Get()
        {
            var wereldBouwers = await _wereldBouwerRepository.GetAllAsync();
            return Ok(wereldBouwers);
        }

        [HttpGet("{id}", Name = "GetWereldBouwerById")]
        public async Task<ActionResult<WereldBouwer>> Get(Guid wereldBouwerId)
        {
            var wereldBouwer = await _wereldBouwerRepository.GetByIdAsync(wereldBouwerId);
            _wereldBouwers.Add(wereldBouwer);
            if (wereldBouwer == null)
            {
                return NotFound();
            }
            return Ok(wereldBouwer);
        }

        [HttpPost(Name = "PostWereldBouwer")]
        public async Task<IActionResult> Post(WereldBouwer wereldBouwer)
        {
            wereldBouwer.id = Guid.NewGuid();
            await _wereldBouwerRepository.AddAsync(wereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { id = wereldBouwer.id }, wereldBouwer);
        }


        [HttpPut("{wereldBouwerId}", Name = "PutWereldBouwer")]
        public async Task<ActionResult> Put(Guid wereldBouwerId, WereldBouwer newWereldBouwer)
        {
            var existingWereldBouwer = await _wereldBouwerRepository.GetByIdAsync(wereldBouwerId);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            newWereldBouwer.id = wereldBouwerId;
            await _wereldBouwerRepository.UpdateAsync(newWereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { id = newWereldBouwer.id }, newWereldBouwer);
        }


        [HttpDelete("{wereldBouwerId}", Name = "DeleteWereldBouwer")]
        public async Task<IActionResult> Delete(Guid wereldBouwerId)
        {
            var existingWereldBouwer = await _wereldBouwerRepository.GetByIdAsync(wereldBouwerId);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }

            await _wereldBouwerRepository.DeleteAsync(wereldBouwerId);
            return Ok(wereldBouwerId);
        }
    }
}
