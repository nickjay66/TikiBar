using Microsoft.AspNetCore.Mvc;
using TikiBar.Models;
using TikiBar.Services;

namespace TikiBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : Controller
    {
        public DrinkController()
        {
        }

        [HttpGet]
        public ActionResult<List<Drink>> GetAll() =>
            DrinkService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Drink> Get(int id)
        {
            var drink = DrinkService.Get(id);
            if (drink == null)
                return NotFound();

            return drink;
        }

        [HttpPost]
        public IActionResult Create(Drink drink)
        {
            DrinkService.Add(drink);
            return CreatedAtAction(nameof(Create), new { id = drink.Id }, drink);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Drink drink)
        {
            if (id != drink.Id)
                return BadRequest();

            var existingDrink = DrinkService.Get(id);
            if (existingDrink == null)
                return NotFound();

            DrinkService.Update(drink);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drink = DrinkService.Get(id);
            if (drink == null)
                return NotFound();

            DrinkService.Delete(id);

            return NoContent();
        }



    }
}
