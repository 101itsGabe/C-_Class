using Newtonsoft.Json;
using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Library.Canvas.DTO;
using UWP.Library.Canvas.Util;

namespace UWP.Canavs.ViewModels
{
    public class AddPersonViewModel
    {
        public Person curPerson { get; set; }
        public StudentService studentService;
        public ObservableCollection<Person> People;
        public PersonDTO Dto { get; set; }
        public AddPersonViewModel(ObservableCollection<Person> p)
        {
            studentService = StudentService.Current;
            //curPerson= new Person();
            People = p;
            Dto = new PersonDTO();
        }

        public string Name {
            get { return curPerson.Name; }
            set { curPerson.Name = value; }
        }

        public AddPersonViewModel(PersonDTO dto)
        {
            Dto = dto;
        }

        public async Task<PersonDTO> AddPerson()
        {
            var handler = new WebRequestHandler();
            var returnVal = await handler.Post("http://localhost:5084/Person", Dto);
            var deserializedReturn = JsonConvert.DeserializeObject<PersonDTO>(returnVal);
            return deserializedReturn;
        }
        
        public void setPerson(string n)
        {
            if(n.Equals("F") || n.Equals("S") || n.Equals("SP") || n.Equals("J"))
            {
                curPerson = new Student(curPerson);
                switch (n)
                {
                    case "F":
                        (curPerson as Student).Classification = PersonClassification.Freshman;
                        break;
                    case "SP":
                        (curPerson as Student).Classification = PersonClassification.Sophmore;
                        break;
                    case "J":
                        (curPerson as Student).Classification = PersonClassification.Junior;
                        break;
                    case "S":
                        (curPerson as Student).Classification = PersonClassification.Senior;
                        break;
                }
                
            }

            else
            {
                if(n.Equals("TA"))
                {
                    curPerson = new TeachingAssistant(curPerson);
                }
                else 
                {
                    curPerson = new Instructor(curPerson);
                }
            }
        }
    }
}
