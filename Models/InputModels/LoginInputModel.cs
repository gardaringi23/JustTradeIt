namespace JustTradeIt.Software.API.Models.InputModels
{
    public class LoginInputModel
    {
        public string Email { get; set; } //should be in valid email form
        public string Password { get; set; } // min length of 8
    }
}