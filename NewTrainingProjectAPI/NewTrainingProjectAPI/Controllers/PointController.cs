
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTrainingProjectAPI.Data;
using NewTrainingProjectAPI.DTOs;
using NewTrainingProjectAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewTrainingProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly DataContext _context;
        public PointController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet("GetPoints")]
        public async Task<IActionResult> GetPoint()
        {
            var points = await _context.Points.ToListAsync();

            if (points == null) { return NotFound(); }

            return Ok(points);

        }

        //f7265ff6-6527-4ce5-9f1b-08db91cb4f05


        [HttpPost("Add")] //Over explaining is a thing.
        public async Task<IActionResult> RegiterUSer(AddPointsDTO addPointsDTO)
        {
            if (addPointsDTO == null) { return BadRequest("You can't enter nothing"); }
            await _context.Points.AddAsync(new Points(addPointsDTO));
            await _context.SaveChangesAsync();
            return Ok(addPointsDTO);
        }



    }
}
