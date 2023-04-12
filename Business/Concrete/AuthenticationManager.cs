using Business.Abstract;
using Business.Constants.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Helpers.Concrete.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthenticationManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetOperationClaims(user);

            var token = _tokenHelper.CreateAccessToken(user: user, operationClaims: claims.Data);

            return new SuccessDataResult<AccessToken>(data: token, message: Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);

            if (userToCheck.Data == null)
                return new ErrorDataResult<User>(data: null, message: Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(password: userForLoginDto.Password, passwordHash: userToCheck.Data.PasswordHash, passwordSalt: userToCheck.Data.PasswordSalt))
                return new ErrorDataResult<User>(data: null, message: Messages.UserPasswordError);

            return new SuccessDataResult<User>(data: userToCheck.Data, message: Messages.UserLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordSalt, passwordHash;

            HashingHelper.CreatePasswordHash(password: userForRegisterDto.Password, passwordHash: out passwordHash, passwordSalt: out passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(data: user, message: Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var userToCheck = _userService.GetByMail(email);

            if (userToCheck.Data != null)
                return new ErrorResult(message: Messages.UserAlreadyExists);

            return new SuccessResult();
        }
    }
}
