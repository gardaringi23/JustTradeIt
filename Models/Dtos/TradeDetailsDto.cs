﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace JustTradeIt.Software.API.Models.Dtos
{
    public class TradeDetailsDto
    {
        public string Identifier { get; set; }
        public IEnumerable<ItemDto> ReceivingItems { get; set; }
        public IEnumerable<ItemDto> OfferingItems { get; set; }
        public UserDto Receiver { get; set; }
        public UserDto Sender { get; set; }
        public DateTime ReceivedTime { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
    }
}