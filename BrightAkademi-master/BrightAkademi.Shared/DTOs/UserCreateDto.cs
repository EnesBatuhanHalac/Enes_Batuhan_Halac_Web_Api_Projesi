namespace BrightAkademi.Shared.DTOs
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }  
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public RoleDto Role { get; set; }
    }     
}
