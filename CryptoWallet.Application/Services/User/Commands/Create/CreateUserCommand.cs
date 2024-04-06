using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Commands.Create
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
    }
}
