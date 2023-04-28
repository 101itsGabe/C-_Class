using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Text;
using UWP.Library.Canvas.Models;

namespace UWP.Library.Canvas.DTO
{
    public class PersonDTO
    {
        public string Name { get; set; }
        public int Id
        {
            get; set;
        }

        public PersonDTO (Person s)
        {
            Id = s.Id;
            Name = s.Name;
            
        }

        public PersonDTO() 
        {

        }

        
    }
}
