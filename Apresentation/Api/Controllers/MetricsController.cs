using Api.ModelView;
using Applications.Auth.Queries;
using Applications.Metrics.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/metrics")]

    
    public class MetricsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetricsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        //[Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSalesMetrics()
        {
            var query = new MetricsSalesQuery();

            return Ok(await _mediator.Send(query));
        }
    }
}
