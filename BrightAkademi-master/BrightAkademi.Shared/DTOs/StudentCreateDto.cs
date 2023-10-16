namespace BrightAkademi.Shared.DTOs
{
    public class StudentCreateDto
    {
        public int Id { get; set; }

        public string EducationalStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public UserCreateDto User { get; set; }


    }
}
