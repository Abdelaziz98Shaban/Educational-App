using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniAppDay2.Models;
using UniAppDay2.ViewModel;

namespace UniAppDay2.Controllers
{
    public class TraineeController : Controller
    {
        UNIEntities context = new UNIEntities();
        public IActionResult Index(int id )
        {
            var csharp = 1;
            var courseRes = context.CourseResult.Include(t => t.Trainee).Include(crs => crs.Course).FirstOrDefault(
                res=> res.traineeId == id && res.courseId == csharp
                );

            var TraineeDeg = new TraineeCourseResultViewModel()
            {
                TraineeName = courseRes.Trainee.traineeName,
                CoureName = courseRes.Course.name,
                TraineeDegree = courseRes.degree,
                Color = courseRes.degree >= courseRes.Course.minDegree ? "green" : "red",
            };
            return View("EvaluationView",TraineeDeg);
        }
    }
}
