using Microsoft.AspNetCore.Mvc;
using Objects.Models;
using UWP.Library.Canvas.Database;
using Canvas.Api.EC;
using UWP.Library.Canvas.DTO;

namespace Canvas.Api.Controllers
{
    [ApiController]  //Decerators telling the .net runtime that these are not reulgar classes
    [Route("[controller]")]
    public class PersonController
    {
        private readonly ILogger<PersonController> _logger;


        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<PersonDTO> Get()
        {
            return new PersonEC().GetPeople();
        }

        [HttpPost]
        public PersonDTO AddOrUpdate([FromBody] PersonDTO dto)
        {
            return new PersonEC().AddOrUpdatePerson(dto);
        }


    }
}
