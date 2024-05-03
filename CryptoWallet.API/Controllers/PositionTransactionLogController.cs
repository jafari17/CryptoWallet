using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Create;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Update;
using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PositionTransactionLogController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOptionPositionRepository _optionPositionRepository;
        public PositionTransactionLogController(IMediator mediator, IOptionPositionRepository optionPositionRepository)
        {
            _mediator = mediator;
            _optionPositionRepository = optionPositionRepository;
        }

        [HttpGet("{lastUpdate}")]
        public async Task<IActionResult> GetPositionTransactionLogList(bool lastUpdate)
        {
            var query = new GETPositionTransactionLogListQuery(lastUpdate);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> SavePositionList()
        {
            var query = new CreateOptionPositionCommand();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOptionPosition(int ID, string Description)
        {
            var command = new UpdateOptionPositionCommand(ID, Description);
            var response = await _mediator.Send(command);
            Console.WriteLine(response);
            return Ok(response);
        }
    }
}
