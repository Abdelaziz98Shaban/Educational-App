using System.Collections.Generic;
using UniAppDay2.Models;

namespace UniAppDay2.Services
{
    public interface ICourseRepo
    {
        int Create(Course Course);
        int Delete(int id);
        List<Course> getAll();
        Course getById(int id);
        List<Course> getByDeptId(int deptId);

        public Course getByName(string name);
        int Update(int id, Course newCourse);
    }
}