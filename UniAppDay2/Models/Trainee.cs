using System.ComponentModel.DataAnnotations.Schema;

namespace UniAppDay2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string traineeName { get; set; }
        public string traineeImage { get; set; }
        public int traineeGrade { get; set; }

        public string traineeAddress { get; set; }

        [ForeignKey("Department")]
        public int deptId { get; set; }

        public Department Department { get; set; }
    }
}
