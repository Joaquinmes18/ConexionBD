using ConexionBD.Models;

namespace ConexionBD.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event? GetById(Guid id);
        void Add(Event ev);
        void Delete(Guid id);
    }
}
