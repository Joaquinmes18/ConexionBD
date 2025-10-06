using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IGuestService
    {
        Task<Guest> Create(CreateGuestDto dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
    }
}