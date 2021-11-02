using JustTradeIt.Software.API.Models.Entities;

namespace JustTradeIt.Software.API.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        JwtToken CreateNewToken();
        bool IsTokenBlacklisted(int tokenId);
        void VoidToken(int tokenId);
    }
}