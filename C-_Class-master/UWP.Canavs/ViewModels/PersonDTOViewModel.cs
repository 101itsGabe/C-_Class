using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Library.Canvas.DTO;

namespace UWP.Canavs.ViewModels
{
    public class PersonDTOViewModel
    {
        public PersonDTO Dto { get; set; }
        public string Display
        {
            get
            {
                return $"[{Dto.Id}] {Dto.Name}";
            }
        }

        public PersonDTOViewModel() { }
        public PersonDTOViewModel(PersonDTO dto) 
        {
            Dto = dto;
        }
    }
}
