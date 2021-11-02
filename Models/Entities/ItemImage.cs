﻿namespace JustTradeIt.Software.API.Models.Entities
{
    public class ItemImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ItemId { get; set; }
        //Navigation
        public Item ItemImgLink { get; set; }
    }
}