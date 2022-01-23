using UniAppDay2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using UniAppDay2.Services;

namespace UniAppDay2.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorRepo instructorRepo;
        IDepartmentRepo departmentRepo;
        ICourseRepo courseRepo;

        public InstructorController(IInstructorRepo _instructorRepo, IDepartmentRepo _departmentRepo, ICourseRepo _courseRepo)
        {
            instructorRepo = _instructorRepo;
            departmentRepo = _departmentRepo;
            courseRepo = _courseRepo;
        }
        //Remote Validation
        public IActionResult NameExist(string insName,int Id)
        {
            if (Id == 0)
            {
                Instructor instructor = instructorRepo.getByName(insName);

                if (instructor == null)
                
                    return Json(true);
                else 
                    return Json(false);
            }
            else
            {
                Instructor instructor = instructorRepo.getByName(insName);
                if (instructor == null)
                    return Json(true);
                else
                {
                    if(instructor.Id == Id)
                        return Json(true);
                    else 
                        return Json(false);


                }
            }
        }
            
        //add new instructor
        public IActionResult Add()
        {
            ViewData["depts"] = departmentRepo.getAll(); 
            ViewData["course"] = courseRepo.getAll();
            return View(new Instructor());
        }

        // save new instructor 
        public IActionResult SaveAdd(Instructor newInstructor)
        {
            if (ModelState.IsValid)
            {
                instructorRepo.Create(newInstructor);
                return RedirectToAction("Index");

            }
            ViewData["depts"] = departmentRepo.getAll(); ;
            ViewData["course"] = courseRepo.getAll(); ;
            return View("Add", newInstructor);
        }

        //Edit instructor
        public IActionResult Edit(int id)
        {
            ViewData["depts"] = departmentRepo.getAll(); ;
            ViewData["course"] = courseRepo.getAll(); ;
            return View(instructorRepo.getById(id));
        }

        // edit instructor 
        public IActionResult SaveEdit( int id, Instructor newInstructor)
        {
            if (ModelState.IsValid)
            {

                instructorRepo.Update(id, newInstructor);
                return RedirectToAction("Index");
            }
            
                ViewData["depts"] = departmentRepo.getAll(); 
                ViewData["course"] = courseRepo.getAll(); ;
                return View("Edit", newInstructor);
            

        }

        //delete 
        public IActionResult Delete(int id)
        {
            try
            {
                instructorRepo.Delete(id);
                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("Exception", e.InnerException.Message);
                return View("Index");
            }
        }
        //get one instructor
        public IActionResult GetInstructor(int id)
        {
            return View("instView", instructorRepo.getById(id));
        }

        // get all instructors
        public IActionResult Index()
        {
            return View(instructorRepo.getAll());
        }

        //get instructors in each department
        public IActionResult GetDepartmentInstructors(int deptId)
        {
            ViewData["depts"] = departmentRepo.getById(deptId);

            return PartialView("_DeptInstructors",instructorRepo.getByDeptId(deptId));
        }
          public IActionResult GetCourseInstructor(int courseId)
        {

            return PartialView("_InstructorCard",instructorRepo.getByCourseId(courseId));
        }

    }
}
