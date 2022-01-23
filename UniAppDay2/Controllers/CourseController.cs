using Microsoft.AspNetCore.Mvc;
using System;
using UniAppDay2.Models;
using UniAppDay2.Services;

namespace UniAppDay2.Controllers
{
    public class CourseController : Controller
    {

        ICourseRepo courseRepo;
        IDepartmentRepo departmentRepo;

        public CourseController(ICourseRepo _courseRepo, IDepartmentRepo _departmentRepo)
        {
            courseRepo = _courseRepo;
             departmentRepo = _departmentRepo;

        }
        public IActionResult NameExist(string courseName, int Id)
        {
            Course course;
            if (Id == 0)
            {
                 course = courseRepo.getByName(courseName);

                if (course == null)

                    return Json(true);
                else
                    return Json(false);
            }
            else
            {
                 course = courseRepo.getByName(courseName);
                if (course == null)
                    return Json(true);
                else
                {
                    if (course.id == Id)
                        return Json(true);
                    else
                        return Json(false);


                }
            }
        }

        //add new department
        public IActionResult Add()
        {
            ViewData["depts"] = departmentRepo.getAll();
            return View(new Course());
        }

        // save new instructor 
        public IActionResult SaveAdd(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Create(newCourse);
                return RedirectToAction("Index");

            }
            ViewData["depts"] = departmentRepo.getAll();
            return View("Add", newCourse);
        }
        //Edit instructor
        public IActionResult Edit(int id)
        {
            ViewData["depts"] = departmentRepo.getAll();

            return View(courseRepo.getById(id));
        }

        // edit instructor 
        public IActionResult SaveEdit(int id, Course newCourse)
        {
            if (ModelState.IsValid)
            {

                courseRepo.Update(id, newCourse);
                return RedirectToAction("Index");
            }
            ViewData["depts"] = departmentRepo.getAll();
            return View("Edit", newCourse);


        }

        //delete 
        public IActionResult Delete(int id)
        {
            try
            {
                courseRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Exception", e.InnerException.Message);
                return View("Index");
            }
        }
        public IActionResult Index()
        {

            return View(courseRepo.getAll());
        }

       
    }
}
