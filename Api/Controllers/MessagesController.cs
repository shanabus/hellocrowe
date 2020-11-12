using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloCrowe.Services;

namespace HelloCrowe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {        
        private readonly ILogger<MessagesController> _logger;
        private readonly IMessageService _messageService;

        public MessagesController(ILogger<MessagesController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var message = _messageService.GetMessage();

            return Ok(message);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string message)
        {
            _messageService.SendMessage(message);

            return Ok();
        }
    }
}
