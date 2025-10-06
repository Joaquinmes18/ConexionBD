using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repo;

        public GuestService(IGuestRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guest> Create(CreateGuestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new InvalidOperationException("FullName is required.");

            var guest = new Guest
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName.Trim(),
                Confirmed = dto.Confirmed
            };

            await _repo.Add(guest);
            return guest;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing is null) return false;

            await _repo.Delete(id);
            return true;
        }

        public Task<IEnumerable<Guest>> GetAll() => _repo.GetAll();

        public Task<Guest?> GetById(Guid id) => _repo.GetById(id);
    }
}