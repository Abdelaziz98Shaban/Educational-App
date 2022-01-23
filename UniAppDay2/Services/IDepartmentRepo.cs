using System.Collections.Generic;
using UniAppDay2.Models;

namespace UniAppDay2.Services
{
    public interface IDepartmentRepo
    {
        int Create(Department Department);
        int Delete(int id);
        List<Department> getAll();
        Department getById(int id);
        Department getByName(string name);

        int Update(int id, Department Department);
    }
}