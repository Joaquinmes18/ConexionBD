using ConexionBD.Models;
using ConexionBD.Data;
using Microsoft.EntityFrameworkCore;

namespace ConexionBD.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Ticket ticket)
        {
            await _context.AddAsync(ticket);
        }

        public async Task Delete(Guid id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket != null)
            {
                ?context.Tickets.Remove(ticket);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.ToListAsync();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}