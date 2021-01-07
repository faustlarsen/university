using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly RegistrarContext _db;

    public DepartmentsController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        List<Department> model = _db.Departments.ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Department department)
    {
        _db.Departments.Add(department);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
        List<Course> foundCourses = _db.Courses.Where(course => course.DepartmentId == id).ToList();
        ViewBag.foundCourses = foundCourses;
        return View(thisDepartment);
    }

    public ActionResult Delete(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      _db.Departments.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department)
    {
        _db.Entry(department).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult AddCourse(int id)
    {
        var thisDepartment = _db.Departments.FirstOrDefault(departments => departments.DepartmentId == id);
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
        return View(thisDepartment);
    }
    [HttpPost]
    public ActionResult AddCourse(Course course, int DepartmentId)
    {
        var thisCourse = _db.Courses.FirstOrDefault(element => element.CourseId == course.CourseId);
        thisCourse.DepartmentId = DepartmentId; //line 83 is true/happened
        _db.Courses.Attach(thisCourse); // prepping for a save
        _db.Entry(thisCourse).Property(element => element.DepartmentId).IsModified = true; // edit modification to db from line 83
        // _db.Entry(thisCourse).State = EntityState.Modified; //not needed
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // [HttpPost]
    // public ActionResult Edit(Item item)
    // {
    //   _db.Entry(item).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult Create(Student student, int CourseId)
    // {
    //     _db.Students.Add(student);
    //     if (CourseId != 0)
    //     {
              // var thisCourseStudent = _db.CourseStudent.FirstOrDefault(courseStudent => courseStudent.CourseId == CourseId); // needs another condition to check if it has a student associated
              // if (thisCourse )
              // {
              //   _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId});
              // } else {
              //   ViewBag.CourseStudentExists = "That course already belongs to this student.";
              //   return View("CourseStudentExists")
              //
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }

    // In your view:
    // @{
    //   Timer timer = new Timer();
    //   timer.interval = 1000; //1sec
    //   time.Start();
    //   while(timer > 5000)
    //   {
    //     RedirectAction
    //   }
    //  }
  }
}