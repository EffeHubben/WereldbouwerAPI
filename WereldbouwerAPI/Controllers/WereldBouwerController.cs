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

        public WereldBouwerController(IWereldBouwerRepository repository, ILogger<WereldBouwerController> logger)
        {
            _wereldBouwerRepository = repository;
            _logger = logger;
        }

        [HttpGet(Name = "GetWereldBouwer")]
        public async Task<IEnumerable<WereldBouwer>> Get()
        {
            return await _wereldBouwerRepository.GetAllAsync();
        }

        [HttpPost(Name = "PostWereldBouwer")]
        public async Task<ActionResult<WereldBouwer>> Post(WereldBouwer wereldBouwer)
        {
            await _wereldBouwerRepository.AddAsync(wereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { id = wereldBouwer.id }, wereldBouwer);
        }

        [HttpPut(Name = "PutWereldBouwer")]
        public async Task<ActionResult<WereldBouwer>> Put(WereldBouwer wereldBouwer)
        {
            var existingWereldBouwer = await _wereldBouwerRepository.GetByIdAsync(wereldBouwer.id);
            if (existingWereldBouwer == null)
            {
                return NotFound();
            }
            await _wereldBouwerRepository.UpdateAsync(wereldBouwer);
            return CreatedAtRoute("GetWereldBouwer", new { id = wereldBouwer.id }, wereldBouwer);
        }

        [HttpDelete("{id}", Name = "DeleteWereldBouwer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var wereldBouwer = await _wereldBouwerRepository.GetByIdAsync(id);
            if (wereldBouwer == null)
            {
                return NotFound();
            }

            await _wereldBouwerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
