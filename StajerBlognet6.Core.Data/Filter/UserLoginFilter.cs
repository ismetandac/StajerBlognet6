using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajerBlognet6.Core.Data.Filter
{
    public class UserLoginFilter
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Message { get; set; }
    }
}
