using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rockfast.ServiceInterfaces;
using Rockfast.ViewModels;

namespace Rockfast.API.Controllers
{
    [Route("[controller]")]
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
        public async Task<IEnumerable<TodoVM>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<TodoVM> Post(TodoVM model)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<TodoVM> Put(TodoVM model)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
