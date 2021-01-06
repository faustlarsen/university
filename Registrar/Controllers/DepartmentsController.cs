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
        
        _db.Courses.Add(new Course() { CourseId = course.CourseId, DepartmentId = DepartmentId });   
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

  }
}
