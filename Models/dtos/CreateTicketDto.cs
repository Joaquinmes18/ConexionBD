using System.ComponentModel.DataAnnotations;

namespace ConexionBD.Models.dtos
{
    public record CreateTicketDto
    {
        public string[]? Notes { get; set; }
    }
}