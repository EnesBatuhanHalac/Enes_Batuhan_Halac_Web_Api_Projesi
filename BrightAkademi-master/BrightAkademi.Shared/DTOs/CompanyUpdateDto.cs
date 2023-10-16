namespace BrightAkademi.Shared.DTOs
{
    public class CompanyUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? About { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FAQ { get; set; } //Frequently Asked Questions
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }
        public List<CourseDto>? CourseDtos { get; set; }
    }
}
