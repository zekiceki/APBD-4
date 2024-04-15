using Microsoft.AspNetCore.Mvc;
using Task4.models;

namespace Task4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : ControllerBase
    {
        private static List<Visit> visits = new List<Visit>();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(visits);
        }
        [HttpGet("{animalId}")]
        public IActionResult GetByAnimalId(Guid animalId)
        {
            var animalVisits = visits.Where(v => v.AnimalId == animalId).ToList();
            if (animalVisits.Count == 0) return NotFound("No visits found for this animal.");
            return Ok(animalVisits);
            
        }
        [HttpPost]
        public IActionResult Post(Visit visit)
        {
            visits.Add(visit);
            return CreatedAtAction(nameof(GetByAnimalId), new { animalId = visit.AnimalId }, visit);
        }
    }
}