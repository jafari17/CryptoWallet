using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.Position_TransactionLog.Commands.Update
{
    public class UpdateOptionPositionCommand : IRequest<bool>
    {
        public int OptionPositionId { get; set; }
        public string Description { get; set; }

        public UpdateOptionPositionCommand(int optionPositionId, string description)
        {
            
            OptionPositionId = optionPositionId;
            Description = description;

        }
    }
}
