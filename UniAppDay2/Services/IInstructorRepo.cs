using System.Collections.Generic;
using UniAppDay2.Models;

namespace UniAppDay2.Services
{
    public interface IInstructorRepo
    {
        int Create(Instructor instructor);
        int Delete(int id);
        List<Instructor> getAll();
        List<Instructor> getByDeptId(int deptId);
        Instructor getByCourseId(int courseId);
        Instructor getById(int id);
        Instructor getByName(string name);
        int Update(int id, Instructor instructor);
    }
}