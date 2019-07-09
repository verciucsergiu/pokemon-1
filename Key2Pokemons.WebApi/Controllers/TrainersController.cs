using System;
using Key2Pokemons.Business;
using Key2Pokemons.DataAccess.Memory;
using Key2Pokemons.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Key2Pokemons.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : Controller
    {
        private const string GetByIdRoute = "GetTrainerById";
        private readonly TrainerService trainerService;

        public TrainersController()
        {
            trainerService = new TrainerService(new TrainersRepository());
        }
        
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(trainerService.GetAll());
        }

        [HttpGet("{id:guid}", Name = GetByIdRoute)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var trainer = trainerService.GetTrainer(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] CreateTrainerModel model)
        {
            var trainerId = trainerService.Create(model.Name);

            return CreatedAtRoute(GetByIdRoute, new {id = trainerId}, new { id = trainerId });
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] UpdateTrainerModel model)
        {
            var trainer = trainerService.GetTrainer(id);
            if (trainer == null)
            {
                return NotFound();
            }

            trainerService.Update(id, model.Name);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Disqualify([FromRoute] Guid id)
        {
            var trainer = trainerService.GetTrainer(id);
            if (trainer == null)
            {
                return NotFound();
            }

            trainerService.Disqualify(id);

            return NoContent();
        }
    }
}
