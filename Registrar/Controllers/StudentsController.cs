using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
    public class StudentsController : Controller
    {
      private readonly RegistrarContext _db;

      public StudentsController(RegistrarContext db)
      {
          _db = db;
      }

      public ActionResult Index()
      {
          return View(_db.Students.ToList());
      }

      public ActionResult Details(int id)
      {
          var thisStudent = _db.Students
          .Include(student => student.Courses)
          .ThenInclude(join=>join.Course)
          .FirstOrDefault(student=>student.StudentId==id);
          return View(thisStudent);
      }

      public ActionResult Create()
      {
          ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
          return View();
      }
      [HttpPost]
      public ActionResult Create(Student student, int CourseId)
      {
          _db.Students.Add(student);
          if (CourseId != 0)
          {
              _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId});
          }
          _db.SaveChanges();
          return RedirectToAction("Index");
      }

      public ActionResult Edit(int id)
      {
          var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
          ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
          return View(thisStudent);
      }

      [HttpPost]
      public ActionResult Edit(Student student)
      {
          _db.Entry(student).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
          var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
          return View(thisStudent);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult Deleteconfirmed(int id)
      {
          var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
          _db.Students.Remove(thisStudent);
          _db.SaveChanges();
          return RedirectToAction("Index");
      }
      
      public ActionResult AddCourse(int id)
      {
          var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
          ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
          return View(thisStudent);
      }
      [HttpPost]
      public ActionResult AddCourse(Student student, int CourseId)
      {
          if (CourseId != 0)
          {
              _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });   
          }
          _db.SaveChanges();
          return RedirectToAction("index");
      }

      [HttpPost]
      public ActionResult DeleteCourse(int joinId)
      {
        var joinEntry = _db.CourseStudent.FirstOrDefault(entry=>entry.CourseStudentId == joinId);
        _db.CourseStudent.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }
}