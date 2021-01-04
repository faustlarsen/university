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
  }
}