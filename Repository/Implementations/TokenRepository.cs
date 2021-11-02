using System.Linq;
using JustTradeIt.Software.API.Models.Entities;
using JustTradeIt.Software.API.Repositories.Contexts;
using JustTradeIt.Software.API.Repositories.Interfaces;

namespace JustTradeIt.Software.API.Repositories.Implementations
{
    
    public class TokenRepository : ITokenRepository
    {
        private readonly JustTradeItDbContext _dbContext;

        public TokenRepository(JustTradeItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JwtToken CreateNewToken()
        {
            throw new System.NotImplementedException();
        }

        public bool IsTokenBlacklisted(int tokenId)
        {
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if (token == null)
            {
                return true;
            }

            return token.Blacklisted;
        }

        public void VoidToken(int tokenId)
        {
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if (token == null)
            {
                return;
            }

            token.Blacklisted = true;
            _dbContext.SaveChanges();
        }
    }
}