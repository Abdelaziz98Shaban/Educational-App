using UniAppDay2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UniAppDay2.Services;
using System;

namespace Day1.Controllers
{
    public class DeptController : Controller
    {


        IDepartmentRepo departmentRepo;

        public DeptController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }
        public IActionResult NameExist(string deptName, int Id)
        {
            if (Id == 0)
            {
                Department instructor = departmentRepo.getByName(deptName);

                if (instructor == null)

                    return Json(true);
                else
                    return Json(false);
            }
            else
            {
                Department instructor = departmentRepo.getByName(deptName);
                if (instructor == null)
                    return Json(true);
                else
                {
                    if (instructor.Id == Id)
                        return Json(true);
                    else
                        return Json(false);


                }
            }
        }

        //add new department
        public IActionResult Add()
        {
            
            return View(new Department());
        }

        // save new instructor 
        public IActionResult SaveAdd(Department newDepartment)
        {
            if (ModelState.IsValid)
            {
                departmentRepo.Create(newDepartment);
                return RedirectToAction("Index");

            }
            return View("Add", newDepartment);
        }
        //Edit instructor
        public IActionResult Edit(int id)
        {
          
            return View(departmentRepo.getById(id));
        }

        // edit instructor 
        public IActionResult SaveEdit( int id, Department newDepartment)
        {
            if (ModelState.IsValid)
            {

                departmentRepo.Update(id, newDepartment);
                return RedirectToAction("Index");
            }
            return View("Edit", newDepartment);


        }

        //delete 
        public IActionResult Delete(int id)
        {
            try
            {
                departmentRepo.Delete(id);
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
                
            return View(departmentRepo.getAll());
        }
    }
}
