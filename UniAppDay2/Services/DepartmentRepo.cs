using System.Collections.Generic;
using System.Linq;
using UniAppDay2.Models;


namespace UniAppDay2.Services
{
    public class DepartmentRepo : IDepartmentRepo
    {

        UNIEntities context;
        public DepartmentRepo(UNIEntities _context)
        {
            context = _context;
        }
        public List<Department> getAll()
        {
            return context.Department.ToList();
        }

        public Department getById(int id)
        {
            return context.Department.FirstOrDefault(dept => dept.Id == id);
        }

        public Department getByName(string name)
        {
            return context.Department.FirstOrDefault(dept => dept.deptName == name);
        }
        public int Create(Department Department)
        {
            context.Department.Add(Department);
            return context.SaveChanges();
        }

        public int Update(int id, Department Department)
        {
            Department oldDepartment = context.Department.FirstOrDefault(dept => dept.Id == id);
            oldDepartment.deptName = Department.deptName;
            oldDepartment.mangerName = Department.mangerName;

            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.Department.Remove(context.Department.FirstOrDefault(dept => dept.Id == id));
            return context.SaveChanges();
        }
    }
}
