using CryptoWallet.Application.Services.Option_Position.Queries.GetOptionList;
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


        [HttpGet]
        public async Task<IActionResult> GetPositionTransactionLogList()
        {
            var query = new GETPositionTransactionLogListQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

    }
}
