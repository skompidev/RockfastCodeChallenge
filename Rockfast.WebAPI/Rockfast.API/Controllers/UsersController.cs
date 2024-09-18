using Microsoft.AspNetCore.Mvc;
using Rockfast.ServiceInterfaces;
using Rockfast.ViewModels;

namespace Rockfast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private ILogger<UsersController> _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            this._userService = userService;
            this._logger = logger;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>list of users</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserVM>>> Get()
        {
            this._logger.LogInformation($"Processing User {nameof(Get)} request");
            return Ok(await _userService.Get());
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetById(Guid id)
        {
            this._logger.LogInformation($"Processing User {nameof(GetById)} request for {id}");

            return Ok(await _userService.GetById(id));
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>user</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserVM>> Post(UserVM model)
        {
            this._logger.LogInformation($"Processing User {nameof(Post)} request for {model}");

            var user = await _userService.Post(model);

            this._logger.LogInformation($"Completed User {nameof(Post)} request for {model}");

            return Created($"/users/{user.Id}", user);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>user</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVM>> Put(UserVM model)
        {
            this._logger.LogInformation($"Processing User {nameof(Put)} request for {model}");

            var user = await _userService.Put(model);

            this._logger.LogInformation($"Completed User {nameof(Put)} request for {model}");

            return Ok(user);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            this._logger.LogInformation($"Processing User {nameof(Delete)} request for {id}");

            await _userService.Delete(id);

            return Ok();
        }
    }
}
