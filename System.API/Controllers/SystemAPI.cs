using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Application.Features.Orders.Commands.CreateOrder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAPI : ControllerBase
    {
        private readonly IMediator _mediator;

        public SystemAPI(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddPatient")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderCommand CreateOrderCommand)
        {
            Guid id = await _mediator.Send(CreateOrderCommand);
            return Ok(id);
        }
    }
}
