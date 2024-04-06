using CryptoWallet.Application.Services.User.Commands.Create;
using CryptoWallet.Application.Services.User.Queries.GetUser;
using CryptoWallet.Application.Services.User.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var query = new GetUserListQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {

            //ExchangeDeribitReceive exchangeDeribitReceive = new ExchangeDeribitReceive();

            //exchangeDeribitReceive.GetToken();

            if (userId >= 0)
            {
                var query = new GetUserQuery(userId);
                var response = await _mediator.Send(query);
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand UserModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(UserModel);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
