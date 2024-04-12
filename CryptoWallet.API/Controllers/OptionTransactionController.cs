using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Create;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Queries.GetOptionTransactionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OptionTransactionController : Controller
    {
        private readonly IMediator _mediator;

        public OptionTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SavelastOptionTransaction()
        {

            var command = new CreateOptionTransactionCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetOptionTransaction()
        {

            var query = new GetOptionTransactionListQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

 
    }
}
