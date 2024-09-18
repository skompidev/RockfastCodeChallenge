using Microsoft.AspNetCore.Mvc;
using Rockfast.Infrastructure.Exceptions;
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

        /// <summary>
        /// Get Todos
        /// </summary>
        /// <returns>Returns list of todos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TodoVM>>> Get()
        {
            try
            {
                this._logger.LogInformation($"Processing Todo {nameof(Get)} request");
                return Ok(await _todoService.Get());
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, ex?.InnerException?.ToString() ?? string.Empty);
            }            
        }

        /// <summary>
        /// Get Todos by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Todo</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TodoVM>>> GetById(int id)
        {
            try
            {
                this._logger.LogInformation($"Processing Todo {nameof(GetById)} request for {id}");
                return Ok(await _todoService.GetById(id));
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, ex?.InnerException?.ToString() ?? string.Empty);
            }            
        }

        /// <summary>
        /// Create a Todo
        /// </summary>
        /// <param name="model">Todo</param>
        /// <returns>todo resource</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoVM>> Post(TodoVM model)
        {
            try
            {
                this._logger.LogInformation($"Processing Todo {nameof(Post)} request for {model}");

                var todo = await _todoService.Post(model);

                this._logger.LogInformation($"Completed Todo {nameof(Post)} request for {todo}");

                return Created($"/todos/{todo.Id}", todo);
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, ex?.InnerException?.ToString() ?? string.Empty);
            }            
        }

        /// <summary>
        /// Updates Todo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoVM>> Put(TodoVM model)
        {
            try
            {
                this._logger.LogInformation($"Processing Todo {nameof(Put)} request for {model}");

                var todo = await _todoService.Put(model);

                this._logger.LogInformation($"Completed Todo {nameof(Put)} request for {model}");

                return Ok(todo);
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, ex?.InnerException?.ToString() ?? string.Empty);
            }            
        }

        /// <summary>
        /// Delete Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                this._logger.LogInformation($"Processing Todo {nameof(Delete)} request for {id}");

                await _todoService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, ex?.InnerException?.ToString() ?? string.Empty);
            }            
        }

        /// <summary>
        /// Get Todos by User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Todos for a User</returns>
        [HttpGet("user/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TodoVM>>> GetByUserId(Guid userId)
        {
            try
            {
                this._logger.LogInformation($"Processing Todo {nameof(GetByUserId)} request for {userId}");

                return Ok(await _todoService.GetByUserId(userId));
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, ex?.InnerException?.ToString() ?? string.Empty);
            }           
        }
    }
}
