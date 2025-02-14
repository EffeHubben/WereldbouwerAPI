using System;
using System.Collections.Generic;

namespace WereldbouwerAPI
{
    public interface IWereldBouwerRepository
    {
        Task<IEnumerable<WereldBouwer>> GetAllAsync();
        Task<WereldBouwer> GetByIdAsync(Guid id);
        Task AddAsync(WereldBouwer wereldBouwer);
        Task UpdateAsync(WereldBouwer wereldBouwer);
        Task DeleteAsync(Guid id);
    }
}
