using System;
using System.Linq;
using JustTradeIt.Software.API.Models.Dtos;
using JustTradeIt.Software.API.Models.Entities;
using JustTradeIt.Software.API.Models.InputModels;
using JustTradeIt.Software.API.Repositories.Contexts;
using JustTradeIt.Software.API.Repositories.Interfaces;
using JustTradeIt.Software.API.Repositories.Helpers;


namespace JustTradeIt.Software.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly JustTradeItDbContext _dbContext;
        private const string _salt = "randomSalt";

        public UserRepository(JustTradeItDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserDto AuthenticateUser(LoginInputModel input)
        {
            var user = _dbContext.Users.FirstOrDefault(u =>
                u.Email == input.Email && u.HashedPassword == HashHelper.HashPassword(input.Password, _salt));
            if (user == null)
            {
                return null;
            }

            var token = new JwtToken();
            _dbContext.JwtTokens.Add(token);
            _dbContext.SaveChanges();
            
            return new UserDto
            {
                Identifier  = user.PublicIdentifier, //fucked here
                Email = user.Email,
                FullName = user.FullName,
                ProfileImageUrl = user.ProfileImageUrl,
                TokenId = token.Id
            };
        }

        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            var nextId = _dbContext.Users.Select(r => r.Id).Max() + 1;
            var entity = new User
            {
                Id = nextId,
                PublicIdentifier = Guid.NewGuid().ToString(),
                FullName = inputModel.FullName,
                Email = inputModel.Email,
                ProfileImageUrl = "www.google.com/photo",
                HashedPassword = inputModel.Password,
                
            };
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return new UserDto()
            {
                Identifier = entity.PublicIdentifier,
                FullName = entity.FullName,
                Email = entity.Email,
                ProfileImageUrl = entity.ProfileImageUrl,
                TokenId = entity.Id
            };
            
        }

        public UserDto GetProfileInformation(string email)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserInformation(string userIdentifier)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(string email, string profileImageUrl, ProfileInputModel profile)
        {
            throw new NotImplementedException();
        }
        /*{
            var entity = _dbContext.Users.FirstOrDefault(a => a.Email == email);
            if (entity == null)
            {
                return;
            }
            entity.Email = profile.
        }*/
    }
}