namespace BrightAkademi.Shared.DTOs
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }

        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public List<CourseDto>? CourseDtos { get; set; }
    }
}
