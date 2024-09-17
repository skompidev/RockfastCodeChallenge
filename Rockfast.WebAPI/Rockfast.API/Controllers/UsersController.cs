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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserVM>>> Get()
        {
            return Ok(await _userService.Get());
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetById(Guid id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserVM>> Post(UserVM model)
        {
            var user = await _userService.Post(model);

            return Created($"/users/{user.Id}", user);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVM>> Put(UserVM model)
        {
            var user = await _userService.Put(model);

            return Ok(user);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _userService.Delete(id);

            return Ok();
        }
    }
}
