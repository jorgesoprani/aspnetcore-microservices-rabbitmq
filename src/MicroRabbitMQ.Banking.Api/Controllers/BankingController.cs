using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MicroRabbitMQ.Banking.Application.Transfers.Commands.Create;
using MicroRabbitMQ.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Banking.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Account>>> Post([FromBody] CreateTransfer accountTransfer) {
            await Mediator.Send(accountTransfer);
            return Ok();
        }
    }
}
