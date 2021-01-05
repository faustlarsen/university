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

    public ActionResult Index()
    {
      List<Course> model = _db.Courses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
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
  }
}