using System.ComponentModel.DataAnnotations;

namespace ConexionBD.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string[]? Notes {  get; set; }
    }
}