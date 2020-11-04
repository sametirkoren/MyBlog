using MyBlog.Dto.DTOs.AppUserDtos;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser> 
    {
        Task<AppUser> CheckUser(AppUserLoginDto appUserLoginDto);
    }
}
