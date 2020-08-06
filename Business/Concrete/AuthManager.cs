using Business.Abstract;
using Business.Contants;
using Core.Results;
using Core.Security;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthManager
    {
        private IUserManager _userManager;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserManager userManager, ITokenHelper tokenHelper)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userManager.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new DataResult<AccessToken>(accessToken, true, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var user = _userManager.GetByMail(userLoginDto.Email);

            if(user == null)
            {
                return new DataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPassword(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new DataResult<User>(Messages.PasswordError);
            }

            return new DataResult<User>(user, true, Messages.LoginOk);
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userManager.Add(user);
            return new DataResult<User>(user, true, Messages.RegisterOk);
        }

        public IResult UserExists(string email)
        {
            if(_userManager.GetByMail(email) != null)
            {
                return new Result(false,Messages.UserAlreadyExists);
            }
            return new Result(true);
        }
    }
}
