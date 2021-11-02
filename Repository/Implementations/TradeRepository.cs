using System;
using System.Collections.Generic;
using System.Linq;
using JustTradeIt.Software.API.Models.Dtos;
using JustTradeIt.Software.API.Models.Entities;
using JustTradeIt.Software.API.Models.InputModels;
using JustTradeIt.Software.API.Repositories.Contexts;
using JustTradeIt.Software.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustTradeIt.Software.API.Repositories.Implementations
{
    public class TradeRepository : ITradeRepository
    {
        private readonly JustTradeItDbContext _dbContext;

        public TradeRepository(JustTradeItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CreateTradeRequest(string email, TradeInputModel trade)
        {
            throw new NotImplementedException();
        }

        public TradeDetailsDto GetTradeByIdentifier(string identifier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TradeDto> GetTradeRequests(string email, bool onlyIncludeActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TradeDto> GetTrades(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TradeDto> GetUserTrades(string userIdentifier)
        {
            throw new NotImplementedException();
        }

        public TradeDetailsDto UpdateTradeRequest(string email, string identifier, Models.Enums.TradeStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}