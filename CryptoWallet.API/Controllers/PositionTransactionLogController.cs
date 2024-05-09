using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Create;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Update;
using CryptoWallet.Application.Services.Position_TransactionLog.Queries.GETPositionTransactionLogList;
using CryptoWallet.Application.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> GetPositionTransactionLogList( )
        {
            var query = new GETPositionTransactionLogListQuery();
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

        [HttpPost]
        public async Task<IActionResult> UpdateOptionPosition(DescriptionDto model )
        {
            var command = new UpdateOptionPositionCommand(model.ID, model.Description);
            var response = await _mediator.Send(command);
            Console.WriteLine(response);
            return Ok(response);
        }
    }
}
