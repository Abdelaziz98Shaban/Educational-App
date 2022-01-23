using System.Collections.Generic;
using System.Linq;
using UniAppDay2.Models;

namespace UniAppDay2.Services
{
    public class CourseRepo : ICourseRepo
    {
        UNIEntities context;
        public CourseRepo(UNIEntities _context)
        {
            context = _context;
        }
        public List<Course> getAll()
        {
            return context.Course.ToList();
        }

        public Course getById(int id)
        {
            return context.Course.FirstOrDefault(course => course.id == id);
        }
        public Course getByName(string name)
        {
            return context.Course.FirstOrDefault(crs => crs.name == name);
        }
        public List<Course> getByDeptId(int deptId)
        {
            return context.Course.Where(ins => ins.deptId == deptId).ToList();
        }

        public int Create(Course Course)
        {
            context.Course.Add(Course);
            return context.SaveChanges();
        }

        public int Update(int id, Course newCourse)
        {
            Course oldCourse = context.Course.FirstOrDefault(course => course.id == id);
            oldCourse.name = newCourse.name;
            oldCourse.degree = newCourse.degree;
            oldCourse.minDegree = newCourse.minDegree;
            oldCourse.deptId = newCourse.deptId;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.Course.Remove(context.Course.FirstOrDefault(course => course.id == id));
            return context.SaveChanges();
        }
    }
}
