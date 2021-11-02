﻿using System.Collections;
using System.Collections.Generic;

namespace JustTradeIt.Software.API.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string PublicIdentifier { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string HashedPassword { get; set; }
        //Navigation
        public ICollection<Item> Items { get; set; }
        public ICollection<TradeItem> TradeItems { get; set; }
        public virtual ICollection<Trade> SentTrades { get; set; }
        public virtual ICollection<Trade> ReceivedTrades { get; set; }
    }
}