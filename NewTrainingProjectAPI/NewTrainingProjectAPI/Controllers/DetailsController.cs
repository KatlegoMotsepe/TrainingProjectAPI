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
    public class DetailsController : ControllerBase
    {
        private readonly DataContext _context;
        public DetailsController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost("Add")] //Over explaining is a thing.
        public async Task<IActionResult> AddDetails(AddDetailsDTO addDetailsDTO)
        {
            if(addDetailsDTO == null) { return BadRequest("You can't enter nothing"); }
            await _context.SessionDetails.AddAsync(new SessionDetails(addDetailsDTO));
            await _context.SaveChangesAsync();
            return Ok(addDetailsDTO);
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails()
        {
            var details = await _context.SessionDetails.ToListAsync();

            if (details == null) { return NotFound(); }

            return Ok(details);

        }

        [HttpGet("GetDetails/{id}")]
        public async Task<IActionResult> GetResultAndPoints(Guid id)
        {
            var details = await _context.SessionDetails.Include(x => x.Points).FirstOrDefaultAsync(x => x.Id == id);
            if (details == null) { return NotFound();}
            return Ok(details);
        }
    }
}
