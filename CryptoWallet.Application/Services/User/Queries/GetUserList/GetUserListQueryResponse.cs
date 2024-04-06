using CryptoWallet.Application.Services.User.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Application.Services.User.Queries.GetUserList
{
    public class GetUserListQueryResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
    }
}
