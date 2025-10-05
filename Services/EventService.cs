using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Event> GetAll() => _repo.GetAll();

        public Event? GetById(Guid id) => _repo.GetById(id);

        public Event Create(CreateEventDto dto)
        {
            // Validaciones de dominio (como en tu BookService)
            if (dto.Date <= DateTime.UtcNow.Date)
                throw new InvalidOperationException("Date must be in the future.");

            if (dto.Capacity < 1)
                throw new InvalidOperationException("Capacity must be a positive number.");

            var ev = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date = dto.Date,
                Capacity = dto.Capacity
            };

            _repo.Add(ev);
            return ev;
        }

        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            _repo.Delete(id);
            return true;
        }
    }
}
