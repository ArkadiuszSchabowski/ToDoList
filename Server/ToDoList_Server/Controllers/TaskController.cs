using Microsoft.AspNetCore.Mvc;
using ToDoList_Server.Interfaces.Aggregates;
using ToDoList_Server.Models;
using ToDoList_Server.Models.Pagination;

namespace ToDoList_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskAggregateService _service;

        public TaskController(ITaskAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResult<GetTaskDto>>> Get([FromQuery] PaginationDto dto)
        {
            var result = await _service.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddTaskDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateTaskStatusDto dto, [FromRoute] int id)
        {
            await _service.UpdateTaskStatusAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }
    }
}
