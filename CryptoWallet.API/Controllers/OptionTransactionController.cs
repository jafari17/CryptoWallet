using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Create;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Update;
using CryptoWallet.Application.Services.Option_Transaction.Queries.GetOptionTransactionList;
using CryptoWallet.Application.ViewModels;
using CryptoWallet.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OptionTransactionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOptionTransactionRepository _optionTransactionRepository;

        public OptionTransactionController(IMediator mediator, IOptionTransactionRepository optionTransactionRepository)
        {
            _mediator = mediator;
            _optionTransactionRepository = optionTransactionRepository;
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


        [HttpPost]
        public async Task<IActionResult> UpdateOptionTransaction(DescriptionDto model)
        {

            var command = new UpdateOptionTransactionCommand(model.ID, model.Description);
            var response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
