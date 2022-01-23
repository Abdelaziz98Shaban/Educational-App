using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UniAppDay2.Models
{
    public class Department
    {
        public int Id { get; set; }


        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(pattern: "[a-zA-Z ]{3,}",
       ErrorMessage = "name must be at least 3 charcters and should not contain numbers")]
        [Remote(action: "NameExist", controller: "Dept",
          ErrorMessage = "Name Already Exist", AdditionalFields = "Id")]
        public string deptName { get; set; }
        [Display(Name = "Manger Name")]
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(pattern: "[a-zA-Z]{3,}",
     ErrorMessage = "name must be at least 3 charcters and should not caontain numbers")]
        [Remote(action: "NameExist", controller: "Dept",
        ErrorMessage = "Name Already Exist", AdditionalFields = "Id")]
        public string mangerName { get; set; }




    }
}
