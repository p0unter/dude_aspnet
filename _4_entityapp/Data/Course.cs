using System.ComponentModel.DataAnnotations;

namespace _4_entityapp.Data
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string? CourseTitle { get; set; }
    }
}
