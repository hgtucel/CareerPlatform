using Core.Results;
using Core.Security;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto, string password);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);

        IResult UserExists(string email);

    }
}
