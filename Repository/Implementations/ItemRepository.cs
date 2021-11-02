using System;
using System.Linq;
using JustTradeIt.Software.API.Models;
using JustTradeIt.Software.API.Models.Dtos;
using JustTradeIt.Software.API.Models.InputModels;
using JustTradeIt.Software.API.Repositories.Contexts;
using JustTradeIt.Software.API.Repositories.Interfaces;

namespace JustTradeIt.Software.API.Repositories.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly JustTradeItDbContext _dbContext;

        public ItemRepository(JustTradeItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddNewItem(string email, ItemInputModel item)
        {
            throw new NotImplementedException();
        }

        public Envelope<ItemDto> GetAllItems(int pageSize, int pageNumber, bool ascendingSortOrder)
        {
            throw new NotImplementedException();
        }

        public ItemDetailsDto GetItemByIdentifier(string identifier)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string email, string identifier)
        {
            throw new NotImplementedException();
        }
    }
}