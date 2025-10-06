using ConexionBD.Models.dtos;
using ConexionBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConexionBD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;

        public EventsController(IEventService service)
        {
            _service = service;
        }

        // GET /api/events
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        // GET /api/events/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetOne(Guid id)
        {
            var ev = _service.GetById(id);
            return ev == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(ev);
        }

        // POST /api/events
        [HttpPost]
        public IActionResult Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ev = _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ev.Id }, ev);
        }

        // DELETE /api/events/{id}
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var ok = _service.Delete(id);
            return ok ? NoContent() : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}
