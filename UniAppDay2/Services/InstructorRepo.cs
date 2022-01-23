using System.Collections.Generic;
using System.Linq;
using UniAppDay2.Models;

namespace UniAppDay2.Services
{
    public class InstructorRepo : IInstructorRepo
    {
        UNIEntities context;
        public InstructorRepo(UNIEntities _context)
        {
            context = _context;
        }
        public List<Instructor> getAll()
        {
            return context.Instructor.ToList();
        }

        public Instructor getById(int id)
        {
            return context.Instructor.FirstOrDefault(ins => ins.Id == id);
        }
        public Instructor getByName(string name)
        {
            return context.Instructor.FirstOrDefault(ins => ins.insName == name);
        }
        public List<Instructor> getByDeptId(int deptId)
        {
            return context.Instructor.Where(ins => ins.deptId == deptId).ToList();
        } 
        
        public Instructor getByCourseId(int courseId)
        {
            return context.Instructor.FirstOrDefault(ins => ins.courseId == courseId);
        }

        public int Create(Instructor instructor)
        {
            context.Instructor.Add(instructor);
            return context.SaveChanges();
        }

        public int Update(int id, Instructor instructor)
        {
            Instructor oldInstructor = context.Instructor.FirstOrDefault(ins => ins.Id == id);
            oldInstructor.insName = instructor.insName;
            oldInstructor.insImage = instructor.insImage;
            oldInstructor.insAddress = instructor.insAddress;
            oldInstructor.insSalary = instructor.insSalary;
            oldInstructor.deptId = instructor.deptId;
            oldInstructor.courseId = instructor.courseId;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.Instructor.Remove(context.Instructor.FirstOrDefault(ins => ins.Id == id));
            return context.SaveChanges();
        }
    }
}
