using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using CryptoWallet.Application.Services.Position_TransactionLog.Commands.Create;
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
        public PositionTransactionLogController(IMediator mediator)
        {
            _mediator = mediator;
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

    }
}
