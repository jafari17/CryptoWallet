using CryptoWallet.Application.Services.Asset_.Commands.Create;
using CryptoWallet.Application.Services.Asset_.Queries.GetAssetList;
using CryptoWallet.Application.Services.Option_Position_History.Commands.Create;
using CryptoWallet.Application.Services.Option_Position_History.Queries.GetOptionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AssetController : Controller
    {

        private readonly IMediator _mediator;
        public AssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SavelastAsset()
        {
            var command = new CreateAssetCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAssetList()
        {

            var query = new GetAssetListQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
