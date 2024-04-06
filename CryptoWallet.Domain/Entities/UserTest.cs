using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Entities
{
    public class UserTest
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
    }
}
