using Microsoft.AspNetCore.Mvc;
using Rockfast.ServiceInterfaces;
using Rockfast.ViewModels;

namespace Rockfast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private ILogger<TodosController> _logger;
        public TodosController(ITodoService todoService, ILogger<TodosController> logger)
        {
            this._todoService = todoService;
            this._logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TodoVM>>> Get()
        {
            return Ok(await _todoService.Get());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TodoVM>>> GetById(int id)
        {
            return Ok(await _todoService.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoVM>> Post(TodoVM model)
        {
            var todo = await _todoService.Post(model);

            return Created($"/todos/{todo.Id}", todo);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoVM>> Put(TodoVM model)
        {
            var todo = await _todoService.Put(model);

            return Ok(todo);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoService.Delete(id);

            return Ok();
        }
    }
}
