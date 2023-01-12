using AdessoRideShareAPI.Models;
using AdessoRideShareAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TravelPlanController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TravelPlan travelPlan)
        {
            _context.TravelPlans.Add(travelPlan);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("/published")]
        public async Task<IActionResult> GetActiveTravelPlanByFromAndTo(string from, string to)
        {
            var travelPlans = await _context.TravelPlans.Where(tp => tp.From == from && tp.To == to).ToListAsync();

            if (travelPlans == null)
            {
                return NotFound();
            }

            return Ok(travelPlans);
        }


        [HttpGet("/PublishedTravelPlans")]
        public List<TravelPlan> GetAllPublishedTravelPlans()
        {
            return _context.TravelPlans.Where(t => t.Published).ToList();
        }

        [HttpPatch("/publish/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var entity = _context.TravelPlans.FirstOrDefault(t => t.Id == id);

            if (entity != null)
            {
                entity.Published = true;

                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpPatch("/published/{id}")]
        public async Task<IActionResult> UpdateNumberOfSeats(int id)
        {
            var entity = _context.TravelPlans.FirstOrDefault(t => t.Id == id);
            if (entity != null)
            {
                if (entity.OccupiedNoOfSeats < entity.MaxNoOfSeats)
                {
                    entity.OccupiedNoOfSeats++;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }

            return NotFound();
        }
    }
}