using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();
        Event? GetById(Guid id);
        Event Create(CreateEventDto dto);
        bool Delete(Guid id);
    }
}
