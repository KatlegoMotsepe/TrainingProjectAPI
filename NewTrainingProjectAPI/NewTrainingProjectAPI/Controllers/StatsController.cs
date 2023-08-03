using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTrainingProjectAPI.Data;
using NewTrainingProjectAPI.DTOs;
using NewTrainingProjectAPI.Models;

namespace NewTrainingProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly DataContext _context;
        public StatsController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet("GetAllStats")]
        public async Task<IActionResult> GetContact()
        {
            var stats = await _context.SessionStats.ToListAsync();

            if (stats == null) { return NotFound(); }

            return Ok(stats);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStat(AddStatsDTO addStatsDTO)
        {
            if (addStatsDTO == null) { return BadRequest("You can't enter nothing"); }
            await _context.SessionStats.AddAsync(new SessionStats(addStatsDTO));
            await _context.SaveChangesAsync();
            return Ok(addStatsDTO);
        }
    }
}
