using Objects.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UWP.Library.Canvas.Database
{
    public static class DatabaseContext
    {
        public static List<Person> People = new List<Person>
       {
                new Person{ Name = "Gabe"},
                new Person{ Name = "Mike" },
                new Person{ Name = "JJ" }
        };
    }
}
