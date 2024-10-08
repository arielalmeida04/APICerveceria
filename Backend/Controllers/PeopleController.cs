using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController([FromKeyedServices("people2Service")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;
        [HttpGet("{id}")]
        public ActionResult<People> Get(int id){
            var people = Repository.People.FirstOrDefault(p => p.ID == id);
            if (people == null)
            {
                return NotFound();
            }
            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        [HttpPost]
        public IActionResult Add(People people) 
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return NoContent();
        }

    }
   
    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                ID = 1, Name="Alma", Birthdate=new DateTime(2002,3,3)

            },
             new People()
             {
                ID = 2, Name="Ariel", Birthdate=new DateTime(2001,10,19)

             },
              new People()
              {
                ID = 3, Name="Melina", Birthdate=new DateTime(1970,5,28)

              },
               new People()
               {
                ID = 4, Name="Martin", Birthdate=new DateTime(1981,4,5)

               },
        new People()
               {
                ID = 5, Name="Oziel", Birthdate=new DateTime(2002,3,11)

               }

        };
    }
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
