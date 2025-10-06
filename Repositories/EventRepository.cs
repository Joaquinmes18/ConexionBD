using ConexionBD.Models;

namespace ConexionBD.Repositories
{
    public class EventRepository : IEventRepository
    {
        // Simulación “como en clase”: lista en memoria
        private readonly List<Event> _events = new()
        {
            new Event { Id = Guid.NewGuid(), Title = "Neon Party", Date = DateTime.UtcNow.AddMonths(1), Capacity = 300 },
            new Event { Id = Guid.NewGuid(), Title = "Formal Gala", Date = DateTime.UtcNow.AddMonths(2), Capacity = 150 },
            new Event { Id = Guid.NewGuid(), Title = "Halloween Night", Date = DateTime.UtcNow.AddDays(20), Capacity = 400 }
        };

        public IEnumerable<Event> GetAll() => _events;

        public Event? GetById(Guid id) => _events.FirstOrDefault(e => e.Id == id);

        public void Add(Event ev) => _events.Add(ev);

        public void Delete(Guid id) => _events.RemoveAll(e => e.Id == id);
    }
}
