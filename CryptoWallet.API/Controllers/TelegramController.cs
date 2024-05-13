using CryptoWallet.API.Notification;
using CryptoWallet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TelegramController : Controller
    {
        private readonly ExchangeProvider _ExchangeProvider;
        public TelegramController(ExchangeProvider ExchangeProvider)
        {
            _ExchangeProvider = ExchangeProvider;
        }

        [HttpGet]
        public async Task<IActionResult> AutoMessage()
        {
            _ExchangeProvider.AutoMessage();

            return View();
        }
    }
}
