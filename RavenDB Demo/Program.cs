using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace RavenDB_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentStore = new DocumentStore { Url = "http://localhost:8080" };
            documentStore.Initialize();

            using (var session = documentStore.OpenSession())
            {

                //Insert Example
                session.Store(new Menu
                {
                    Name = "Breakfast Menu",
                    Courses = {
                        new Course {
                            Name = "Waffle",
                            Cost = 2.3m,
                        },
                        new Course {
                            Name = "Cereal",
                            Cost = 1.3m,
                            Allergenics = {"Peanuts"}
                        },
                        new Course {
                            Name = "Porridge",
                            Cost = 1.7m,
                            Allergenics = {"Wheat", "Peanuts"}
                        }
                    }
                });

                session.Store(new Menu
                {
                    Name = "Lunch Menu",
                    Courses = {
                        new Course {
                            Name = "Sandwich",
                            Cost = 4.5m,
                        },
                        new Course {
                            Name = "Ribs",
                            Cost = 11.3m,
                            Allergenics = {"Pork"}
                        },
                        new Course {
                            Name = "Chicken",
                            Cost = 6.7m,
                            Allergenics = {"Gluten"}
                        }
                    }
                });

                session.Store(new Menu
                {
                    Name = "Dinner Menu",
                    Courses = {
                        new Course {
                            Name = "Pizza",
                            Cost = 5.5m,
                        },
                        new Course {
                            Name = "Soup",
                            Cost = 2.3m,
                        },
                        new Course {
                            Name = "Steak",
                            Cost = 25.5m,
                            Allergenics = {"Peanuts"}
                        }
                    }
                });
                session.SaveChanges();

                //Example 1 (This may not have an accurate ID anymore)
                Console.WriteLine("Example 1");
                var menu1 = session.Load<Menu>("Menus/34");
                DisplayMenu(new List<Menu>() {menu1});

                //Example 2 - Queries
                Console.WriteLine("Query Examples");
                Console.WriteLine("Breakfast Menu");
                var breakFastMenu =
                    from menu in session.Query<Menu>()
                    where menu.Name.StartsWith("Breakfast")
                    select menu;
                DisplayMenu(breakFastMenu);

                Console.WriteLine("Cheap Menus");
                var cheapMenus =
                    from menu in session.Query<Menu>()
                    where menu.Courses.Any(c => c.Cost < 2)
                    select menu;

                DisplayMenu(cheapMenus);

                



            }

            Console.ReadLine();
        }
        static void DisplayMenu(IEnumerable<Menu> menus )
        {
            foreach (Menu m in menus)
            {
                Console.WriteLine(m.Name);
                foreach (var course in m.Courses)
                {
                    Console.WriteLine("\t{0} - {1}", course.Name, course.Cost);
                    Console.WriteLine("\t\t{0}", string.Join(", ", course.Allergenics));
                }
            }
            
        }
    }

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
