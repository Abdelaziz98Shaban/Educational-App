using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniAppDay2.Models
{
    public class Instructor
    {
      //  [Key]
        public int Id { get; set; }


        [Display(Name = "Instructor Name")]
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(pattern: "[a-zA-Z]{3,}",
         ErrorMessage = "name must be at least 3 charcters and should not caontain numbers")]
        [Remote(action:"NameExist" , controller:"Instructor",
            ErrorMessage ="Name Already Exist",AdditionalFields = "Id")]
        public string insName { get; set; }



        [Display(Name = "Instructor Image")]
        [Required(ErrorMessage = "Insert your image please")]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image must contain jpg or png ")]

        // [FileExtensions]


        public string insImage { get; set; }




        [Display(Name = "Instructor Salary")]
        [Required(ErrorMessage = "Salary Is Required")]
        [Range(minimum: 2000, maximum: 30000000000)]
        public int insSalary { get; set; }





        [Display(Name = "Instructor Address")]
        [Required(ErrorMessage = "Insert Address")]
        [MaxLength(50)]
        [RangeAdress]
        public  string insAddress { get; set; }





        [Display(Name = "Instructor Department")]
        [ForeignKey("Department")]
        public int deptId { get; set; }



        public Department Department { get; set; }


        
        [Display(Name = "Instructor Course")]
        [ForeignKey("Course")]
        public int courseId { get; set; }

        public Course Course { get; set; }


    }
}
