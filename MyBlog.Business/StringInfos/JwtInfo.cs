using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost:61968";
        public const string Audience = "http://localhost:5000";
        public const string SecurityKey = "sametirkorenzawxsecdr123";
        public const double Expires = 40;
    }
}
