using System;
using System.Collections;
using System.Collections.Generic;

namespace JustTradeIt.Software.API.Models.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public string PublicIdentifier { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string TradeStatus { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        //Navigation
        public User SenderFk { get; set; }
        public User ReceiverFk { get; set; }
        public ICollection<TradeItem> TradeItems { get; set; }
    }
}