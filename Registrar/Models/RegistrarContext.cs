using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Registrar.Models
{
    public class RegistrarContext : DbContext
    {
        public virtual DbSet <Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <CourseStudent> CourseStudent { get; set; }


        public RegistrarContext(DbContextOptions options) : base(options) { }
    }
}