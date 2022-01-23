using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniAppDay2.Models
{
    public class Course
    {
        public int id { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(pattern: "[a-zA-Z ]{3,}",
        ErrorMessage = "name must be at least 3 charcters and should not caontain numbers")]
        [Remote(action: "NameExist", controller: "Instructor",
           ErrorMessage = "Name Already Exist", AdditionalFields = "Id")]
        public string name { get; set; }

        [Display(Name = "Degree")]

        [Required(ErrorMessage = "Degree Is Required")]
        [Range(minimum: 50, maximum: 200)]
        public int degree { get; set; }

        [Required(ErrorMessage = "Minimum Degree Is Required")]
        [Range(minimum: 0, maximum: 200)]
        [Display(Name = "Minimum Degree")]

        public int minDegree { get; set; }

        [Display(Name ="Department")]

        [ForeignKey("Department")]
        public int deptId { get; set; }

        public Department Department { get; set; }

    }
}
