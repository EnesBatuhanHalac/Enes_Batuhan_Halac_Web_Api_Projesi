namespace BrightAkademi.Shared.DTOs
{
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }     
    
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }   
}
