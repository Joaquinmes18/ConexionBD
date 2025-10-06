using ConexionBD.Models;
using ConexionBD.Models.dtos;

namespace ConexionBD.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();
        Event? GetById(Guid id);
        Event Create(CreateEventDto dto);
        bool Delete(Guid id);
    }
}
