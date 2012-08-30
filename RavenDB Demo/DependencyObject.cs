using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB_Demo
{
    class DependencyObject
    {
        public string Category { get; set; }
        public string Key { get; set; }
        public string Id { get; set; }
        public int value { get; set; }
        public List<string> Dependants { get; set; }

        public DependencyObject(string category, string name)
        {
            this.Category = category;
            this.Id = name;
            this.Key = this.Category + "." + this.Id;
            this.value = new Random().Next(50);
            Dependants = new List<string>();
        }

        public DependencyObject(string catagory, string name, DependencyObject a, DependencyObject b)
        {
            this.Category = catagory;
            this.Id = name;
            this.Key = catagory + "." + name;
            this.value = a.value + b.value;
            this.Dependants = new List<string> { a.Key, b.Key };
        }

    }
}
