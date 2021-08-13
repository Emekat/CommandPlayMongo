using System.Collections.Generic;
using CommandAPIMongo.Data;
using CommandAPIMongo.Models;
using Microsoft.AspNetCore.Mvc;
namespace CommandAPIMongo.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class CommandsController : ControllerBase
        {
            //Add the following code to our class
            private readonly ICommandAPIRepo _repository;
            public CommandsController(ICommandAPIRepo repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                var commandItems = _repository.GetAllCommands();
                return Ok(commandItems);
            }
            
            //Add the following code for our second ActionResult
            [HttpGet("{id}")]
            public ActionResult<Command> GetCommandById(int id)
            {
                var commandItem = _repository.GetCommandById(id);
                if (commandItem == null)
                {
                    return NotFound();
                }
                return Ok(commandItem);
            }
        }
    
}