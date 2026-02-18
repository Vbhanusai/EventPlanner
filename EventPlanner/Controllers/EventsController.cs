using Microsoft.AspNetCore.Mvc;
using EventPlanner.Repositories;

namespace EventPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repo;

        public EventsController(IEventRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<EventItem>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventItem>> GetById(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<EventItem>> Create(EventItem item)
        {
            var created = await _repo.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventItem item)
        {
            if (id != item.Id) return BadRequest();
            var ok = await _repo.UpdateAsync(item);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repo.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
