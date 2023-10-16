using BrightWeb.Entity.Concrete;

namespace BrightAkademi.Entity.Concrete
{
    public class Level
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public List<Course>? Courses { get; set; }
    }
}
