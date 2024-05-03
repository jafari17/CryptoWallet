using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Option_Transaction.Commands.Update
{
    public class UpdateOptionTransactionCommand : IRequest<bool>
    {
        public int   OptionTransactionId  { get; set; }
        public string Description { get; set; }

        public UpdateOptionTransactionCommand(int optionTransactionId , string description)
        {
            OptionTransactionId = optionTransactionId;
            Description = description;
            
        }
    }
}
