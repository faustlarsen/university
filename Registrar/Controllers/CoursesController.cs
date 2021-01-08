using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly RegistrarContext _db;

    public CoursesController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index(string CourseSearch)
    {
      List<Course> model = _db.Courses.ToList();
      if(CourseSearch!=null){
          model = _db.Courses.Where(courses => courses.CourseName.Contains(CourseSearch)).ToList();
        }
      return View(model);
    }

    public ActionResult Create()
    {

      // if(department==null){
      // return View()
      //   } else {
      //   _db.Departments.Add(department);
      //   _db.SaveChanges();
      //   }
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCourse = _db.Courses
        .Include(course => course.Students)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    public ActionResult Edit(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddStudent(int id)
    {
        var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
        ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
        return View(thisCourse);
    }
    [HttpPost]
    public ActionResult AddStudent(Course course, int StudentId)
    {
        if (StudentId != 0)
        {
            _db.CourseStudent.Add(new CourseStudent() { CourseId = course.CourseId, StudentId = StudentId });   
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
        return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
        _db.Courses.Remove(thisCourse);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult DeleteAll()
    {
        var allCourses = _db.Courses.ToList();
        return View();
    }

    [HttpPost, ActionName("DeleteAll")]
        public ActionResult DeleteAllConfirmed()
    {
        var allCourses = _db.Courses.ToList();

    foreach (var course in allCourses)
    {
        _db.Courses.Remove(course);
    }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}