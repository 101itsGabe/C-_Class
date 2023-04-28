using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Library.Canvas.DTO;

namespace Objects.Models
{
    public class Person : Item 
    {
       
        private static int lastId = 0;

        public int Id
        {
            get; protected set;
        }

        public Person(PersonDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
        }
        public Person()
        {
            Name = string.Empty;
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}