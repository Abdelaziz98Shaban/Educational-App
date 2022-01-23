using System.ComponentModel.DataAnnotations.Schema;

namespace UniAppDay2.Models
{
    public class CourseResult
    {
        public int id { get; set; }
        public int degree { get; set; }


        [ForeignKey("Course")]
        public int courseId { get; set; }

        public Course Course { get; set; } 
        
        [ForeignKey("Trainee")]
        public int traineeId { get; set; }

        public Trainee Trainee { get; set; }
    }
}
