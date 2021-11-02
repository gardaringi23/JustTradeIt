using Microsoft.AspNetCore.Http;

namespace JustTradeIt.Software.API.Models.InputModels
{
    public class ProfileInputModel
    {
        public string FullName { get; set; } // min length of 3
        public IFormFile ProfileImage { get; set; } // an image file (see uploading an image for reference)
    }
}