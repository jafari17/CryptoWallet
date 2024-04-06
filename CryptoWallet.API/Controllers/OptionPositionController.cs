using CryptoWallet.Application.Contracts.Persistence;
 
using CryptoWallet.Application.Services.Option_Position.Commands.Create;
using CryptoWallet.Application.Services.Option_Position.Queries.GetOptionList;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Create;
using CryptoWallet.Application.Services.User.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OptionPositionController : Controller
    {
        private readonly IMediator _mediator;
        public OptionPositionController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> GetOptionPositionList()
        {

            var query = new GetOptionPositionListQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> SavelastOptionPosition()
        {
            var command = new CreateOptionPositionCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
