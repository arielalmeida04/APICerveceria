using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        public BeerController(StoreContext context)
        {
            _context = context;
        }

        //En este Task estoy obteniendo el contenido de todos los valores de la tabla
        [HttpGet]
        public async Task<IEnumerable<BeerDTO>> Get() =>

           await _context.Beers.Select(b => new BeerDTO
           {
               Id = b.BeerId,
               Name = b.BeerName,
               Alcohol = b.Alcohol,
               Brandid = b.BrandId

           }).ToListAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDTO>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerDTO = new BeerDTO
            {
                Id = beer.BeerId,
                Name = beer.BeerName,
                Alcohol = beer.Alcohol,
                Brandid = beer.BrandId
            };
            return Ok(beerDTO);
        }

    }

}

