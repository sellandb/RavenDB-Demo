using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB_Demo
{
    public class Menu
    {
        public Menu()
        {
            Courses = new List<Course>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Course
    {
        public Course()
        {
            Allergenics = new List<string>();
        }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public List<string> Allergenics { get; set; }
    }
}
