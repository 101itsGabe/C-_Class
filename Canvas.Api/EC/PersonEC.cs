using Objects.Models;
using UWP.Library.Canvas.Database;
using UWP.Library.Canvas.DTO;

namespace Canvas.Api.EC
{
    public class PersonEC
    {
        public List<PersonDTO> GetPeople()
        {
            return DatabaseContext.People.Select(s => new PersonDTO(s)).ToList();
        }

        public PersonDTO AddOrUpdatePerson(PersonDTO p)
        {
            if(p.Id <= 0)
            {
                var lastId = DatabaseContext.People.Select(person => person.Id).Max();
                p.Id = ++lastId;
            }
            DatabaseContext.People.Add(new Person(p));
            return p;
        }
    }
}
