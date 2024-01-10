using Api.ModelView;
using Applications.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;


        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Post([FromBody] LoginModel model)
        {
            var query = new AuthQuery(model.Login, model.Password);

            return Ok(await _mediator.Send(query));
        }

    }
}
