namespace BrightAkademi.Shared.DTOs
{
    public class SuperAdminDto
    {
        public int TotalStudent { get; set; } 
        public int TotalCourses { get; set; } 
        public int TotalTeachers { get; set; } 
        public int TotalUsers { get; set; }
        public List<UserDto> LastUsers { get; set; }
    }      
}
