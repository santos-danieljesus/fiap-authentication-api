using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Template.Application.Commands.Authentication;

namespace Template.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public ILogger<AuthenticationController> Logger;
        public IMediator Mediator;
        public AuthenticationController(ILogger<AuthenticationController> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        [HttpPost]
        [Route("/auth")]
        public async Task<ActionResult> AuthenticateUser([FromBody] AuthenticationRequest request)
        {
            var response = await Mediator.Send(request);

            if (!string.IsNullOrEmpty(response.Token))
            {
                return Ok(response);
            }

            return Unauthorized();
        }
    }
}