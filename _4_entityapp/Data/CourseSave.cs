using System.ComponentModel.DataAnnotations;

namespace _4_entityapp.Data
{
    public class CourseSave
    {
        [Key]
        public int SaveId { get; set; }

        public int StudentId { get; set; }
        
        public int CourseId { get; set; }

        public DateTime SaveDate { get; set; }
    }
}
