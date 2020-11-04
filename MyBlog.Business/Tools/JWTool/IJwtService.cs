using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.Tools.JWTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
