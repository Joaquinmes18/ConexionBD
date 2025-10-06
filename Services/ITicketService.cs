using ConexionBD.Models;
using ConexionBD.Models.dtos;

namespace ConexionBD.Services
{
    public interface ITicketService
    {
        Task<Ticket> Create(CreateBookDto dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Ticket>> GetAll();
        Task<ITicketService?> GetById(Guid id);
    }
}