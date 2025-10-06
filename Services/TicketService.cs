using ConexionBD.Models;
using ConexionBD.Models.dtos;
using ConexionBD.Repositories;

namespace ConexionBD.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;
        public TicketService(ITicketService repo) => _repo = repo;

        public async Task<Ticket> Create(CreateTicketDto dto)
        {
            var ticket = new TicketService { Id = Guid.NewGuid(), Notes = dto.Notes };
            await _repo.Add(ticket);
            return ticket;
        }

        public async Task<bool> Delete(Guid id)
        {
            var exists = await _repo.GetById(id);
            if (exists is null) return false;
            await _repo.Delete(id);
            return true;
        }

        public Task<Ienumerable<Ticket>> GetAll() => _repo.GetAll();
        public Task<Ticket?> GetById(Guid id) => _repo.GetById(id);
    }
}