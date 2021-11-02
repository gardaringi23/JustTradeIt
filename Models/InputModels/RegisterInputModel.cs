namespace JustTradeIt.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        public string Email { get; set; } // should be in valid email form
        public string FullName { get; set; } //min length of 3
        public string Password { get; set; } //min length of 8
        public string PasswordConfirmation { get; set; } //min length of 8. must equal to PasswordField within same class

    }
}