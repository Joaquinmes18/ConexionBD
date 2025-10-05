using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateEventDto
    {
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        // Usa tu zona si quieres; aquí validaremos lógica en el Service
        [Required]
        public DateTime Date { get; set; }

        [Range(1, 100000)]
        public int Capacity { get; set; }
    }
}
