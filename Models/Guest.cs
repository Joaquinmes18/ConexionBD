using System.ComponentModel.DataAnnotations;

namespace ConexionBD.Models
{
    public class Guest
    {
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        public bool Confirmed { get; set; }
    }
}