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

    public ActionResult Index(string DepSearch)
    {
        List<Department> model = _db.Departments.ToList();
        if(DepSearch!=null){
          model = _db.Departments.Where(departments => departments.DepartmentName.Contains(DepSearch)).ToList();
        }
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

      public ActionResult DeleteAll()
        {
            var allDepartments = _db.Departments.ToList();
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
            public ActionResult DeleteAllConfirmed()
        {
            var allDepartments = _db.Departments.ToList();

        foreach (var department in allDepartments)
        {
            _db.Departments.Remove(department);
        }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
  }
}