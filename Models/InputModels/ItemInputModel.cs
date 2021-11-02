using System.Collections;
using System.Collections.Generic;

namespace JustTradeIt.Software.API.Models.InputModels
{
    public class ItemInputModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ConditionCode { get; set; } //must be a valid condition code: MINT, GOOD, USED, BAD OR DAMAGED
        public IEnumerable<string> ItemImages { get; set; } //Should be a list of URLs of images
    }
}