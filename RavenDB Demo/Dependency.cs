using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB_Demo
{
    class Dependency
    {
        static void Main(string[] args)
        {
            var documentStore = new DocumentStore { Url = "http://localhost:8080" };
            documentStore.Initialize();

        }

        
    }
}
