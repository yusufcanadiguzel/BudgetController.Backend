using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Concrete
{
    public class AccessToken : IToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
