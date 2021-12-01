using System.Threading.Tasks;
using MediatR;
using MicroRabbitMQ.Banking.Application.Account.Commands.Create;
using MicroRabbitMQ.Banking.Application.Account.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Banking.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public AccountController() {
        }

        [HttpGet]
        public async Task<ActionResult<AllAccountsView>> GetAll() {
            var result = await Mediator.Send(new GetAllAccounts());

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AllAccountsView>> Create([FromBody] CreateAccount command) {
            var result = await Mediator.Send(command);
            return Ok();
        }
    }
}
