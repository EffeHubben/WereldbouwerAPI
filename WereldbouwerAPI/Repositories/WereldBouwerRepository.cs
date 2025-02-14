using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WereldbouwerAPI
{
    public class WereldBouwerRepository : IWereldBouwerRepository
    {
        private readonly List<WereldBouwer> _wereldBouwers = new List<WereldBouwer>();

        public async Task<IEnumerable<WereldBouwer>> GetAllAsync()
        {
            return await Task.FromResult(_wereldBouwers);
        }

        public async Task<WereldBouwer> GetByIdAsync(Guid id)
        {
            var wereldBouwer = _wereldBouwers.FirstOrDefault(wb => wb.id == id);
            return await Task.FromResult(wereldBouwer);
        }

        public async Task AddAsync(WereldBouwer wereldBouwer)
        {
            wereldBouwer.id = Guid.NewGuid();
            _wereldBouwers.Add(wereldBouwer);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(WereldBouwer wereldBouwer)
        {
            var existingWereldBouwer = await GetByIdAsync(wereldBouwer.id);
            if (existingWereldBouwer != null)
            {
                existingWereldBouwer.name = wereldBouwer.name;
                existingWereldBouwer.maxLength = wereldBouwer.maxLength;
                existingWereldBouwer.maxHeight = wereldBouwer.maxHeight;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var wereldBouwer = await GetByIdAsync(id);
            if (wereldBouwer != null)
            {
                _wereldBouwers.Remove(wereldBouwer);
            }
            await Task.CompletedTask;
        }
    }
}
